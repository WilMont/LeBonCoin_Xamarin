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
	public partial class ConnexionView : ContentPage
	{
		public ConnexionView ()
		{
			InitializeComponent();
		}

        private void Btn_PageInscription(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InscriptionView());
        }

        private void Btn_PageAnnonces(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageOngletsPrincipauxView());
        }
    }
}