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
	public partial class MesAnnoncesView : ContentPage
	{
		public MesAnnoncesView ()
		{
			InitializeComponent ();
		}

        private void Btn_PageCreerAnnonce(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreerAnnonceView());
        }

    }
}