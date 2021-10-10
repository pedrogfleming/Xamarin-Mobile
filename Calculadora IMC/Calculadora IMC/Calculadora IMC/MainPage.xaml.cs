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
                    double imc = peso / (altura * altura);
                    entIMC.Text = imc.ToString();
                    string resultado = string.Empty;
                    if (imc < 18.5)
                    {
                        resultado = "Tienes bajo peso";
                    }
                    else if (imc >= 18.5 && imc <= 24.9)
                    {
                        resultado = "Tu peso es normal";
                    }
                    else if (imc >= 25 && imc <= 29.9)
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
    }
}
