using LeBonCoin_Xamarin.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace LeBonCoin_Xamarin.ViewModel.DAL
{
    public class AnnonceDAL
    {

        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Annonce> Annonces { get; set; }


        public AnnonceDAL()
        {
            database =
              DependencyService.Get<IDatabaseConnection>().
              DbConnection();
            database.CreateTable<Annonce>();

            this.Annonces =
              new ObservableCollection<Annonce>(database.Table<Annonce>());

            /*if (!database.Table<Annonce>().Any())
            {
                AddNewAnnonce();
            }*/

        }

        public void AddNewAnnonce()
        {
            this.Annonces.Add(new Annonce
            {
                Titre = "Peugeot 206 grise",
                Description = "20 000km, très bon état",
                Prix = Convert.ToDecimal(2500),
                NumTel = "0631985297",
                Categorie = "Véhicules",
                AuteurId = 1,
            });
        }

        public IEnumerable<Annonce> GetAnnonces()
        {
            lock (collisionLock)
            {
                var query = from annonce in database.Table<Annonce>()
                            select annonce;
                return query.AsEnumerable();
            }
        }

        /*public IEnumerable<Annonce> GetAnnoncesSaufUtilisateur()
        {
            lock (collisionLock)
            {
                var query = from annonce in database.Table<Annonce>()
                            where annonce.AuteurId != 
                            select annonce;
                return query.AsEnumerable();
            }
        }*/

        public IEnumerable<Annonce> GetAnnoncesSaufUtilisateur()
        {
            lock (collisionLock)
            {
                var query = from annonce in database.Table<Annonce>()
                            where (annonce.AuteurId != 0)
                            select annonce;
                return query.AsEnumerable();
            }
        }

        /*public IEnumerable<Annonce> GetAnnoncesUtilisateur()
        {
            lock (collisionLock)
            {
                var query = from annonce in database.Table<Annonce>()
                            where annonce.AuteurId == this.idUtilisateur
                            select annonce;
                return query.AsEnumerable();
            }
        }*/

        public IEnumerable<Annonce> GetAnnoncesUtilisateur()
        {
            lock (collisionLock)
            {
                var query = from annonce in database.Table<Annonce>()
                            where (annonce.AuteurId == 0)
                            select annonce;
                return query.AsEnumerable();
            }
        }

        public IEnumerable<Annonce> GetAnnoncesResultatRecherche(string recherche)
        {
            lock (collisionLock)
            {
                var query = from annonce in database.Table<Annonce>()
                            where (annonce.Titre.Contains(recherche))
                            select annonce;
                return query.AsEnumerable();
            }
        }

        public int SauvegarderAnnonce(Annonce annonceInstance)
        {
            lock (collisionLock)
            {
                if (annonceInstance == GetAnnonces())
                {
                    database.Update(annonceInstance);
                    return annonceInstance.Id;
                }
                else
                {
                    database.Insert(annonceInstance);
                    return annonceInstance.Id;
                }
            }
        }

        public void IEnumerableVersListeAnnonce(IEnumerable<Annonce> collection, ObservableCollection<Annonce> collectionARemplir)
        {
            if (collection != null)
            {
                using (IEnumerator<Annonce> enumerator = collection.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        collectionARemplir.Add(enumerator.Current);
                    }
                }
            }
        }


    }
}
