using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LeBonCoin_Xamarin.Model
{
    [Table("Annonces")]
    public class Annonce : INotifyPropertyChanged
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
        private string _titre;
        [NotNull]
        [MaxLength(50)]
        public string Titre
        {
            get
            {
                return _titre;
            }
            set
            {
                this._titre = value;
                OnPropertyChanged(nameof(Titre));
            }
        }

        // Le nom de la catégorie.
        private string _description;
        [NotNull]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                this._description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        // Le nom de la catégorie.
        private decimal _prix;
        [NotNull]
        public decimal Prix
        {
            get
            {
                return _prix;
            }
            set
            {
                this._prix = value;
                OnPropertyChanged(nameof(Prix));
            }
        }

        // Le nom de la catégorie.
        private string _numTel;
        [NotNull]
        [MaxLength(20)]
        public string NumTel
        {
            get
            {
                return _numTel;
            }
            set
            {
                this._numTel = value;
                OnPropertyChanged(nameof(NumTel));
            }
        }

        // Le nom de la catégorie.
        private Categorie _categorie;
        [NotNull]
        public Categorie Categorie
        {
            get
            {
                return _categorie;
            }
            set
            {
                this._categorie = value;
                OnPropertyChanged(nameof(Categorie));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
