using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LeBonCoin_Xamarin.ViewModel
{
    public class UtilisateurViewModel
    {
        public ICommand ConnexionCommand { private set; get; }

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

        public UtilisateurViewModel()
        {

            ConnexionCommand = new Command(
            execute: () =>
            {


                //IsEditing = true;
                RefreshCanExecutes();
            },
            canExecute: () =>
            {
                if (string.IsNullOrEmpty(LoginEntre) || string.IsNullOrEmpty(MotDePasseEntre))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            });

            void RefreshCanExecutes()
            {
                (ConnexionCommand as Command).ChangeCanExecute();
            }


        }
    }
}
