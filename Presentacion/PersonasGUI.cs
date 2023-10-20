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
                Console.SetCursorPosition(10, 9); Console.WriteLine("3. Eliminar persona por cedula");
                Console.SetCursorPosition(10, 11); Console.WriteLine("4. Actualizar persona");
                Console.SetCursorPosition(10, 13); Console.WriteLine("5. Filtrar por Nombre");
                Console.SetCursorPosition(10, 16); Console.WriteLine("6. Salir del programa");
                Console.SetCursorPosition(15, 20); Console.WriteLine("Seleccione una opcion");
                
                    op = int.Parse(Console.ReadLine());

                switch (op) 
                {
                    case 1:
                        AgregarPersona();
                        break;
                    case 2:
                        MostrarPersona();
                        break;
                    case 3:
                        EliminarPersona();//Sistema de punto de venta POV
                        break;
                    case 4:
                        ModificarPersona(); ;
                        break;
                    case 5:
                        FiltroPorNombre();
                        break;
                }

            } while (op != 6);
        }
        public void AgregarPersona()
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

            string sexo;
            do
            {
                Console.WriteLine("Digite el sexo de la persona (1.Masculino / 2.Femenino):");
                sexo = Console.ReadLine();
                if (sexo == "1")
                {
                    sexo = "Masculino";
                }
                else
                {
                    sexo = "Femenino";
                }
            } while (sexo != "Masculino" && sexo != "Femenino");
            //Console.WriteLine("Digite las pulsaciones de la persona");
            //decimal pulsaciones = decimal.Parse(Console.ReadLine());

            Persona persona = new Persona(cedula,nombre,apellido,edad,sexo/*,pulsaciones*/);
            Console.WriteLine(personaServicio.Guardar(persona));
            Console.ReadKey();
        }
        private void MostrarPersona()
        {
            PersonaServicios personaServicio = new PersonaServicios();
            if (personaServicio.ConsultarTodos() != null)
            {
                Console.Clear();
                Console.SetCursorPosition(15, 2); Console.Write("--------------LISTADO DE PERSONAS---------------");
                Console.SetCursorPosition(10, 4); Console.Write("identificacion");
                Console.SetCursorPosition(28, 4); Console.Write("Nombre");
                Console.SetCursorPosition(40, 4); Console.Write("Apellido");
                Console.SetCursorPosition(52, 4); Console.Write("Edad");
                Console.SetCursorPosition(60, 4); Console.Write("Sexo");
                //Console.SetCursorPosition(56, 4); Console.Write("Pulsacion");
                int posicion = 2;
                foreach (var item in personaServicio.ConsultarTodos())
                {

                    Console.SetCursorPosition(11, 4 + posicion); Console.Write(item.Cedula);
                    Console.SetCursorPosition(29, 4 + posicion); Console.Write(item.Nombre);
                    Console.SetCursorPosition(39, 4 + posicion); Console.Write(item.Apellido);
                    Console.SetCursorPosition(52, 4 + posicion); Console.Write(item.Edad);
                    Console.SetCursorPosition(60, 4 + posicion); Console.Write(item.Sexo);
                    //Console.SetCursorPosition(59, 4 + posicion); Console.Write(item.Pulsaciones);
                    posicion++;
                }
            }
            else
            {
                Console.WriteLine("LA LISTA ESTA VACIA");
            }
            Console.ReadKey();
        }
        private static void EliminarPersona()
        {
            PersonaServicios personaServicio = new PersonaServicios();
            int cc;
            string op;

            Console.Clear();
            Console.WriteLine("Ingrese el numero de liquidacion a eliminar");
            cc = int.Parse(Console.ReadLine());
            Console.WriteLine("");


            var personaEliminada = personaServicio.ObtenerPersona(cc);

            if (personaEliminada == null)
            {
                Console.WriteLine("El numero de cedula ingresado no coincide con los registros");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Numero de cedula  : {personaEliminada.Cedula}");
                Console.WriteLine($"ID del paciente        : {personaEliminada.Nombre}");
                Console.WriteLine($"Nombre del paciente    : {personaEliminada.Apellido}");
                Console.WriteLine($"Tipo de afiliacion     : {personaEliminada.Edad}");
                Console.WriteLine($"Salario del paciente   : {personaEliminada.Sexo}");
               // Console.WriteLine($"Valor del servicio     : {personaEliminada.ValorServicio}");
                Console.WriteLine("");

                do
                {
                    Console.WriteLine("DESEA ELIMINAR ESTA INFORMACION [S/N]");
                    op = Console.ReadLine();
                    op = op.ToUpper();

                } while (op != "S" && op != "N");

                if (op == "S")
                {
                    personaServicio.EliminarPersona(personaEliminada);
                }
            }

            Console.ReadKey();
        }
        private void ModificarPersona()
        {
            PersonaServicios personaServicio = new PersonaServicios();
            int numeroCc;
            string op;

            Console.Clear();
            Console.WriteLine("Ingrese el numero de liquidacion a modificar");
            numeroCc = int.Parse(Console.ReadLine());
            Console.WriteLine("");


            var personaOriginal = personaServicio.ObtenerPersona(numeroCc);

            if (personaOriginal == null)
            {
                Console.WriteLine("El numero de liquidacion generado no coincide con los registros");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Numero de cedula  : {personaOriginal.Cedula}");
                Console.WriteLine($"ID del paciente        : {personaOriginal.Nombre}");
                Console.WriteLine($"Nombre del paciente    : {personaOriginal.Apellido}");
                Console.WriteLine($"Tipo de afiliacion     : {personaOriginal.Edad}");
                Console.WriteLine($"Salario del paciente   : {personaOriginal.Sexo}");
                Console.WriteLine("");

                do
                {
                    Console.WriteLine("DESEA MODIFICAR A ESTA PERSONA? [S/N]");
                    op = Console.ReadLine();
                    op = op.ToUpper();

                } while (op != "S" && op != "N");

                if (op == "S")
                {
                    AgregarPersona();
                    //var personaModificada = personaOriginal;
                    //Console.WriteLine(personaServicio.ModificarPersona(personaOriginal, personaModificada));
                }
            }

            Console.ReadKey();
        }
        private static void FiltroPorNombre()
        {
            Console.Clear();
            PersonaServicios personaServicio = new PersonaServicios();
            string Nombre;


            Console.WriteLine("Ingrese el nombre a buscar");
            Nombre = Console.ReadLine();

            if (personaServicio.FiltroPorNombre(Nombre) != null)
            {


                Console.Clear();
                Console.SetCursorPosition(15, 2); Console.Write("***Listado General***");
                Console.SetCursorPosition(2, 4); Console.Write("Cedula");
                Console.SetCursorPosition(16, 4); Console.Write("Nombre");
                Console.SetCursorPosition(29, 4); Console.Write("Apellido");
                Console.SetCursorPosition(38, 4); Console.Write("Edad");
                Console.SetCursorPosition(52, 4); Console.Write("Sexo");

                int posicion = 2;
                foreach (var item in personaServicio.FiltroPorNombre(Nombre))
                {

                    Console.SetCursorPosition(2, 4 + posicion); Console.Write(item.Cedula);
                    Console.SetCursorPosition(16, 4 + posicion); Console.Write(item.Nombre);
                    Console.SetCursorPosition(29, 4 + posicion); Console.Write(item.Apellido);
                    Console.SetCursorPosition(38, 4 + posicion); Console.Write(item.Edad);
                    Console.SetCursorPosition(52, 4 + posicion); Console.Write(item.Sexo);
                    posicion++;
                }
            }
            else
            {
                Console.WriteLine($"NO SE ENCONTRARON PERSONAS CON EL NOMBRE {Nombre}");
            }

            Console.ReadKey();
        }
    }
}
