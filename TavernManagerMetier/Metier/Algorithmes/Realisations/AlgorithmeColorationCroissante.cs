using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavernManagerMetier.Metier.Algorithmes.Graphes;
using TavernManagerMetier.Metier.Tavernes;

namespace TavernManagerMetier.Metier.Algorithmes.Realisations
{
    public class AlgorithmeColorationCroissante : IAlgorithme
    {
        public string Nom { get => "Coloration croissante"; }


        private long tempsExecution = -1;
        public long TempsExecution { get => this.tempsExecution; }

        public void Executer(Taverne taverne)
        {
            Graphe graphe = new Graphe(taverne); // Création graphe

            // Colorisation du graphe
            int c = 0;
            foreach (Sommet sommet in graphe.Sommets) // Pour chaque sommet du graphe
            {
                c = 0;
                foreach(Sommet voisin in sommet.Voisins) // Pour chaque voisin du sommet 
                {
                    foreach(Sommet v in sommet.Voisins) // Pour chaque voisin du sommet
                    {
                        if(c == v.Couleur) // si le compteur de colorisation est égal à la couleur du voisin
                        {
                            c++;
                        }
                    }
                    
                }
                sommet.Couleur = c; // on colore le sommet
            }
            int maxCouleur = 0; // correspond à la valeur max de couleur 
            foreach(Sommet sommet in graphe.Sommets) // Calcul...
            {
                if(sommet.Couleur > maxCouleur)
                {
                    maxCouleur= sommet.Couleur;
                }
            }

            int numTable = 0; // numéro de table 
            
            // Colorisation croissante
            for(int i = 0; i <= maxCouleur; i++)
            {
                taverne.AjouterTable();
                foreach(Sommet sommet in graphe.Sommets)
                {
                    if(sommet.Couleur == i)
                    {
                        foreach(Client client in sommet.Clients)
                        {
                            if (!taverne.Tables[numTable].EstPleine)
                            {
                                taverne.AjouterClientTable(client.Numero, numTable);
                            }
                            else
                            {
                                numTable++;
                                taverne.AjouterTable();
                                taverne.AjouterClientTable(client.Numero, numTable);
                            }
                        }
                    }
                }
                numTable++;
            }






            //int numTable = 0;

            //void PasserTableSuivante()
            //{
            //    numTable++;
            //    if (taverne.Tables.Count() == numTable)
            //    {
            //        taverne.AjouterTable();
            //    }
            //}

            //void AjouterSommetTable(Sommet sommet)
            //{
            //    foreach (Client client in sommet.Clients)
            //    {
            //        if (taverne.Tables[numTable].EstPleine)
            //        {
            //            PasserTableSuivante();
            //        }
            //        taverne.AjouterClientTable(client.Numero, numTable);
            //    }
            //}

            //Graphe graphe = new Graphe(taverne);
            //List<Sommet> aPlacer = graphe.Sommets;
            //taverne.AjouterTable();

            // Sort the sommets in increasing order of the number of clients
            //aPlacer.Sort((s1, s2) => s1.Clients.Count.CompareTo(s2.Clients.Count));

            //foreach (Sommet sommet in aPlacer)
            //{   PasserTableSuivante();
            //    AjouterSommetTable(sommet);
                
            //}
        }



        /*int numTable;
        List<Client> nPlace = taverne.Clients.ToList();  

        void PasserTableSuivante()
        {
            numTable++;
            if (numTable >= taverne.Tables.Count())
            {
                taverne.AjouterTable();
            }
        }





        taverne.AjouterTable();
        taverne.AjouterClientTable(0, 0);
         for(int i = 0; i < taverne.Clients.Count();i++)
        {

            bool estPlace = false;
            numTable = 0;
            while (!estPlace) { 
                foreach(Table table in taverne.Tables)
                {
                    bool aEnnemis = false;
                    foreach (Client client in table.Clients)
                    {
                        if (taverne.Clients[i].EstEnnemisAvec(client))
                        {
                            aEnnemis = true;
                        }
                    }
                    if (!estPlace)
                    {
                        if (aEnnemis)
                        {
                            PasserTableSuivante();
                        }
                        else
                        {
                            if (!table.EstPleine)
                            {
                                taverne.AjouterClientTable(i, numTable);
                                estPlace = true;
                            }
                            else
                            {
                                PasserTableSuivante();
                            }
                        }
                    }

                }
            }
        }*/
    }
}

