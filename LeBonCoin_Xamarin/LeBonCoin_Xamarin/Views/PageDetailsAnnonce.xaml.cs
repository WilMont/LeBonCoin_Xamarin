using System;
using LeBonCoin_Xamarin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace LeBonCoin_Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDetailsAnnonce : ContentPage
    {
        public Annonce AnnonceDisplayed { get; set; }

        public PageDetailsAnnonce(Annonce annonce)
        {
            InitializeComponent();

            AnnonceDisplayed = annonce;

            this.BindingContext = AnnonceDisplayed;

            var tapGestureRecognizer = new TapGestureRecognizer();

            
            string numeroT = nAppel.Text;

            tapGestureRecognizer.Tapped += (s, e) => {

                Device.OpenUri(new Uri("tel:"+ numeroT));

            };

            nAppel.GestureRecognizers.Add(tapGestureRecognizer);
        }


    }

}
