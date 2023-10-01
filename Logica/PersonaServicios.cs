using Datos;
using Entidades;
using System;
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
            personaList = datosPersona.ConsultarTodos();
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
            return msg;
        }
        //Este metodo mostrara todos los datos guardados en la lista, los mostrar en pantalla 
        public List<Persona> ConsultarTodos()
        {
            return personaList;//retorna la lista 
        }

        //Elimina persona por la cedula utilizando el metodo de ObtenerPersona y borra todo los datos de esa persona
        public string Eliminarpersona(Persona persona)
        {
            personaList.Remove(ObtenerPersona(persona.Cedula));

            var msg = datosPersona.Guardar(personaList);
            return msg;
        }

        //Busca persona por id en la lista de personas 
        public Persona ObtenerPersona(int id)
        {
            foreach (var item in personaList)
            {
                if (id == item.Cedula)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
