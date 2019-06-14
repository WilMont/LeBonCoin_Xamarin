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
    public class ConnexionViewModel : INotifyPropertyChanged
    {
        public ICommand ConnexionCommand { set; get; }
        public UtilisateurDAL utilisateurDAL = new UtilisateurDAL();

        //Propriétés du formulaire de connexion
        #region Propriétés formulaire connexion

        private string _loginEntre; // Le login que l'utilisateur entre dans le champs correspondant.
        public string LoginEntre
        {
            get { return this._loginEntre; }
            set
            {
                if (this._loginEntre != value)
                {
                    this._loginEntre = value;
                    OnPropertyChanged(nameof(LoginEntre));
                }
            }
        }

        private string _motDePasseEntre; // Le mot de passe que l'utilisateur entre dans le champs correspondant.
        public string MotDePasseEntre
        {
            get { return this._motDePasseEntre; }
            set
            {
                if (this._motDePasseEntre != value)
                {
                    this._motDePasseEntre = value;
                    OnPropertyChanged(nameof(MotDePasseEntre));
                }
            }
        }


        // Commande pour la connexion.
        private void ConnexionExecute() // Ce que la commande exécute.
        {


            try
            {
                if (utilisateurDAL.ConnexionUtilisateur(LoginEntre,MotDePasseEntre) == true)
                {
                    App.EstConnecte = true;
                    UtilisateurDAL.utilisateurCourant = utilisateurDAL.GetUtilisateurCourant(LoginEntre);
                }
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

        public ConnexionViewModel()
        {
            ConnexionCommand = new Command(ConnexionExecute, CanExecute);
            utilisateurDAL.GetUtilisateurs();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}
