using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;
        #region Constructores
        /// <summary>
        /// Constructor que instancia el objeto inicializando su atributo en 0
        /// </summary>
        public Operando():this(0)
        {
        }
        /// <summary>
        /// Constructor que instancia el objeto asginandole el atributo segun parametro
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)          
        {
            this.numero = numero;
        }
        /// <summary>
        /// /// Constructor que instancia el objeto asginandole el atributo segun parametro
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }
        #endregion
        #region Propiedad
        /// <summary>
        /// Settea el valor en el atributo sólo si es un operador valido
        /// </summary>
        public string Numero
        {
            set
            {
                double numeroValidado = ValidarOperando(value);
                if (numeroValidado != 0)
                {
                    this.numero = numeroValidado;
                }
            }
        }
        #endregion
        #region Validaciones
        /// <summary>
        /// Comprueba que el string sea numerico
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Retorna el string como double si es numero,sino 0 si es NULL,empty o no es numero</returns>
        public double ValidarOperando(string strNumero)
        {
            double ret = 0;
            if (!String.IsNullOrEmpty(strNumero))
            {
                double.TryParse(strNumero, out ret);
            }
            return ret;
        }
        /// <summary>
        /// Valida que el string este compuesto unicamente por caracteres '0' o '1'
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Devuelve true si solo tiene 0 y 1. False si no</returns>
        private bool Esbinario(string binario)
        {
            bool ret = false;
            if (!String.IsNullOrEmpty(binario))
            {
                foreach (char item in binario)
                {
                    if(item != '0' && item != '1')
                    {                        
                       return ret;                        
                    }                    
                }
                ret = true;                
            }
            return ret;
        }
        #endregion
        #region Decimal>>>Binario & Binario>>>Decimal
        /// <summary>
        /// Convierte un número de entero a binario.
        /// </summary>
        /// <param name="decimalRecibido"></param>
        /// <returns>Devuelve el decimal convertido a binario en string o "Valor invalido" en caso que no pudo convertirlo</returns>
        public string DecimalBinario(double decimalRecibido)
        {
            StringBuilder auxStringBuilder = new StringBuilder();
            if (!double.IsNaN(decimalRecibido))
            {
                int absolutoDecimal = (int)Math.Abs(decimalRecibido);
                do
                {
                    if ((absolutoDecimal % 2) == 0)
                    {
                        auxStringBuilder.Insert(0, '0');
                    }
                    else
                    {
                        auxStringBuilder.Insert(0, '1');
                    }
                    absolutoDecimal = absolutoDecimal / 2;
                }while (absolutoDecimal > 0);
                return auxStringBuilder.ToString();
            }
            return "Valor invalido";
        }
        /// <summary>
        /// Convierte un número de entero a binario decimal absoluto.
        /// </summary>
        /// <param name="decimalRecibido"></param>
        /// <returns>Devuelve el decimal convertido a binario en string o "Valor invalido" en caso que no pudo convertirlo</returns>
        public string DecimalBinario(string decimalRecibido)
        {
            double absolutoDecimal;
            if (!String.IsNullOrEmpty(decimalRecibido))
            {                
                if(double.TryParse(decimalRecibido, out absolutoDecimal))
                {
                    return DecimalBinario(absolutoDecimal);
                }                
            }
            return "Valor invalido";
        }
            /// <summary>
            /// Convierte un número binario a entero decimal absoluto.
            /// </summary>
            /// <param name="binario"></param>
            /// <returns>Devuelve el binario convertido a decimal en string o "Valor invalido" en caso que no pudo convertirlo</returns>
        public string BinarioDecimal(string binario) 
        {                                            
            double auxDouble = 0;
            string auxString;
            double auxDigito;
            int auxEntero;
            if (!String.IsNullOrEmpty(binario) && Esbinario(binario))
            {
                double auxPotencias = binario.Length - 1; //las potencias q manejo                   
                foreach (char letra in binario)
                {
                        auxString = letra.ToString();
                        double.TryParse(auxString, out auxDigito);
                        auxDouble += (auxDigito * Math.Pow(2, auxPotencias));
                        auxPotencias--;
                }
                auxEntero = (int)Math.Abs(auxDouble);
                return auxEntero.ToString();
            }
            return "Valor invalido";
        }
        #endregion
        #region Sobrecargas -,+,*,/
        /// <summary>
        /// Realiza la resta entre dos operandos
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la resta</returns>
        public static double operator-(Operando n1,Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Realiza la suma entre dos operandos
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la suma</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Realiza la multiplicacion entre dos operandos
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la multiplicacion</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Realiza la division entre dos operandos.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la division, si el divisor es = 0, entonces retorna el min.value que permite un double</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }
        #endregion


    }
}
