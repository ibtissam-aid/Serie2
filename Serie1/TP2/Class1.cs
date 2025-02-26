using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banque banque = new Banque();
            banque.ChargerComptes();
            banque.Authentification();
        }
    }
}
