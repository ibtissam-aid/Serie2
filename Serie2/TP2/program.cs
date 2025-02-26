using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2.TP2
{
    internal class program
    {
        static void Main(string[] args)
        {
            Biblio maBiblio = new Biblio();


            maBiblio.Add(new Livre("Ghailani Mohammed ", 350, "C# Avancé"));
            maBiblio.Add(new Livre("El hadad Mohammed ", 420, "Java"));
            maBiblio.Add(new Livre("El Mohammedi ", 420, " c++ "));
            maBiblio.Add(new Dictionnaire(" Français", 50000, " Dictionnaire Français"));
            maBiblio.Add(new Dictionnaire("English ", 60000, " Dictionary Anglais"));
            maBiblio.CalculernbLivres();//as cest faux 
            maBiblio.Calculer_NB_Livres();//is
            maBiblio.tousLesAuteurs();
            maBiblio.toutesLesDescriptions();
            //maBiblio.AfficherDictionnaire();



        }
    }
}