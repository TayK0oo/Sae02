using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TavernManagerMetier.Metier.Algorithmes.Graphes;

namespace TavernManagerMetier.Metier.Tavernes.Fabriques
{
    /// <summary>
    /// Fabrique de taverne aléatoire
    /// </summary>
    public class FabriqueTaverne
    {
        /// <summary>
        /// Création d'une taverne
        /// </summary>
        /// <param name="capaciteTables">Capacité des tables</param>
        /// <param name="nombreClients">Nombre de clients</param>
        /// <param name="densite">Densité des relations</param>
        /// <param name="proportionAmis">Proportion de relations amicales</param>
        /// <returns></returns>
        public Taverne CreerTaverne(int capaciteTables, int nombreClients, double densite, double proportionAmis)
        {
            bool estValide = false;
            Taverne taverne = null;
            while (!estValide)
            {
                //Création de la liste des clients
                List<Client> listeClients = (new FabriqueClient()).CreerListeClients(nombreClients, densite,proportionAmis);

                //Création de la taverne
                taverne = new Taverne(capaciteTables, listeClients);
                Graphe graphe = new Graphe(taverne);

                estValide = true;
                foreach(Sommet sommet in graphe.Sommets)
                {
                    foreach(Client client in sommet.Clients)
                    {
                        foreach(Client c in sommet.Clients)
                        {
                            if (client.Ennemis.Contains(c))
                            {
                                estValide = false;
                            }
                        }
                    }
                }
                //foreach (Client client in taverne.Clients)
                //{
                //    foreach (Client ami in client.Amis)
                //    {
                //        foreach (Client ennemi in ami.Ennemis)
                //        {
                //            if (client.Amis.Contains(ennemi))
                //            {
                //                estValide = false;
                                
                //            }
                //        }
                //    }
                    
                //}
            }
            
            

            return taverne;
        }


    }
}
