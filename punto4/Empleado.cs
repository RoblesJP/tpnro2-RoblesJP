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
        private string direccion;
        private DateTime fechaDeNacimiento;
        private EstadoCivil estadoCivil;
        private int cantidadDeHijos;
        private DateTime fechaDeDivorcio;
        private DateTime fechaDeIngreso;
        private double sueldoBasico;
        private string tituloUniversitario;
        private string universidad;

        public string Apellido 
        { 
            get => apellido; 
            set => apellido =  
                value == "" ? 
                throw new ArgumentException("Se asigno una cadena de caracteres vacia como el valor del atrbit") 
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
        public string TituloUniversitario { get => tituloUniversitario; set => tituloUniversitario = value.Trim() == "" ? null : value; }
        public string Universidad 
        { 
            get => universidad;
            set
            {
                if (this.TituloUniversitario == null && value.Trim() != "")
                {
                    universidad = null;
                    throw new InvalidOperationException("Este empleado no tiene titulo universitario");
                } else
                {
                    universidad = value.Trim() == "" ? null : value;
                }
            }
        }

        public double Antiguedad()
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
            double antiguedad = this.Antiguedad();
            double adicional = antiguedad < 20 ? (antiguedad / 100) * this.SueldoBasico : (25 / 100) * this.SueldoBasico;
            double descuento = this.SueldoBasico * 0.15;
            return this.SueldoBasico + adicional - descuento; 
        }

        public bool TieneTituloUniversitario ()
        {
            if (this.TituloUniversitario == null)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}
