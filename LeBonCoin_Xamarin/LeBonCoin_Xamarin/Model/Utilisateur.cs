using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LeBonCoin_Xamarin.Model
{
    [Table ("Utilisateurs")]
    public class Utilisateur : INotifyPropertyChanged
    {

        // L'identifiant unique de l'utilisateur.
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

        // Le nom de l'utilisateur.
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

        // Le prénom de l'utilisateur.
        private string _prenom;
        [NotNull]
        [MaxLength(50)]
        public string Prenom {
            get
            {
                return _prenom;
            }
            set
            {
                this._prenom = value;
                OnPropertyChanged(nameof(Prenom));
            }
        }

        // Le login de l'utilisateur (pseudo utilisé pour s'identifier).
        private string _login;
        [NotNull]
        [MaxLength(20)]
        public string Login {
            get
            {
                return _login;
            }
            set
            {
                this._login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        // Le mot de passe de l'utilisateur.
        private string _motDePasse;
        [NotNull]
        public string MotDePasse {
            get
            {
                return _motDePasse;
            }
            set
            {
                this._motDePasse = value;
                OnPropertyChanged(nameof(MotDePasse));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
