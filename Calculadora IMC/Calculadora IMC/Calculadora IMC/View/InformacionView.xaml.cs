using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculadora_IMC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformacionView : ContentPage
    {
        public InformacionView()
        {
            InitializeComponent();
        }
        async void OnSave(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}