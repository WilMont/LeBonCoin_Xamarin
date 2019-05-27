using LeBonCoin_Xamarin.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeBonCoin_Xamarin
{
    public class LeBonCoinDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public LeBonCoinDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Utilisateur>().Wait();
            _database.CreateTableAsync<Categorie>().Wait();
            _database.CreateTableAsync<Annonce>().Wait();
        }

        //Fonctions table [Utilisateur] -----------------------------------------------

        public Task<List<Utilisateur>> GetUtilisateurAsync()
        {
            return _database.Table<Utilisateur>().ToListAsync();
        }

        public Task<Utilisateur> GetUtilisateursAsync(int id)
        {
            return _database.Table<Utilisateur>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveUtilisateurAsync(Utilisateur utilisateur)
        {
            if (utilisateur.Id != 0)
            {
                return _database.UpdateAsync(utilisateur);
            }
            else
            {
                return _database.InsertAsync(utilisateur);
            }
        }

        public Task<int> DeleteNoteAsync(Utilisateur utilisateur)
        {
            return _database.DeleteAsync(utilisateur);
        }

        //Fonctions table [Categorie] -----------------------------------------------

        public Task<List<Categorie>> GetCategorieAsync()
        {
            return _database.Table<Categorie>().ToListAsync();
        }

        public Task<Categorie> GetCategoriesAsync(int id)
        {
            return _database.Table<Categorie>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCategorieAsync(Categorie categorie)
        {
            if (categorie.Id != 0)
            {
                return _database.UpdateAsync(categorie);
            }
            else
            {
                return _database.InsertAsync(categorie);
            }
        }

        public Task<int> DeleteCategorieAsync(Categorie categorie)
        {
            return _database.DeleteAsync(categorie);
        }

        //Fonctions table [Annonce] -----------------------------------------------

        public Task<List<Annonce>> GetAnnonceAsync()
        {
            return _database.Table<Annonce>().ToListAsync();
        }

        public Task<Annonce> GetAnnoncesAsync(int id)
        {
            return _database.Table<Annonce>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveAnnonceAsync(Annonce annonce)
        {
            if (annonce.Id != 0)
            {
                return _database.UpdateAsync(annonce);
            }
            else
            {
                return _database.InsertAsync(annonce);
            }
        }

        public Task<int> DeleteAnnonceAsync(Annonce annonce)
        {
            return _database.DeleteAsync(annonce);
        }

    }
}
