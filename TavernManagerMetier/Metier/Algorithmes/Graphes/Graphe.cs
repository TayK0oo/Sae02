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
        public List<Sommet> Sommets { get => this.sommets.Values.Distinct().ToList<Sommet>();}

        private Dictionary<Client, Sommet> sommets;

        public Graphe(Taverne taverne)
        {
            this.sommets = new Dictionary<Client, Sommet>();

            /// On ajoute un sommet pour chaque client de la taverne
            foreach(Client client in taverne.Clients)
            {
                this.AjouterSommet(client, new Sommet());
                
            }

            /// On ajoute une arrête entre tous les ennemis parmi les clients
            foreach (Client client in taverne.Clients)
            {
                foreach (Client ennemi in client.Ennemis)
                {
                    AjouterArrete(client, ennemi);
                }
            }


            /*foreach (KeyValuePair<Client,Sommet> client in this.sommets)
            {
                if (client.Key.EstAvecUnEnnemis)
                {
                    this.sommets[client.Key].Clients.Remove(client.Key);
                    this.sommets[client.Key] = new Sommet();
                   
                }
            }*/
        }

        public void AjouterSommet(Client client, Sommet sommet)
        {
            if (!this.sommets.ContainsKey(client))
            {
                this.sommets[client] = sommet;
                this.sommets[client].Clients.Add(client);
                sommet.NbClients++;
                foreach (Client ami in client.Amis)
                {
                        this.AjouterSommet(ami, sommet);
                }

            }
        }

        public void AjouterArrete(Client client1, Client client2)
        {
            this.sommets[client1].Voisins.Add(this.sommets[client2]);
        }

    }
}
