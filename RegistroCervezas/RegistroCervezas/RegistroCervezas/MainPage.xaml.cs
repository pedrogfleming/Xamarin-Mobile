using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RegistroCervezas
{
    public partial class MainPage : ContentPage
    {
        public static List<CervezaViewModel> cervezas;
        static MainPage()
        {
            MainPage.cervezas = new List<CervezaViewModel>()
            {
                new CervezaViewModel("Minerva Verde","Minerva","Stout"),
                new CervezaViewModel("Ticus","Colima","Porter"),
            };
        }            
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = cervezas;
            //Para que se pueda actualizar el nuevo elemento
            listView.ItemsSource = null;
            listView.ItemsSource = cervezas;
        }
        async void OnNew(object sender,EventArgs e)
        {
            //Creo una nueva vista y la sumo a la cola
            await Navigation.PushAsync(new Views.CervazaPage
            {
                BindingContext = new CervezaViewModel()
            }); 
        }
    } 
}
