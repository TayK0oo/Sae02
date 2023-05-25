using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavernManagerMetier.Metier.Algorithmes.Graphes;
using TavernManagerMetier.Metier.Tavernes;

namespace TavernManagerMetier.Metier.Algorithmes.Realisations
{
    public class AlgorithmeChacunSaTable: IAlgorithme
    {
        public string Nom { get => "Chacun sa table"; }

        public long TempsExecution { get => -1; }

        public void Executer(Taverne taverne)
        {
            Graphe graphe = new Graphe(taverne);
            Console.WriteLine(graphe.Sommets.Count());
            for(int i = 0; i < taverne.Clients.Count(); i++)
            {
                taverne.AjouterTable();
                taverne.AjouterClientTable(taverne.Clients[i].Numero, i);
            }
        }
    }
}
