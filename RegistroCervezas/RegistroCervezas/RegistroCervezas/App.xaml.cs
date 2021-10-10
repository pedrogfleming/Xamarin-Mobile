using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistroCervezas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Le indico que se comporte como una pagina de navegacion
            MainPage = new NavigationPage(new MainPage());
        }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
