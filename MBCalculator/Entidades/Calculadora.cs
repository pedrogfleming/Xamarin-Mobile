using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza la operacion entre los numeros segun corresponda
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna el resultado de la operacion</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case '+':
                    resultado = num1+num2;
                    break;
                case '-':
                    resultado = num1-num2;
                    break;
                case '/':
                    resultado = num1/num2;
                    break;
                case '*':
                    resultado = num1*num2;
                    break;
            }
            return resultado;
        }
        /// <summary>
        /// Valida que el operador sea valido.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Retorna el operador validado. En caso que no sea un operador valido,se asigna por default el '+'</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador.Equals('+') ||
                operador.Equals('-') ||
               operador.Equals('/') ||
               operador.Equals('*'))
            {
                return operador;
            }
            return '+';

        }
    }
}
