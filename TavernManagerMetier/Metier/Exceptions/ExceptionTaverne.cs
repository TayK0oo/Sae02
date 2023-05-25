using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TavernManagerMetier.Metier.Exceptions
{
    public class ExceptionTaverne : Exception
    {
        public ExceptionTaverne():base("La taverne n'est pas valide, au moins deux amis d'un client sont ennemis entre eux") 
        {

        }
    }
}
