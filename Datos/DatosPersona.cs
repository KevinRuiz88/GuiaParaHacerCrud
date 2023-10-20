using Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosPersona
    {

        string fileName = "Personas.txt";

        public string Guardar(Persona persona)
        {

            var escritor = new StreamWriter(fileName, true);
            escritor.WriteLine(persona.ToString());
            escritor.Close();

            return $"{persona.Nombre} Fue guardad@ correctamente";
        }

        public string Guardar(List<Persona> personas)
        {

            var escritor = new StreamWriter(fileName);
            foreach (var item in personas)
            {
                escritor.WriteLine(item.ToString());
            }
            escritor.Close();
            return $"archivo actualizado";
        }

        public List<Persona> MostrarTodos()
        {
            var listaPersonas = new List<Persona>();
            try
            {
                StreamReader lector = new StreamReader(fileName);
                while (!lector.EndOfStream)
                {
                    listaPersonas.Add(Map(lector.ReadLine()));
                }
                lector.Close();
                return listaPersonas;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Persona Map(string linea)
        {
            var p = new Persona();
            p.Cedula = int.Parse(linea.Split(',')[0]);
            p.Nombre = linea.Split(',')[1];
            p.Apellido = linea.Split(',')[2];
            p.Edad = int.Parse(linea.Split(',')[3]);
            p.Sexo = linea.Split(',')[4];
            //p.Pulsaciones = decimal.Parse(linea.Split(';')[5]);

            return p;
        }

        public string ActualizarLista(List<Persona> personaList)
        {
            var escritor = new StreamWriter(fileName);

            foreach (var item in personaList)
            {
                escritor.WriteLine(item.ToString());
            }
            escritor.Close();
            return "Lista Actualizada";
        }

    }
}
