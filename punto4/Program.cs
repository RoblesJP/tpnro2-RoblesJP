using NLog;
using punto4;
using System;

namespace punto2
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {

            Empleado Empleado1 = new Empleado();
            
            
            Console.WriteLine("INGRESE LOS DATOS DEL EMPLEADO");
            try
            {
                Console.Write("Apellido: "); Empleado1.Apellido = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Logger.Warn(ex);
            }

            try
            {
                Console.Write("Nombre: "); Empleado1.Nombre = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Logger.Warn(ex);
            }

            try
            {
                Console.Write("Direccion: "); Empleado1.Direccion = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Logger.Warn(ex);
            }

            Console.Write("Fecha de ingreso: "); Empleado1.FechaDeIngreso = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Fecha de nacimiento: "); Empleado1.FechaDeNacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Estado civil: "); Empleado1.EstadoCivil = (EstadoCivil)Convert.ToInt32(Console.ReadLine());
                
            try
            {
                Console.Write("Fecha de divorcio: "); Empleado1.FechaDeDivorcio = Convert.ToDateTime(Console.ReadLine());
            } 
            catch (InvalidOperationException ex)
            {
                Logger.Error(ex);
            }

            Console.Write("Sueldo basico: "); Empleado1.SueldoBasico = Convert.ToDouble(Console.ReadLine());
            Console.Write("Cantidad de hijos: "); Empleado1.CantidadDeHijos = Convert.ToInt32(Console.ReadLine());
            Empleado1.MostrarEmpleado();
        }
    }
}
