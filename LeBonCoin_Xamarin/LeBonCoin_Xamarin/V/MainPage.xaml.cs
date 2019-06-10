using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LeBonCoin_Xamarin
{
    public partial class MainPage : ContentPage
    {
       
        
            //liste donnée à la listeview
            List<string> _categories = new List<string>
            {
                "Consoles & Jeux vidéo", "Immobilier", "Electroménager", "Sport", "Véhicules"
            };

            
            //lien avec la barre de recherche
            public MainPage()
            {
                InitializeComponent();

                SearchAnnonceList.ItemsSource = _categories;

            }

            //la recherche retourne le terme correspondant de la viewlist, en ajoutant du binding on doit pouvoir afficher des annonces à la place de juste un mot
            private void SearchAnnonce_OnSearchButtonPressed(object sender, EventArgs e)
            {
                string keyword = SearchAnnonce.Text;

                IEnumerable<string> searchResult = _categories.Where(categorie => categorie.ToLower().Contains(keyword.ToLower()));

                SearchAnnonceList.ItemsSource = searchResult;
            }
        
    }
}
