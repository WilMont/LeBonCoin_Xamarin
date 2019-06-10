using LeBonCoin_Xamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace LeBonCoin_Xamarin.ViewModel.DAL
{
    public class UtilisateurDAL
    {

        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Utilisateur> Utilisateurs { get; set; }

        public UtilisateurDAL()
        {
            database =
              DependencyService.Get<IDatabaseConnection>().
              DbConnection();
            database.CreateTable<Utilisateur>();

            this.Utilisateurs =
              new ObservableCollection<Utilisateur>(database.Table<Utilisateur>());
        }

        public IEnumerable<Utilisateur> GetUtilisateurs()
        {
            lock (collisionLock)
            {
                var query = from utilisateur in database.Table<Utilisateur>()
                            select utilisateur;
                return query.AsEnumerable();
            }
        }

        public Utilisateur GetUtilisateur(int id)
        {
            lock (collisionLock)
            {
                return this.database.Table<Utilisateur>().FirstOrDefault(Utilisateur => Utilisateur.Id == id);
            }
        }

        public int SauvegarderUtilisateur(Utilisateur utilisateurInstance)
        {
            lock (collisionLock)
            {
                if (utilisateurInstance.Id != 0)
                {
                    database.Update(utilisateurInstance);
                    return utilisateurInstance.Id;
                }
                else
                {
                    database.Insert(utilisateurInstance);
                    return utilisateurInstance.Id;
                }
            }
        }

        public int SupprimerUtilisateur(Utilisateur utilisateurInstance)
        {
            var id = utilisateurInstance.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Utilisateur>(id);
                }
            }
            this.Utilisateurs.Remove(utilisateurInstance);
            return id;
        }

    }
}
