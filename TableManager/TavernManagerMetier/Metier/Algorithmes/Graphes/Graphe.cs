using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavernManagerMetier.Metier.Tavernes;

namespace TavernManagerMetier.Metier.Algorithmes.Graphes
{
    public class Graphe
    {
        public List<Sommet> Sommets { get => this.sommets.Values.Distinct().ToList<Sommet>(); }

        private Dictionary<Client, Sommet> sommets;

        public Graphe(Taverne taverne)
        {
            this.sommets = new Dictionary<Client, Sommet>();
            foreach(Client client in taverne.Clients)
            {
                this.AjouterSommet(client, new Sommet());
                
            }
            foreach (Client client in taverne.Clients)
            {
                foreach (Client ennemi in client.Ennemis)
                {
                    AjouterArrete(client, ennemi);
                }
            }
        }

        public void AjouterSommet(Client client, Sommet sommet)
        {
            if (!this.sommets.ContainsKey(client))
            {
                
                this.sommets[client] = sommet;
                
                sommet.NbClients++;
                foreach (Client ami in client.Amis)
                {
                    foreach (Client enemi in ami.Ennemis)
                    {
                        if (!ami.Ennemis.Contains(enemi))
                        {
                            this.sommets[ami] = sommet;
                            sommet.NbClients++;
                            this.AjouterSommet(ami, sommet);
                        }
                        
                    }

                }
            }
        }

        public void AjouterArrete(Client client1, Client client2)
        {
            this.sommets[client1].Voisins.Add(this.sommets[client2]);
        }

    }
}
