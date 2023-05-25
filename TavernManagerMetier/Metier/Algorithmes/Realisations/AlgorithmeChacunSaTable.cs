using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        private long tempsExecution = -1;
        public long TempsExecution { get => this.tempsExecution; }

        public void Executer(Taverne taverne)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Graphe graphe = new Graphe(taverne);
            for(int i = 0; i < taverne.Clients.Count(); i++)
            {
                taverne.AjouterTable();
                taverne.AjouterClientTable(taverne.Clients[i].Numero, i);
            }
            sw.Stop();
            this.tempsExecution = sw.ElapsedMilliseconds;
        }
    }
}
