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

        //Propriétés du formulaire de connexion
        #region Propriétés formulaire connexion

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

            private void InscriptionExecute()
            {
                Utilisateur utilisateur = new Utilisateur {
                    Nom = NomEntre,
                    Prenom = PrenomEntre,
                    Login = LoginEntre,
                    MotDePasse = MotDePasseEntre
                };
                UtilisateurDAL.SaveCustomer(utilisateur);
            }

            private bool CanExecute()
            {
                if (string.IsNullOrEmpty(NomEntre) || string.IsNullOrEmpty(PrenomEntre) || string.IsNullOrEmpty(LoginEntre) || string.IsNullOrEmpty(MotDePasseEntre) || (MotDePasseEntre != MotDePasseEntreConfirmation) )
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
