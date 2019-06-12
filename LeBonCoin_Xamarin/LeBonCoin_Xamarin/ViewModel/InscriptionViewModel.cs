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

        // Nom que l'utilisateur rentre dans le champs correspondant.
        private string _nomEntre;
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

        // Prénom que l'utilisateur rentre dans le champs correspondant.
        private string _prenomEntre;
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

        // Login que l'utilisateur rentre dans le champs correspondant.
        private string _loginEntre;
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

        // Mot de passe que l'utilisateur rentre dans le champs correspondant.
        private string _motDePasseEntre;
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

        // Confirmation du mot de passe entré.
        private string _motDePasseEntreConfirmation;
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
        #endregion

        public InscriptionViewModel()
        {
            InscriptionCommand = new Command(InscriptionExecute, CanExecute);
        }

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
            catch(Exception e)
            {
                DependencyService.Get<IMessage>().ShortAlert(e.Message);
                DependencyService.Get<IMessage>().ShortAlert("Une erreur est survenue"); // Affichage d'un message d'erreur.
            }
            
            }

            private bool CanExecute() // Les conditions pour que la commande puisse s'exécuter.
            {
            return true;
            }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
