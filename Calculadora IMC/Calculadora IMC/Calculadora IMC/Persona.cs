using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora_IMC
{
    public class Persona
    {
        private double altura;
        private double peso;
        private double imc;

        public Persona(double altura, double peso)
        {
            this.Altura = altura;
            this.Peso = peso;
            this.Imc = calcularImc();
        }
        #region Propiedades
        public double Altura
        {
            get { return this.altura; }
            set 
            { 
                if(value > 0 && value < 400)
                {
                    this.altura = value;
                } 
            }
        }
        public double Peso
        {
            get { return this.peso; }
            set
            {
                if (value > 0 && value < 3)
                {
                    this.peso = value;
                }
            }
        }
        public double Imc
        {
            get { return this.imc; }
            set
            {
                this.imc = value;
            }
        }
        #endregion}
        
        private double calcularImc()
        {
            if ((this.Altura > 0) && this.Peso > 0)
            {
                return this.Peso / (this.Altura * this.Altura);
            }
            return 0;
        }

    }
}
