using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistroCervezas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CervazaPage : ContentPage
    {
        public CervazaPage()
        {
            InitializeComponent();
        }
        async void OnSave(object sender, EventArgs e)
        {
            //Me va a llenar automaticamente el objeto a partir del formulario
            CervezaViewModel cerveza = (CervezaViewModel)BindingContext;
            MainPage.cervezas.Add(cerveza);
            //Para regresar a la que lo invoco, se quita a si misma para que deje a la de atras
            await Navigation.PopAsync();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
        }
    }
}