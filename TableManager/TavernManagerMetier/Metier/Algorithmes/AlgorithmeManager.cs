using System.Collections.Generic;
using TavernManagerMetier.Metier.Algorithmes.Graphes;
using TavernManagerMetier.Metier.Algorithmes;
using TavernManagerMetier.Metier.Tavernes;
using System.Linq;

public class AlgorithmeLDO : IAlgorithme
{
    public string Nom => "LDO";

    public long TempsExecution { get; private set; }

    public void Executer(Taverne taverne)
    {
        Graphe graphe = new Graphe(taverne);
        List<Client> invitesNonPlaces = taverne.Clients.ToList();

        while (invitesNonPlaces.Count > 0)
        {
            Table table = taverne.AjouterTable();
            List<Client> invitesPlaces = new List<Client>();

            // Sélection du premier invité non placé
            Client invite = invitesNonPlaces[0];
            invitesPlaces.Add(invite);
            invitesNonPlaces.Remove(invite);

            // Placement des invités compatibles sur la même table
            for (int i = 0; i < invitesNonPlaces.Count; i++)
            {
                Client autreInvite = invitesNonPlaces[i];
                if (!EstEnnemi(graphe, invite, autreInvite) && !EstEnnemiAvecTable(table, graphe, autreInvite))
                {
                    invitesPlaces.Add(autreInvite);
                }
            }

            // Ajout des invités placés à la table
            foreach (Client invitePlace in invitesPlaces)
            {
                taverne.AjouterClientTable(invitePlace.Numero, table.Numero);
                invitesNonPlaces.Remove(invitePlace);
            }
        }
    }

    private bool EstEnnemi(Graphe graphe, Client invite1, Client invite2)
    {
        return graphe.Sommets.Contains(invite1) && graphe.Sommets.Contains(invite2) && invite1.Ennemis.Contains(invite2);
    }

    private bool EstEnnemiAvecTable(Table table, Graphe graphe, Client invite)
    {
        foreach (Client clientTable in table.Clients)
        {
            if (EstEnnemi(graphe, invite, clientTable))
            {
                return true;
            }
        }
        return false;
    }
}