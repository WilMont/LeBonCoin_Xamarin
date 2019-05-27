using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeBonCoin_Xamarin.Model
{
    public class Annonce
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Titre { get; set; }

        public string Description { get; set; }

        public decimal Prix { get; set; }

        public string NumTel { get; set; }

        public Categorie Categorie { get; set; }
    }
}
