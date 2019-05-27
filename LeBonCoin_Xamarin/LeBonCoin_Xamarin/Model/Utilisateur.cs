using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeBonCoin_Xamarin.Model
{
    public class Utilisateur
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Login { get; set; }

        public string MotDePasse { get; set; }
    }
}
