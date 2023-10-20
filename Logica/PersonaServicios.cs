using Datos;
using Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PersonaServicios
    {
        DatosPersona datosPersona = null;
        private List<Persona> personaList = null;
        public PersonaServicios()
        {
            datosPersona = new DatosPersona();
            personaList = datosPersona.MostrarTodos();
        }

        public String Guardar(Persona persona)
        {
            //Este condiconal valida que el dato que se vaya a guardar no sea nulo o este vacia la informacion 
            if(persona == null)
            {
                return "No se puede agregar personas nulas o sin in formacion";
            }
            //Si el dato no es nulo en tonces mandara la informacion al metodo guardar de ñla capa de datos y
            //guardara la informacion en el archivo de texto
            var msg = (datosPersona.Guardar(persona));
            personaList = datosPersona.MostrarTodos();
            return msg;
        }
        //Este metodo mostrara todos los datos guardados en la lista, los mostrar en pantalla 
        public List<Persona> ConsultarTodos()
        {
            return personaList;//retorna la lista 
        }

        //Elimina persona por la cedula utilizando el metodo de ObtenerPersona y borra todo los datos de esa persona
        public String EliminarPersona(Persona PersonaEliminada)
        {

            if (PersonaEliminada == null)
            {
                return $"No se encuentra persona Con ID {PersonaEliminada.Cedula}";
            }
            else
            {
                personaList.Remove(PersonaEliminada);
                datosPersona.ActualizarLista(personaList);
                return $"Liquidacion eliminada con exito";
            }
        }

        public string ModificarPersona(Persona personaOriginal, Persona personaModificada)
        {
            if (personaModificada == null)
            {
                return $"No se encuentra la persona con el ID {personaModificada.Cedula}";
            }
            else
            {
                personaList.Remove(personaOriginal);
                personaList.Add(personaModificada);
                datosPersona.ActualizarLista(personaList);
                return $"Persona modificada con exito";
            }
        }
        public List<Persona> FiltroPorNombre(String Nombre)
        {
            List<Persona> listaFiltrada = new List<Persona>();
            bool listaVacia = true;

            foreach (var Liquidacion in personaList)
            {
                if (Liquidacion.Nombre == Nombre)
                {
                    listaFiltrada.Add(Liquidacion);
                    listaVacia = false;
                }
            }

            if (listaVacia == true)
            {
                listaFiltrada = null;
            }

            return listaFiltrada;
        }

        //Busca persona por id en la lista de personas 
        public Persona ObtenerPersona(int cc)
        {
            foreach (var item in personaList)
            {
                if (cc == item.Cedula)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
