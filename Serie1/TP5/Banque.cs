using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp5
{
    internal class Banque
    {
        private List<CompteBancaire> CB;
        private static int nbr_compte = 0;
        private Dictionary<string, string> utilisateurs;


        public Banque()
        {
            CB = new List<CompteBancaire>();

        }
        public void Authentification()
        {
            Console.Write("Login: ");
            string login = Console.ReadLine();
            Console.Write("Mot de passe: ");
            string password = Console.ReadLine();

            if (utilisateurs.ContainsKey(login) && utilisateurs[login] == password)
            {
                Console.WriteLine("Authentification réussie!\n");
                MenuPrincipal();
            }
            else
            {
                Console.WriteLine("Identifiants incorrects.");
            }
        }

        private void MenuPrincipal()
        {
            int choix;
            do
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("1) Ajouter un nouveau compte");
                Console.WriteLine("2) Rechercher un compte");
                Console.WriteLine("3) Supprimer un compte");
                Console.WriteLine("4) Operation sur un compte");
                Console.WriteLine("5) Afficher tous les comptes");
                Console.WriteLine("6) Quitter le programme");
                Console.WriteLine("==========================================");
                Console.Write("Donnez votre choix:");
                choix = Int32.Parse(Console.ReadLine());

                switch (choix)
                {
                    case 1: AjouterCompte(); break;
                    case 2: RechercherCompte(); break;
                    case 3: SupprimerCompte(); break;
                    case 4: OperationCompte(); break;
                    case 5: AfficherToutComptes(); break;
                }
            } while (choix != 6);
        }

        public void RechercherCompte()
        {
            Console.Write("Numéro du compte: ");
            int num = int.Parse(Console.ReadLine());
            foreach (CompteBancaire compte in CB)
            {
                if (compte.No_compte == num)
                {
                    CompteBancaire C = compte;
                    Console.WriteLine("numero de compte :" + C.No_compte + " nom du client : " + C.Nom_client + C.Prenom_client + " solde : " + C.Solde + compte.Historique.Count + "operations effectuees");
                }
            }

        }
        public void AjouterCompte()
        {
            Console.Write("Entrez le num du compte bancaire: ");
            int numCompte = Int32.Parse(Console.ReadLine());
            Console.Write("Entrez le nom du client: ");
            string nomClient = Console.ReadLine();
            Console.Write("Entrez son prenom: ");
            string prenomClient = Console.ReadLine();
            Console.WriteLine("donnez votre solde innitial : ");
            double solde = double.Parse(Console.ReadLine());
            CB.Add(new CompteBancaire(numCompte, nomClient, prenomClient, solde));
            nbr_compte++;
            Console.WriteLine("Creation de compte effectue.....");
        }
        public void SupprimerCompte()
        {
            Console.Write("Entrez le num du compte bancaire: ");
            int numCompte = Int32.Parse(Console.ReadLine());
            foreach (CompteBancaire compte in CB)
            {
                if (compte.No_compte == numCompte)
                {
                    CompteBancaire C = compte;
                    CB.Remove(C);
                    nbr_compte--;
                    Console.WriteLine("Compte suprime .....");
                }
            }
        }

        public void OperationCompte()
        {
            CompteBancaire C = new CompteBancaire();
            Console.Write("Numéro du compte: ");
            int num = int.Parse(Console.ReadLine());
            foreach (CompteBancaire compte in CB)
            {
                if (compte.No_compte == num)
                {
                    C = compte;
                }
            }
            if (C != null)
            {
                Console.WriteLine("1. Créditer ");
                Console.WriteLine("2. Débiter");
                Console.WriteLine("3. Historique");
                Console.WriteLine("4. Transfert d'argents");
                Console.WriteLine("5. Revenir au menu principal");
                int choix = int.Parse(Console.ReadLine());
                switch (choix)
                {
                    case 1:
                        Console.Write("entrer le montant a verser: ");
                        double montant = double.Parse(Console.ReadLine());
                        C.Crediter(montant);
                        break;
                    case 2:
                        Console.Write("enter le montant a retirer: ");
                        double Montant = double.Parse(Console.ReadLine());
                        C.Debiter(Montant);
                        break;
                    case 3:
                        C.AfficherHistorique();
                        break;
                    case 4:
                        Console.WriteLine("Entrer le numero du destinataire : ");
                        int Num = int.Parse(Console.ReadLine());
                        Console.WriteLine("Entrer le montant a transferer : ");
                        double Mt = double.Parse(Console.ReadLine());
                        foreach (CompteBancaire compte in CB)
                        {
                            if (compte.No_compte == num)
                            {
                                CompteBancaire CbDestinataire = compte;
                                C.Transferer(CbDestinataire, Mt);
                            }
                        }

                        break;
                }

            }
            else
            {
                Console.WriteLine("Compte non trouvé.");
            }
        }
        public void AfficherToutComptes()
        {
            foreach (CompteBancaire compte in CB)
            {
                Console.WriteLine(compte.No_compte + compte.Prenom_client + compte.Nom_client + compte.Solde + compte.Historique.Count + "operations effectuees");
            }
        }

    }
}
