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
        /// <summary>
        /// La funcion async va a esperar el await de adentro para ir a la nueva pagina y volver
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnNew(object sender,EventArgs e)
        {
            //Creo una nueva vista y la sumo a la cola
            //Push async va a esperar que se haga algo(en este caso crear un objeto de cerveza)
            // y una vez que lo haga, retorna algo
            //Lleva al usuario a la nueva pagina y espera a que el usuario vuelva de la otra pagina
            await Navigation.PushAsync(new Views.CervazaPage
            {
                BindingContext = new CervezaViewModel()
            }); 
        }
        /// <summary>
        /// Elimina el primer elemento de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRemove(object sender, EventArgs e)
        {            
            MainPage.cervezas.Remove(MainPage.cervezas.FirstOrDefault());
        }
    } 
}
