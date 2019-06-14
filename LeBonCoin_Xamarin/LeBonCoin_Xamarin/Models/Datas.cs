using System;
using System.Collections.Generic;
using System.Text;


namespace LeBonCoin_Xamarin.Models
{
    public class Datas
    {
        #region Singleton

        private static Datas _instance { get; set; }
        public static Datas GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Datas();
            }
            return _instance;
        }

        #endregion

        private List<Annonce> _listeAnnonces { get; set; }

        private Datas()
        {
            _listeAnnonces = new List<Annonce>
            {

                new Annonce
                {
                    IdA = "id01",
                    Titre = "annonce test",
                    Description = "bla bla bla",
                    Prix = 15.5f,
                    NumeroT = "0641091509",
                    Categorie = "Immobilier"
            
                }
                //binding + condition pour cacher les annonces de l'utilisateur courant
                //je vais binder des annonces exemples je pense, genre 2 ou 3
            };
        }

        public List<Annonce> GetListeAnnonces()
        {
            return _listeAnnonces;
        }
    }
}
