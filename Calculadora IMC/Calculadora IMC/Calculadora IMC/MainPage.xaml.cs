using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculadora_IMC
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(entAltura.Text) && !string.IsNullOrEmpty(entPeso.Text))
                {                    
                    double altura = double.Parse(entAltura.Text);
                    double peso = double.Parse(entPeso.Text);                    
                    if (altura > 2.50 && peso > 400)
                    {
                        throw new System.ArgumentException();
                    }
                    Persona aux = new Persona(altura, peso);

                    double imc = peso / (altura * altura);
                    entIMC.Text = imc.ToString();
                    string resultado = string.Empty;
                    if (aux.Imc < 18.5)
                    {
                        resultado = "Tienes bajo peso";
                    }
                    else if (aux.Imc >= 18.5 && aux.Imc <= 24.9)
                    {
                        resultado = "Tu peso es normal";
                    }
                    else if (aux.Imc >= 25 && aux.Imc <= 29.9)
                    {
                        resultado = "Tienes sobrepeso";
                    }
                    else
                    {
                        resultado = "Tienes obesidad, ¡cuídate!";
                    }
                    DisplayAlert("Resultado", resultado, "OK");
                }       
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (System.FormatException)
            {
                DisplayAlert("Error de input", "Ingrese sólo numeros", "OK");
            }
            catch(System.ArgumentNullException)
            {
                DisplayAlert("No se puede calcular", "Ingrese valores para poder calcular", "OK");
            }
            catch(ArgumentException)
            {
                DisplayAlert("Pasaron cosas...", "No se que paso aca...", "OK");
            }
        }

        private void OnNew(object sender, EventArgs e)
        {
            //Creo una nueva vista y la sumo a la cola
            //await Navigation.PushAsync(new View.InformacionView()            
            //{
            //    BindingContext = new ()
            //});
        }
    }
}
