using LeBonCoin_Xamarin.Interfaces;
using LeBonCoin_Xamarin.Model;
using LeBonCoin_Xamarin.ViewModel.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LeBonCoin_Xamarin.ViewModel
{
    public class InscriptionViewModel: INotifyPropertyChanged
    {
        public ICommand InscriptionCommand { set; get; }
        public UtilisateurDAL utilisateurDAL = new UtilisateurDAL();

        //Propriétés du formulaire de connexion.
        #region Propriétés formulaire connexion

        
        private string _nomEntre; // Nom que l'utilisateur rentre dans le champs correspondant.
        public string NomEntre
        {
            get
            {
                return _nomEntre;
            }
            set
            {
                if (this._nomEntre != value)
                {
                    this._nomEntre = value;
                    OnPropertyChanged(nameof(NomEntre));
                    
                }
            }
        }

        
        private string _prenomEntre; // Prénom que l'utilisateur rentre dans le champs correspondant.
        public string PrenomEntre
        {
            get
            {
                return _prenomEntre;
            }
            set
            {
                if (this._prenomEntre != value)
                {
                    this._prenomEntre = value;
                    OnPropertyChanged(nameof(PrenomEntre));
                }
            }
        }

        
        private string _loginEntre; // Login que l'utilisateur rentre dans le champs correspondant.
        public string LoginEntre
        {
            get
            {
                return _loginEntre;
            }
            set
            {
                if (this._loginEntre != value)
                {
                    this._loginEntre = value;
                    OnPropertyChanged(nameof(LoginEntre));
                }
            }
        }

        
        private string _motDePasseEntre; // Mot de passe que l'utilisateur rentre dans le champs correspondant.
        public string MotDePasseEntre
        {
            get
            {
                return _motDePasseEntre;
            }
            set
            {
                if (this._motDePasseEntre != value)
                {
                    this._motDePasseEntre = value;
                    OnPropertyChanged(nameof(MotDePasseEntre));
                }
            }
        }

        
        private string _motDePasseEntreConfirmation; // Confirmation du mot de passe entré.
        public string MotDePasseEntreConfirmation
        {
            get
            {
                return _motDePasseEntreConfirmation;
            }
            set
            {
                if (this._motDePasseEntreConfirmation != value)
                {
                    this._motDePasseEntreConfirmation = value;
                    OnPropertyChanged(nameof(MotDePasseEntreConfirmation));
                }
            }
        }

        // La commande pour s'inscrire.
        private void InscriptionExecute() // Ce que la commande exécute.
        {


            try
            {
                Utilisateur utilisateur = new Utilisateur // On crée un nouvel utilisateur avec les informations renseignées.
                {
                    Nom = this.NomEntre,
                    Prenom = this.PrenomEntre,
                    Login = this.LoginEntre,
                    MotDePasse = this.MotDePasseEntre
                };

                utilisateurDAL.SauvegarderUtilisateur(utilisateur); // On insère cet utilisateur dans la table correspondante.
                DependencyService.Get<IMessage>().ShortAlert("Inscription réussie"); // Affichage d'un message de succès.
            }
            catch (Exception e)
            {
                //DependencyService.Get<IMessage>().ShortAlert(e.Message); // Affichage de l'erreur.
                DependencyService.Get<IMessage>().ShortAlert("Une erreur est survenue"); // Affichage d'un message d'erreur.
            }

        }

        private bool CanExecute() // Les conditions pour que la commande puisse s'exécuter.
        {
            return true;
        }

        #endregion

        public InscriptionViewModel()
        {
            InscriptionCommand = new Command(InscriptionExecute, CanExecute);
        }




        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
