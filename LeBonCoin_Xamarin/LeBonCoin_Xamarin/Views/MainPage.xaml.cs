using LeBonCoin_Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LeBonCoin_Xamarin.Views
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

                listeAnnonces.ItemsSource = Datas.GetInstance().GetListeAnnonces();

                

                //sert pour la barre de recherche

                SearchAnnonceList.ItemsSource = _categories;

               //numéro cliquable

               //création de l'action "tap sur un élément"
               var tapGestureRecognizer = new TapGestureRecognizer();

               tapGestureRecognizer.Tapped += (s, e) => {
                   //la méthode qui ouvre la fonction téléphone
                   Device.OpenUri(new Uri("tel:0641091509"));
               };

               //liaison de l'action et du label
               NAppel.GestureRecognizers.Add(tapGestureRecognizer);

               
            

            }

            //click sur l'annonce
            private async void ListeAnnonces_ItemTapped(object sender, ItemTappedEventArgs e)
            {
                Annonce selectedAnnonce = this.listeAnnonces.SelectedItem as Annonce;
                await this.Navigation.PushAsync(new PageDetailsAnnonce(selectedAnnonce));

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
