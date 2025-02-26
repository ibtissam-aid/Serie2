using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Serie2.TP2
{
    internal class Livre : Document
    {
        string Auteur;
        int NbPages;
        public Livre(string auteur, int nb , string titre) : base(titre) {
            Auteur = auteur;
            NbPages = nb;

        }
        public string auteur
        {
            get { return Auteur; }
            set { Auteur = value; }
        }
        public int pages {  get { return NbPages; } set { NbPages = value; } }

        override
       public string Description()
        {
            return " cest un livre   d auteur  " + auteur + " \n le nombre de pages  :" + pages;
        }
    }
}
