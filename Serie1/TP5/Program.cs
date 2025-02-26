using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp5;

namespace Serie1.TP5
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



