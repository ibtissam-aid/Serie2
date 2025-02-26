using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2;

namespace TP2
{
    
    class Projet
    {
        private string  Code  ;
        private string sujet ;
        private string duree;
        private int NbProgrammeurs;
        public Projet(string code, string sjt, string dure, int nbProgrammeurs)
        {
            Code = code;
            sujet = sjt;
            duree = dure;
            NbProgrammeurs = nbProgrammeurs;
        }
    }
}
class Programmeur
{
    public int ID { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public int Bureau { get; set; }

    public Programmeur(int id, string nom, string prenom, int bureau)
    {
        ID = id;
        Nom = nom;
        Prenom = prenom;
        Bureau = bureau;
    }
}
class ConsommationCafe
{
    public int NoSemaine { get; set; }
    public int ProgrammeurID { get; set; }
    public int NbTasses { get; set; }

    public ConsommationCafe(int semaine, int programmeurID, int nbTasses)
    {
        NoSemaine = semaine;
        ProgrammeurID = programmeurID;
        NbTasses = nbTasses;
    }
}
class Program
{
    static List<Programmeur> programmeurs = new List<Programmeur>();
    static List<ConsommationCafe> consommations = new List<ConsommationCafe>();
    static Projet projet;

    static void Main()
    {
        // Création du projet
        Console.Write("Code du projet : ");
        string code = Console.ReadLine();
        Console.Write("Sujet du projet : ");
        string sujet = Console.ReadLine();
        Console.Write("Durée du projet (semaines) : ");
        int duree = int.Parse(Console.ReadLine());
        Console.Write("Nombre de programmeurs : ");
        int nbProgrammeurs = int.Parse(Console.ReadLine());

        projet = new Projet(code, sujet, duree, nbProgrammeurs);
        Console.WriteLine("\nProjet créé avec succès !");

        while (true)
        {
            Console.WriteLine("\nMenu :");
            Console.WriteLine("1. Ajouter un programmeur");
            Console.WriteLine("2. Rechercher un programmeur");
            Console.WriteLine("3. Afficher un programmeur");
            Console.WriteLine("4. Afficher la liste des programmeurs");
            Console.WriteLine("5. Supprimer un programmeur");
            Console.WriteLine("6. Ajouter une consommation de café");
            Console.WriteLine("7. Modifier le bureau d'un programmeur");
            Console.WriteLine("8. Afficher le total des tasses consommées en une semaine");
            Console.WriteLine("9. Quitter");
            Console.Write("Choix : ");
            int choix = int.Parse(Console.ReadLine());

            switch (choix)
            {
                case 1:
                    AjouterProgrammeur();
                    break;
                case 2:
                    RechercherProgrammeur();
                    break;
                case 3:
                    AfficherProgrammeur();
                    break;
                case 4:
                    AfficherListeProgrammeurs();
                    break;
                case 5:
                    SupprimerProgrammeur();
                    break;
                case 6:
                    AjouterConsommationCafe();
                    break;
                case 7:
                    ModifierBureauProgrammeur();
                    break;
                case 8:
                    AfficherTotalTassesSemaine();
                    break;
                case 9:
                    return;
                default:
                    Console.WriteLine("Choix invalide !");
                    break;
            }
        }
    }

    static void AjouterProgrammeur()
    {
        Console.Write("ID du programmeur : ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Nom : ");
        string nom = Console.ReadLine();
        Console.Write("Prénom : ");
        string prenom = Console.ReadLine();
        Console.Write("Bureau : ");
        int bureau = int.Parse(Console.ReadLine());

        programmeurs.Add(new Programmeur(id, nom, prenom, bureau));
        Console.WriteLine("Programmeur ajouté avec succès !");
    }

    static void RechercherProgrammeur()
    {
        Console.Write("ID du programmeur : ");
        int id = int.Parse(Console.ReadLine());

        var prog = programmeurs.FirstOrDefault(p => p.ID == id);
        if (prog != null)
        {
            Console.WriteLine($"Trouvé : {prog.Nom} {prog.Prenom}, Bureau {prog.Bureau}");
        }
        else
        {
            Console.WriteLine("Programmeur introuvable !");
        }
    }

    static void AfficherProgrammeur()
    {
        Console.Write("ID du programmeur : ");
        int id = int.Parse(Console.ReadLine());

        var prog = programmeurs.FirstOrDefault(p => p.ID == id);
        if (prog != null)
        {
            Console.WriteLine($"Programmeur : {prog.Nom} {prog.Prenom}, Bureau {prog.Bureau}");
        }
        else
        {
            Console.WriteLine("Programmeur introuvable !");
        }
    }

    static void AfficherListeProgrammeurs()
    {
        Console.WriteLine("\nListe des programmeurs :");
        foreach (var prog in programmeurs)
        {
            Console.WriteLine($"{prog.ID} - {prog.Nom} {prog.Prenom}, Bureau {prog.Bureau}");
        }
    }

    static void SupprimerProgrammeur()
    {
        Console.Write("ID du programmeur à supprimer : ");
        int id = int.Parse(Console.ReadLine());

        var prog = programmeurs.FirstOrDefault(p => p.ID == id);
        if (prog != null)
        {
            programmeurs.Remove(prog);
            Console.WriteLine("Programmeur supprimé !");
        }
        else
        {
            Console.WriteLine("Programmeur introuvable !");
        }
    }

    static void AjouterConsommationCafe()
    {
        Console.Write("ID du programmeur : ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Numéro de semaine : ");
        int semaine = int.Parse(Console.ReadLine());
        Console.Write("Nombre de tasses : ");
        int nbTasses = int.Parse(Console.ReadLine());

        consommations.Add(new ConsommationCafe(semaine, id, nbTasses));
        Console.WriteLine("Consommation enregistrée !");
    }

    static void ModifierBureauProgrammeur()
    {
        Console.Write("ID du programmeur : ");
        int id = int.Parse(Console.ReadLine());

        var prog = programmeurs.FirstOrDefault(p => p.ID == id);
        if (prog != null)
        {
            Console.Write("Nouveau numéro de bureau : ");
            int bureau = int.Parse(Console.ReadLine());
            prog.Bureau = bureau;
            Console.WriteLine("Bureau mis à jour !");
        }
        else
        {
            Console.WriteLine("Programmeur introuvable !");
        }
    }

    static void AfficherTotalTassesSemaine()
    {
        Console.Write("Numéro de semaine : ");
        int semaine = int.Parse(Console.ReadLine());

        int totalTasses = consommations.Where(c => c.NoSemaine == semaine).Sum(c => c.NbTasses);
        Console.WriteLine($"Total des tasses consommées en semaine {semaine} : {totalTasses}");
    }
}