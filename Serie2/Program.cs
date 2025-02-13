using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gestion_Emp gestion = new Gestion_Emp();
            gestion.Ajouter(new Employe("Safaa",233333.665, "chef de dequipe ", "2023-04-11"));
            gestion.Ajouter(new Employe("chaimae", 533333.665, "chef de hamam ", "2023-04-11"));
            gestion.Ajouter(new Employe("meryem", 233333.665, "chef d darat ", "2023-04-11"));
            Directeur directeur = Directeur.getInstance();
            directeur.setGestionEmployes(gestion);
           




        }
    }
}
