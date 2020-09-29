using System;
using NLog;
using NLog.Extensions.Logging;

namespace punto1
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            

            // ################ PROBLEMA 1 #################
            int? num = null;

            Console.WriteLine("CALCULAR EL CUADRADO DE UN NUMERO");
            do
            {
                Console.Write("Ingrese un numero entero: ");
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    num = null;
                    Logger.Error(ex);
                    continue;
                }
            } while (num == null);

            Console.WriteLine(">> El cuadrado de {0} es: {1}", num, num*num);

            // ################ PROBLEMA 2 #################

            int? numerador = null;
            int? denominador = null;
            int? resultado = null;
             
            Console.WriteLine("\nCALCULAR EL COCIENTE ENTRE DOS NUMEROS");
            do
            {
                
                try
                {
                    Console.Write("Ingrese el numerador: ");
                    numerador = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Ingrese el denominador: ");
                    denominador = Convert.ToInt32(Console.ReadLine());
                    resultado = numerador / denominador;
                }
                catch (Exception ex)
                {
                    if (ex is FormatException || ex is DivideByZeroException)
                    {
                        numerador = null;
                        denominador = null;
                        Logger.Error(ex);
                        continue;
                    }
                }
            } while (numerador == null || denominador == null);

            Console.WriteLine(">> El resultado de {0}/{1} es {2}", numerador, denominador, resultado);
        }
    }
}
