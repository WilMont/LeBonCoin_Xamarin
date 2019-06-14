using LeBonCoin_Xamarin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeBonCoin_Xamarin.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageAnnonceView : ContentPage
	{

        public Annonce AnnonceSelectionnee { get; set; }

        public PageAnnonceView(Annonce annonce)
		{
			InitializeComponent ();

            AnnonceSelectionnee = annonce;
            this.BindingContext = AnnonceSelectionnee;

            var tapGestureRecognizer = new TapGestureRecognizer();


            string numeroT = nAppel.Text;

            tapGestureRecognizer.Tapped += (s, e) => {

                Device.OpenUri(new Uri("tel:" + numeroT));

            };

            nAppel.GestureRecognizers.Add(tapGestureRecognizer);
        }
	}
}