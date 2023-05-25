using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavernManagerMetier.Metier.Tavernes;

namespace TavernManagerMetier.Metier.Algorithmes.Graphes
{
    public class Sommet
    {
        private List<Client> clients;
        public List<Client> Clients
        {
            get => clients.Distinct().ToList();
            set => clients = value;
        }

        private List<Sommet> voisins;

        public List<Sommet> Voisins { get => voisins; set => voisins = value; }
        
        private int nbClients;
        public int NbClients { get => nbClients; set => nbClients = value; }

        


        public Sommet()
        {
            this.voisins = new List<Sommet>();
            this.nbClients = 0;
        }

        public void AjouterVoisin(Sommet sommet)
        {
            this.voisins.Add(sommet);
        }


    }
}
