﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeBonCoin_Xamarin.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreerAnnonceView : ContentPage
	{
		public CreerAnnonceView ()
		{
			InitializeComponent ();
		}

        private void Btn_PageMesAnnonces(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MesAnnoncesView());
        }
    }
}