using LeBonCoin_Xamarin.Model;
using LeBonCoin_Xamarin.View;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LeBonCoin_Xamarin
{
    public partial class App : Application
    {
        public static bool EstConnecte { get; set; }
        public static Utilisateur UtilisateurCourant { get; set; }

        public App()
        {
            InitializeComponent();

            if (!EstConnecte || UtilisateurCourant==null)
            {
                MainPage = new NavigationPage(new ConnexionView());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }

            //SET PRIMARY TOOLBAR COLOR
            Current.Resources = new ResourceDictionary();
            Color xamarin_color = Color.FromHex("#E86528");
            var navigationStyle = new Style(typeof(NavigationPage));
            var barBackgroundColorSetter = new Setter { Property = NavigationPage.BarBackgroundColorProperty, Value = xamarin_color };
            navigationStyle.Setters.Add(barBackgroundColorSetter);
            Current.Resources.Add(navigationStyle);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
