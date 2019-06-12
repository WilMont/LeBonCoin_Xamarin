using LeBonCoin_Xamarin.ViewModel.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LeBonCoin_Xamarin.ViewModel
{
    public class UtilisateurViewModel : INotifyPropertyChanged
    {

        public UtilisateurDAL utilisateurDAL = new UtilisateurDAL();

        public UtilisateurViewModel()
        {

            


        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
