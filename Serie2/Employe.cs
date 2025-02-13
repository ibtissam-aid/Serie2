using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2
{
    internal class Employe
    {
        string Nom;
        double Salaire;
        string Poste;
        string Date_embauche;
            public Employe(string name , double sal,string poste,string date_emb) {
            Nom=name;
            Salaire=sal;
            Poste=poste;
            Date_embauche=date_emb;

            }
        public string name
        {
            get
            {
                return Nom;
            }


                set { Nom = value; }

        }
        public double  salaire
        {
            get
            {
                return Salaire;
            }


            set { Salaire = value; }

        }

        public string poste
        {
            get
            {
                return Poste;
            }


            set { Poste = value; }

        }
        public string date
        {
            get
            {
                return Date_embauche;
            }


            set {Date_embauche = value; }

        }
    }
}
