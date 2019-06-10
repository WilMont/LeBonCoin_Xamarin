using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LeBonCoin_Xamarin.Model
{
    [Table("Categories")]
    public class Categorie :INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        // Le nom de la catégorie.
        private string _nom;
        [NotNull]
        [MaxLength(50)]
        public string Nom
        {
            get
            {
                return _nom;
            }
            set
            {
                this._nom = value;
                OnPropertyChanged(nameof(Nom));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
