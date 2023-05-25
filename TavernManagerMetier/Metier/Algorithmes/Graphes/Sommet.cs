using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TavernManagerMetier.Metier.Tavernes;

namespace TavernManagerMetier.Metier.Algorithmes.Graphes
{
    public class Sommet
    {
        private List<Sommet> voisins;

        private List<Client> clients;

        private int couleur;


        public List<Sommet> Voisins { get => voisins; set => voisins = value; }
        
        private int nbClients;
        public int NbClients { get => nbClients; set => nbClients = value; }
        public List<Client> Clients { get => clients; set => clients = value; }
        public int Couleur { get => couleur; set => couleur = value; }

        public Sommet()
        {
            this.voisins = new List<Sommet>();
            this.nbClients = 0;
            this.clients = new List<Client>();
            this.couleur = -1;
        }

        public void AjouterVoisin(Sommet sommet)
        {
            this.voisins.Add(sommet);
        }


    }
}
