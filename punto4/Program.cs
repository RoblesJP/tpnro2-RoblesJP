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
            Console.Write("Estado civil (0: Casado, 1: Divorciado): "); Empleado1.EstadoCivil = (EstadoCivil)Convert.ToInt32(Console.ReadLine());
                
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
            Console.Write("Titulo universitario (saltear si no tiene): "); Empleado1.TituloUniversitario = Console.ReadLine();
            try
            {
                Console.Write("Universidad: "); Empleado1.Universidad = Console.ReadLine();
            }
            catch (InvalidOperationException ex)
            {
                Logger.Error(ex);
            }
            
            MostrarEmpleado(Empleado1);
        }


        static void MostrarEmpleado(Empleado Empleado)
        {
            Console.WriteLine();
            Console.WriteLine("Apellido: {0}", Empleado.Apellido);
            Console.WriteLine("Nombre: {0}", Empleado.Nombre);
            Console.WriteLine("Fecha de nacimiento: {0}", Empleado.FechaDeNacimiento);
            Console.WriteLine("Edad: {0}", Empleado.Edad());
            Console.WriteLine("Direccion: {0}", Empleado.Direccion);
            Console.WriteLine("Estado civil: {0}", Empleado.EstadoCivil);
            Console.WriteLine("Cantidad de hijos: {0}", Empleado.CantidadDeHijos);
            if (Empleado.EstadoCivil == EstadoCivil.Divorciado)
            {
                Console.WriteLine("Fecha de divorcio: {0}", Empleado.FechaDeDivorcio);
            }
            Console.WriteLine("Fecha de ingreso: {0}", Empleado.FechaDeIngreso);
            Console.WriteLine("Sueldo Basico: ${0}", Empleado.SueldoBasico);
            Console.WriteLine("Salario: ${0}", Empleado.Salario());
            if (Empleado.TieneTituloUniversitario())
            {
                Console.WriteLine("Titulo universitario: ${0}", Empleado.TituloUniversitario);
                Console.WriteLine("Universidad: ${0}", Empleado.Universidad);
            }
            Console.WriteLine();
        }
    }

    
}
