using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeBonCoin_Xamarin.Model
{
    public class Categorie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nom { get; set; }
    }
}
