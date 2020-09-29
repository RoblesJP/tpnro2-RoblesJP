using System;
using System.Collections.Generic;
using System.Text;

namespace punto4
{
    public enum EstadoCivil
    {
        Casado,
        Divorciado,
    }
    class Empleado
    {
        private string apellido;
        private string nombre;
        private DateTime fechaDeNacimiento;
        private string direccion;
        private DateTime fechaDeIngreso;
        private EstadoCivil estadoCivil;
        private int cantidadDeHijos;
        private DateTime fechaDeDivorcio;
        private double sueldoBasico;

        public string Apellido 
        { 
            get => apellido; 
            set => apellido =  
                value == "" ? 
                throw new ArgumentException("Se asigno una cadena de caracteres vacia como apellido del empleado") 
                : 
                value; 
        }

        public string Nombre 
        { 
            get => nombre; 
            set => nombre = 
                value == "" ?
                throw new ArgumentException("Se asigno una cadena de caracteres vacia como apellido del empleado")
                :
                value; 
        }

        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }

        public string Direccion 
        { 
            get => direccion; 
            set => direccion = 
                value == "" ?
                throw new ArgumentException("Se asigno una cadena de caracteres vacia como la direccion del empleado")
                :
                value;
        }

        public DateTime FechaDeIngreso { get => fechaDeIngreso; set => fechaDeIngreso = value; }
        public EstadoCivil EstadoCivil { get => estadoCivil; set => estadoCivil = value; }
        public int CantidadDeHijos { get => cantidadDeHijos; set => cantidadDeHijos = value; }
        public DateTime FechaDeDivorcio 
        { 
            get => fechaDeDivorcio;
            set => fechaDeDivorcio = 
                this.EstadoCivil == EstadoCivil.Divorciado ? 
                value 
                : 
                throw new InvalidOperationException("Este empleado no esta divorciado"); 
        }
        public double SueldoBasico { get => sueldoBasico; set => sueldoBasico = value; }

        public int Antiguedad()
        {
            DateTime FechaActual = DateTime.Now;
            DateTime FechaZero = new DateTime(1, 1, 1);
            double DiasDeAntiguedad = FechaActual.Subtract(FechaDeIngreso).TotalDays;
            return FechaZero.AddDays(DiasDeAntiguedad).Year - 1;
        }

        public int Edad()
        {
            DateTime FechaActual = DateTime.Now;
            DateTime FechaZero = new DateTime(1, 1, 1);
            double DiasDeAntiguedad = FechaActual.Subtract(FechaDeNacimiento).TotalDays;
            return FechaZero.AddDays(DiasDeAntiguedad).Year - 1;
        }

        public double Salario()
        {
            int antiguedad = this.Antiguedad();
            double adicional = antiguedad < 20 ? (antiguedad / 100) * this.SueldoBasico : (25 / 100) * this.SueldoBasico;
            double descuento = this.SueldoBasico * 0.15;
            return this.SueldoBasico + adicional - descuento; 
        }

        public void MostrarEmpleado()
        {
            Console.WriteLine();
            Console.WriteLine("Apellido: {0}", this.Apellido);
            Console.WriteLine("Nombre: {0}", this.Nombre);
            Console.WriteLine("Fecha de nacimiento: {0}", this.FechaDeNacimiento);
            Console.WriteLine("Edad: {0}", this.Edad());
            Console.WriteLine("Direccion: {0}", this.Direccion);
            Console.WriteLine("Fecha de ingreso: {0}", this.FechaDeIngreso);
            Console.WriteLine("Estado civil: {0}", this.EstadoCivil);
            Console.WriteLine("Apellido: {0}", this.Apellido);
            Console.WriteLine("Cantidad de hijos: {0}", this.CantidadDeHijos);
            if (this.EstadoCivil == EstadoCivil.Divorciado)
            {
                Console.WriteLine("EstadoCivil: {0}", this.EstadoCivil);
            }
            Console.WriteLine("Sueldo Basico: ${0}", this.SueldoBasico);
            Console.WriteLine("Salario: ${0}", this.Salario());
            Console.WriteLine();
        }
        
    }
}
