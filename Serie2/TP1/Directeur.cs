using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2
{
    internal class Directeur
    {
        Gestion_Emp gest_emp;
        static Directeur Instance ;

        private Directeur() {
            gest_emp = new Gestion_Emp();// jai pas de cstr donc cest par defaut
        }
        public void  setGestionEmployes( Gestion_Emp gestion_)
        {
            gest_emp = gestion_;
        }
        public  static Directeur getInstance()
        {
            if (Instance == null)
            {
                Instance = new Directeur();
            }
            return Instance;
        }
       

        public double CalculerSalaireTotal()
        {
            return gest_emp.CalculerSalaireEntrprise();

        }
        public double SalaireMoyen()
        {
            return gest_emp.CalculerMoyEmp();
        }
          public void AfficherInfos()
        {
            Console.WriteLine("le salaire total :" + CalculerSalaireTotal() + "\n" + "le salaire Moyen:" + SalaireMoyen());
        }  
 
        


    }
}
