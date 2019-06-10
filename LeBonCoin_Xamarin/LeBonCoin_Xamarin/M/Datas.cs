using System;
using System.Collections.Generic;
using System.Text;

namespace LeBonCoin_Xamarin.M
{
    class Datas
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
                //binding + condition pour cacher les annonces de l'utilisateur courant
                //je vais binder des annonces exemples je pense, genre 2 ou 3
            };
        }

        public List<Annonce> GetAnnonces()
        {
            return _listeAnnonces;
        }
    }
}
