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

        public static Utilisateur utilisateurCourant = new Utilisateur();

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
                return database.Table<Utilisateur>().FirstOrDefault(Utilisateur => Utilisateur.Id == id);
            }
        }

        public int SauvegarderUtilisateur(Utilisateur utilisateurInstance)
        {
            lock (collisionLock)
            {
                if (utilisateurInstance == GetUtilisateurs())
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

        public bool ConnexionUtilisateur(string loginConnexion, string motDePasseConnexion)
        {
            bool condition = false;
            lock (collisionLock)
            {
                foreach(var utilisateurInstance in this.Utilisateurs)
                {
                    if (utilisateurInstance.Login.ToString() == loginConnexion.ToString() && utilisateurInstance.MotDePasse.ToString() == motDePasseConnexion.ToString())
                    {
                        utilisateurCourant = utilisateurInstance;
                        condition = true;
                        
                    }
                    else
                    {
                        condition = false;
                    }
                }
                return condition;
            }
        }

        public int GetIdUtilisateurCourant(string loginConnexion)
        {
            lock (collisionLock)
            {
                var query = (from utilisateur in database.Table<Utilisateur>()
                            where utilisateur.Login == loginConnexion
                            select utilisateur.Id).Take(1);
                return Convert.ToInt32(query.FirstOrDefault());
            }
        }

        public Utilisateur GetUtilisateurCourant(string loginConnexion)
        {
            lock (collisionLock)
            {
                var query = (from utilisateur in database.Table<Utilisateur>()
                             where utilisateur.Login == loginConnexion
                             select utilisateur).Take(1);
                return query.FirstOrDefault();
            }
        }

    }
}
