using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TavernManagerMetier.Metier.Exceptions
{
    internal class Except : Exception
    {
        private string message;

        public override string Message { get { return message; } }

        public Except(string message) 
        { 
            this.message = message;
        }
    }
}
