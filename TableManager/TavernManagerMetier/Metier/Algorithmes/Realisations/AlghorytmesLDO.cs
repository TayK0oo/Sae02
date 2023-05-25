using System;
using System.Collections.Generic;
using System.Linq;
using TavernManagerMetier.Metier.Algorithmes;
using TavernManagerMetier.Metier.Algorithmes.Graphes;
using TavernManagerMetier.Metier.Tavernes;

namespace TavernManagerMetier.Metier.Algorithmes.Realisations
{
    public class AlgorithmeLDO : IAlgorithme
    {
        public string Nom => "LDO";

        public long TempsExecution => -1;

        public void Executer(Taverne taverne)
        {
            Graphe graphe = new Graphe(taverne);
            Console.WriteLine(graphe.Sommets.Count());

            // Tri des sommets par degré décroissant
            List<Sommet> sommetsTriés = graphe.Sommets.OrderByDescending(s => s.Voisins.Count).ToList();

            // Coloration des sommets en utilisant la plus petite couleur possible
            foreach (Sommet sommet in sommetsTriés)
            {
                while(sommet.NbClients != 0)
                {
                    sommet.Clients
                }             
            }
        }

        
    }
}