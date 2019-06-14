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
    public class CategorieDAL
    {

        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Categorie> Categories { get; set; }

        public CategorieDAL()
        {
            database =
              DependencyService.Get<IDatabaseConnection>().
              DbConnection();
            database.CreateTable<Categorie>();

            this.Categories =
              new ObservableCollection<Categorie>(database.Table<Categorie>());
        }

        public IEnumerable<Categorie> GetCategories()
        {
            lock (collisionLock)
            {
                var query = from categorie in database.Table<Categorie>()
                            select categorie;
                return query.AsEnumerable();
            }
        }

        public void IEnumerableVersListeCategorie(IEnumerable<Categorie> collection, ObservableCollection<Categorie> collectionARemplir)
        {
            if (collection != null)
            {
                using (IEnumerator<Categorie> enumerator = collection.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        collectionARemplir.Add(enumerator.Current);
                    }
                }
            }
        }

        public int SauvegarderCategorie(Categorie categorieInstance)
        {
            lock (collisionLock)
            {
                if (categorieInstance.Id != 0)
                {
                    database.Update(categorieInstance);
                    return categorieInstance.Id;
                }
                else
                {
                    database.Insert(categorieInstance);
                    return categorieInstance.Id;
                }
            }
        }

    }
}
