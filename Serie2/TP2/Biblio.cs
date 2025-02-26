using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2.TP2
{
    internal class Biblio
    {
        List<Document> docs;
        public Biblio()
        {
            docs = new List<Document>();
        }
        public void Add(Document doc)
        {
            if (!docs.Contains(doc))
         
                docs.Add(doc);
            
            else Console.WriteLine("ce docs existe deja"); 
        }
        public void Calculer_NB_Livres()
        {
            int nb = 0;

            foreach (Document doc in docs)
            {
                if (doc is Livre livre) //vérifier si un objet est d’un type spécifique.
                {
                    nb++;
                }
            }

            Console.WriteLine($"Nombre de livres : {nb}");
        }
        public void CalculernbLivres()//casting as 
        {
            int nb = 0;

            foreach (Document doc in docs)
            {
                Livre livre = doc as Livre ;
                
                    nb++;
                }
            


            Console.WriteLine($"Nombre de livres : {nb}");
        }
        public void AfficherDictionnaire()
        {
            foreach (Document doc in docs)
            {
                if (doc is Dictionnaire)
                {
                    //Console.WriteLine(doc.ToString());
                    Console.WriteLine( " voici dictionnaire:" + doc);
                }
            }
        }
        public void tousLesAuteurs()
        {
            Console.WriteLine("\n Liste des auteurs  :");
            foreach (var doc in docs)
            {
                if (doc is Livre livre)
                {
                    if (livre.auteur != null)
                    
                        Console.WriteLine(doc.num +"   " + livre.auteur);
                    
                }
            }
        }
        /*public void toutesLesDescriptions()
                {
                    foreach (var doc in docs)
                    {
                        if (doc is Livre livre)
                        {
                            Console.WriteLine(livre.Description());
                        }
                        if (doc is Dictionnaire dictionnaire)
                        {
                            Console.WriteLine(dictionnaire.Description());
                        }
                    }
        */
        public void toutesLesDescriptions()
        {
            Console.WriteLine("\n Descriptions de tous les documents :");
            foreach (var doc in docs)
            {
                Console.WriteLine(doc.Description());
            }
        }
    }
}
