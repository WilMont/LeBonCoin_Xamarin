using LeBonCoin_Xamarin.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeBonCoin_Xamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeToutesAnnoncesView : ContentPage
    {

        public ListeToutesAnnoncesView()
        {
            InitializeComponent();
        }

        private void Btn_PageMesAnnonces(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MesAnnoncesView());
        }

        private async void ListeToutesAnnonces_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Annonce selectedAnnonce = this.ListeToutesAnnonces.SelectedItem as Annonce;
            await this.Navigation.PushAsync(new PageAnnonceView(selectedAnnonce));
        }

    }
}
