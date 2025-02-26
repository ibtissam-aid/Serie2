using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2.TP2
{
    internal class Dictionnaire : Document
    {
        string Langue;
        int Nb_Def;
        public Dictionnaire(string langue, int nb_Def, string titre) : base(titre)
        {
            Langue = langue;
            Nb_Def = nb_Def;
        }
        public string langue {  get { return Langue; }  set { value = langue; } }
        public int nbDef {  get { return Nb_Def; } set { Nb_Def = value; } }

        override
        public  string Description()
        {
            return " cest un dictionnaire  de langue " + langue + "le titre : " + titre+ " \n le nombre de definition quel contient est :" +nbDef  ;
        }
    }
    
}
