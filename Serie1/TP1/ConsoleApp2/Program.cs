using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
  public class Fichier
    {
        public string Nom { get; set; } 
        public string Extension { get; set; }
        public float Taille { get; set; }

        
        public Fichier(string nom, string extension, float taille)
        {
            Nom = nom; 
            Extension = extension; 
            Taille = taille; 
        }

        
        public override string ToString()
        {
            return $"{Nom}.{Extension} - {Taille} Ko";
        }
    }

  public class Repertoire
    {  public string Nom { get; set; }
        public int NbrFichiers { get; private set; } 
        private Fichier[] fichiers; 
        private const int Capacite = 30;

      
        public Repertoire(string nom)
        {
            Nom = nom;
            fichiers = new Fichier[Capacite];
            NbrFichiers = 0;
        }

    
        public void Afficher()
        {
            Console.WriteLine($"Répertoire : {Nom}");
            if (NbrFichiers == 0)
            {
                Console.WriteLine("Aucun fichier dans le répertoire.");
            }
            else
            {
                for (int i = 0; i < NbrFichiers; i++)
                {
                    Console.WriteLine(fichiers[i].ToString());
                }
            }
        }

       
        public void Ajouter(Fichier fichier)
        {
            if (NbrFichiers < Capacite)
            {
                fichiers[NbrFichiers++] = fichier;
                Console.WriteLine($"Fichier ajouté : {fichier.Nom}.{fichier.Extension}");
            }
            else
            {
                Console.WriteLine("Le répertoire est plein !");
            }
        }

        // Rechercher un fichier par nom
        public int Rechercher(string nom)
        {
            for (int i = 0; i < NbrFichiers; i++)
            {
                if (fichiers[i].Nom.Equals(nom, StringComparison.OrdinalIgnoreCase))
                {
                    return i; // Retourne l'indice du fichier trouvé
                }
            }
            return -1; // Retourne -1 si le fichier n'est pas trouvé
        }

        // Méthode : Rechercher les fichiers par extension
        public void RechercherParExtension(string extension)
        {
            Console.WriteLine($"Fichiers avec l'extension .{extension} :");
            bool trouve = false;

            for (int i = 0; i < NbrFichiers; i++)
            {
                if (fichiers[i].Extension.Equals(extension, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(fichiers[i].ToString());
                    trouve = true;
                }
            }

            if (!trouve)
            {
                Console.WriteLine("Aucun fichier trouvé avec cette extension.");
            }
        }

        // Méthode : Supprimer un fichier
        public void Supprimer(string nom)
        {
            int index = Rechercher(nom);
            if (index != -1)
            {
                for (int i = index; i < NbrFichiers - 1; i++)
                {
                    fichiers[i] = fichiers[i + 1];
                }

                fichiers[--NbrFichiers] = null; // Réduit le compteur et supprime la référence
                Console.WriteLine($"Fichier {nom} supprimé.");
            }
            else
            {
                Console.WriteLine($"Fichier {nom} introuvable.");
            }
        }

        // Méthode : Renommer un fichier
        public void Renommer(string ancienNom, string nouveauNom)
        {
            int index = Rechercher(ancienNom);
            if (index != -1)
            {
                fichiers[index].Nom = nouveauNom;
                Console.WriteLine($"Fichier renommé : {ancienNom} -> {nouveauNom}");
            }
            else
            {
                Console.WriteLine($"Fichier {ancienNom} introuvable.");
            }
        }

        // Méthode : Modifier la taille d'un fichier
        public void ModifierTaille(string nom, float nouvelleTaille)
        {
            int index = Rechercher(nom);
            if (index != -1)
            {
                fichiers[index].Taille = nouvelleTaille;
                Console.WriteLine($"Taille du fichier {nom} modifiée à {nouvelleTaille} Ko.");
            }
            else
            {
                Console.WriteLine($"Fichier {nom} introuvable.");
            }
        }

        // Méthode : Calculer la taille totale du répertoire en Mo
        public float GetTaille()
        {
            float tailleTotale = 0;
            for (int i = 0; i < NbrFichiers; i++)
            {
                tailleTotale += fichiers[i].Taille;
            }
            return tailleTotale / 1024; // Convertit la taille en Mo
        }
    }
   
class Program
    {
        static void Main(string[] args)
        {
            // Création du répertoire
            Repertoire rep = new Repertoire("MesDocuments");

            // Ajout de fichiers
            rep.Ajouter(new Fichier("Rapport", "pdf", 1500));
            rep.Ajouter(new Fichier("Photo", "jpg", 2048));
            rep.Ajouter(new Fichier("Musique", "mp3", 5120));

            // Afficher le contenu du répertoire
            rep.Afficher();

            // Rechercher un fichier par nom
            int index = rep.Rechercher("Photo");
            Console.WriteLine(index != -1 ? "Fichier trouvé !" : "Fichier introuvable.");

            // Rechercher par extension
            rep.RechercherParExtension("pdf");

            // Supprimer un fichier
            rep.Supprimer("Musique");

            // Renommer un fichier
            rep.Renommer("Photo", "Image");

            // Modifier la taille d'un fichier
            rep.ModifierTaille("Image", 3000);

            // Afficher la taille totale du répertoire
            Console.WriteLine($"Taille totale : {rep.GetTaille()} Mo");

            // Afficher le contenu mis à jour
            rep.Afficher();
        }
    }


}
