using LeBonCoin_Xamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LeBonCoin_Xamarin.ViewModel
{
    public class ListeAnnoncesViewModel
    {

        private ObservableCollection<Annonce> _listeToutesAnnonces;
        public ObservableCollection<Annonce> ListeToutesAnnonces
        {
            get { return this._listeToutesAnnonces; }
            set
            {
                if (this._listeToutesAnnonces != value)
                {
                    this._listeToutesAnnonces = value;
                }
            }
        }

        private ObservableCollection<Annonce> _listeCategories;
        public ObservableCollection<Annonce> ListeCategories
        {
            get { return this._listeCategories; }
            set
            {
                if (this._listeCategories != value)
                {
                    this._listeCategories = value;
                }
            }
        }

        public ListeAnnoncesViewModel()
        {

        }


    }
}
