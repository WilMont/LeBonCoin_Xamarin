using LeBonCoin_Xamarin.Interfaces;
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
        public ICommand ConnexionCommand { private set; get; }
        public UtilisateurDAL utilisateurDAL = new UtilisateurDAL();

        //Propriétés du formulaire de connexion
        #region Propriétés formulaire connexion

        private string _loginEntre;
        public string LoginEntre
        {
            get { return this._loginEntre; }
            set
            {
                if (this._loginEntre != value)
                {
                    this._loginEntre = value;
                }
            }
        }

        private string _motDePasseEntre;
        public string MotDePasseEntre
        {
            get { return this._motDePasseEntre; }
            set
            {
                if (this._motDePasseEntre != value)
                {
                    this._motDePasseEntre = value;
                }
            }
        }
        #endregion

        public ConnexionViewModel()
        {
            ConnexionCommand = new Command(ConnexionExecute, CanExecute);
        }

        private void ConnexionExecute() // Ce que la commande exécute.
        {


            try
            {
                if(utilisateurDAL.ConnexionUtilisateur(this.LoginEntre, this.MotDePasseEntre) == true)
                {
                    App.EstConnecte = true;
                }
            }
            catch (Exception e)
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
