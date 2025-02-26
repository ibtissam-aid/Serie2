using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp5
{
    internal class CompteBancaire
    {
        private int no_compte;
        private string nom_client;
        private string prenom_client;
        private double solde;
        public List<string> Historique;
        public CompteBancaire(int no_compte = 0, string nom = "", string prenom = "", double solde = 0)
        {
            this.no_compte = no_compte;
            this.nom_client = nom;
            this.prenom_client = prenom;
            this.solde = solde;
            Historique = new List<string>();
        }
        public int No_compte
        {
            get { return no_compte; }
            set { no_compte = value; }
        }
        public string Nom_client
        {
            get { return nom_client; }
            set { nom_client = value; }
        }
        public string Prenom_client
        {
            get { return prenom_client; }
            set { prenom_client = value; }
        }
        public double Solde
        {
            get { return solde; }
            set { solde = value; }
        }
        public void Crediter(double mt)
        {
            Solde += mt;
            AjouterHistorique("Crédité de: " + mt);
        }
        public void Debiter(double mt)
        {
            Solde -= mt;
            AjouterHistorique("debite de: " + mt);
        }
        public void AjouterHistorique(string op)
        {
            Historique.Add("[" + DateTime.Now + "] " + op);
        }
        public void AfficherHistorique()
        {
            foreach (string op in Historique)
            {
                Console.WriteLine(op);
            }
        }

        public bool Transferer(CompteBancaire destinataire, double montant)
        {
            if (montant > Solde)
            {
                Console.WriteLine("Fonds insuffisants pour effectuer le transfert.");
                return false;
            }
            this.Debiter(montant);
            destinataire.Crediter(montant);
            AjouterHistorique("Transféré " + montant + " à " + destinataire.no_compte);
            destinataire.AjouterHistorique("Reçu " + montant + " de " + this.no_compte);
            return true;
        }
    }
}
