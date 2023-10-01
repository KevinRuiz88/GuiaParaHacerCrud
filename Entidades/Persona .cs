using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        public Persona()
        {
        }
        public Persona(int cedula, string nombre, string apellido, int edad, string sexo, decimal pulsaciones )
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Sexo = sexo;
            Pulsaciones = pulsaciones;
        }
        public override string ToString()
        {
            return $"{Cedula},{ Nombre},{ Apellido},{ Edad},{Sexo},{Pulsaciones}";
        }
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Sexo  { get; set; }
        public decimal Pulsaciones { get; set; }

    }
}
