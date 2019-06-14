using LeBonCoin_Xamarin.Interfaces;
using LeBonCoin_Xamarin.Model;
using LeBonCoin_Xamarin.ViewModel.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LeBonCoin_Xamarin.ViewModel
{
    public class ListeAnnoncesViewModel :INotifyPropertyChanged
    {
        public ICommand CreationAnnonceCommand { private set; get; }
        AnnonceDAL annonceDAL = new AnnonceDAL();

        private ObservableCollection<Annonce> _listeToutesAnnonces; // La liste des annonces excluant celle de l'utilisateur courant.
        public ObservableCollection<Annonce> ListeToutesAnnonces
        {
            get { return this._listeToutesAnnonces; }
            set
            {
                if (this._listeToutesAnnonces != value)
                {
                    this._listeToutesAnnonces = value;
                    OnPropertyChanged(nameof(ListeToutesAnnonces));
                }
            }
        }

        private ObservableCollection<Annonce> _listeMesAnnonces; // La liste des annonces de l'utilisateur courant.
        public ObservableCollection<Annonce> ListeMesAnnonces
        {
            get { return this._listeMesAnnonces; }
            set
            {
                if (this._listeMesAnnonces != value)
                {
                    this._listeMesAnnonces = value;
                    OnPropertyChanged(nameof(ListeMesAnnonces));
                }
            }
        }

        // Propriétés pour la création d'une annonce.
        #region Création Annonce

        private string _titreEntre; // Le titre de l'annonce que l'utilisateur entre dans le champs correspondant.
        public string TitreEntre
        {
            get { return this._titreEntre; }
            set
            {
                if (this._titreEntre != value)
                {
                    this._titreEntre = value;
                    OnPropertyChanged(nameof(TitreEntre));
                }
            }
        }

        private string _descriptionEntre; // La description de l'annonce que l'utilisateur entre dans le champs correspondant.
        public string DescriptionEntre
        {
            get { return this._descriptionEntre; }
            set
            {
                if (this._descriptionEntre != value)
                {
                    this._descriptionEntre = value;
                    OnPropertyChanged(nameof(DescriptionEntre));
                }
            }
        }

        private decimal _prixEntre; // Le prix de l'objet vendu que l'utilisateur entre dans le champs correspondant.
        public decimal PrixEntre
        {
            get { return this._prixEntre; }
            set
            {
                if (this._prixEntre != value)
                {
                    this._prixEntre = value;
                    OnPropertyChanged(nameof(PrixEntre));
                }
            }
        }

        private string _telephoneEntre; // Le numéro de téléphone que l'utilisateur entre dans le champs correspondant.
        public string TelephoneEntre
        {
            get { return this._telephoneEntre; }
            set
            {
                if (this._telephoneEntre != value)
                {
                    this._telephoneEntre = value;
                    OnPropertyChanged(nameof(TelephoneEntre));
                }
            }
        }

        private string _categorieEntre; // La catégorie de l'objet vendu que l'utilisateur sélectionne.
        public string CategorieEntre
        {
            get { return this._categorieEntre; }
            set
            {
                if (this._categorieEntre != value)
                {
                    this._categorieEntre = value;
                    OnPropertyChanged(nameof(CategorieEntre));
                }
            }
        }

        // Commande pour la création de l'annonce.
        private void CreationAnnonceExecute() // Ce que la commande exécute.
        {


            try
            {
                Annonce annonce = new Annonce // On crée une nouvelle annonce avec les informations renseignées.
                {
                    Titre = this.TitreEntre,
                    Description = this.DescriptionEntre,
                    Prix = this.PrixEntre,
                    NumTel = this.TelephoneEntre,
                    Categorie = this.CategorieEntre,
                    AuteurId = UtilisateurDAL.utilisateurCourant.Id,
                };
                annonceDAL.SauvegarderAnnonce(annonce);
                DependencyService.Get<IMessage>().ShortAlert("L'annonce a été créée"); // Affichage d'un message de succès.
            }
            catch (Exception e)
            {
                DependencyService.Get<IMessage>().ShortAlert(e.Message); // Affichage de l'erreur.
                //DependencyService.Get<IMessage>().ShortAlert("Une erreur est survenue"); // Affichage d'un message d'erreur.
            }

        }

        private bool CanExecute() // Les conditions pour que la commande puisse s'exécuter.
        {
            return true;
        }

        #endregion


        public ListeAnnoncesViewModel()
        {
            ObservableCollection<Annonce> CollectionAnnoncesSaufUtilisateur = new ObservableCollection<Annonce>(annonceDAL.GetAnnoncesSaufUtilisateur());
            this.ListeToutesAnnonces = CollectionAnnoncesSaufUtilisateur;

            ObservableCollection<Annonce> CollectionAnnoncesUtilisateur = new ObservableCollection<Annonce>(annonceDAL.GetAnnoncesUtilisateur());
            this.ListeMesAnnonces = CollectionAnnoncesSaufUtilisateur;



            //annonceDAL.IEnumerableVersListeAnnonce(annonceDAL.GetAnnoncesSaufUtilisateur(), this.ListeToutesAnnonces);
            //annonceDAL.IEnumerableVersListeAnnonce(annonceDAL.GetAnnoncesUtilisateur(), this.ListeMesAnnonces);
            CreationAnnonceCommand = new Command(CreationAnnonceExecute, CanExecute);
            
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
