using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Serie2
{
    internal class Gestion_Emp
    {
        List<Employe> list_Emp = new List<Employe>();

        public void Ajouter(Employe employe)
        {
            list_Emp.Add(employe);
        }
        public void Supprimer(Employe employe)
        {
            list_Emp.Remove(employe);
        }
        public double CalculerSalaireEntrprise()
        {
            double Total = 0;
            foreach (var employe in list_Emp)
            {
                Total += employe.salaire;
            }
            return Total;
        }

        public double CalculerMoyEmp(Employe employe)
        {
            if (list_Emp.Count > 0)
            {


                return CalculerSalaireEntrprise() / list_Emp.Count;
            }
            return 0;
        }

    }
}
