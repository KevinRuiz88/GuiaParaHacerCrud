using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    internal class PersonasGUI
    {
        private PersonaServicios personaServicio = new PersonaServicios();

        //Metosdo donde estan las opciones que podra elegier el usuario que se mostrara en pantalla 
        public void Menu()
        {
            int op = 0;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(15, 2); Console.WriteLine("########### MENU PRINCIPAL ############");
                Console.SetCursorPosition(10, 5); Console.WriteLine("1. Agregar perosona");
                Console.SetCursorPosition(10, 7); Console.WriteLine("2. Mostrar todas las personas registradas");
                Console.SetCursorPosition(10, 9); Console.WriteLine("3. Actualizar persona");
                Console.SetCursorPosition(10, 11); Console.WriteLine("4. Eliminar persona por cedula");
                Console.SetCursorPosition(10, 13); Console.WriteLine("5. Salir del programa");
                Console.SetCursorPosition(15, 15); Console.WriteLine("Seleccione una opcion");
                
                    op = int.Parse(Console.ReadLine());

                switch (op) 
                {
                    case 1:
                        AgregarUsuario();
                        break;
                    case 2:
                        MostrarPersonas();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                }

            } while (op != 5);
        }
        public void AgregarUsuario()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el numero de cedula de la persona");
            int cedula = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite el nombre de la persona");
            string nombre = Console.ReadLine();
            Console.WriteLine("Digite el apellido de la persona");
            string apellido = Console.ReadLine();
            Console.WriteLine("Digite la edad de la persona");
            int edad = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite el sexo de la persona");
            string sexo = Console.ReadLine();
            Console.WriteLine("Digite las pulsaciones de la persona");
            decimal pulsaciones = decimal.Parse(Console.ReadLine());

            Persona persona = new Persona(cedula,nombre,apellido,edad,sexo,pulsaciones);
            Console.WriteLine(personaServicio.Guardar(persona));
            Console.ReadKey();
        }
        private void MostrarPersonas()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 2); Console.Write("Listado General");
            Console.SetCursorPosition(10, 4); Console.Write("identificacion");
            Console.SetCursorPosition(28, 4); Console.Write("Nombre");
            Console.SetCursorPosition(34, 4); Console.Write("Apellido");
            Console.SetCursorPosition(40, 4); Console.Write("Edad");
            Console.SetCursorPosition(46, 4); Console.Write("Sexo");
            Console.SetCursorPosition(56, 4); Console.Write("Pulsacion");
            int posicion = 2;
            foreach (var item in personaServicio.ConsultarTodos())
            {

                Console.SetCursorPosition(15, 4 + posicion); Console.Write(item.Cedula);
                Console.SetCursorPosition(29, 4 + posicion); Console.Write(item.Nombre);
                Console.SetCursorPosition(34, 4 + posicion); Console.Write(item.Apellido);
                Console.SetCursorPosition(42, 4 + posicion); Console.Write(item.Edad);
                Console.SetCursorPosition(48, 4 + posicion); Console.Write(item.Sexo);
                Console.SetCursorPosition(59, 4 + posicion); Console.Write(item.Pulsaciones);
                posicion++;
            }
            Console.ReadKey();
        }
        //public void EliminarPersona()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Digite el numero de cedula que desee eliminar ");
        //    int cedula = int.Parse(Console.ReadLine());
        //    personaServicio.ObtenerPersona(cedula);
        //    personaServicio.
        //}
        public void ActulizarPersona()
        {
        }
    }
}
