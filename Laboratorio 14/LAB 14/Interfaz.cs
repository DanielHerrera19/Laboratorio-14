using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_14.LAB_14
{
    internal class Interfaz
    {

        public static int[] edad = new int[100];
        public static int[] votoobtenido = new int[100];
        public static int contador = 0;

        public static int Menu()
        {
            string texto = "================================\n" +
                   "Encuesta Covid-19\n" +
                   "================================\n" +
                   "1: Realizar Encuesta\n" +
                   "2: Mostrar Datos de la encuesta\n" +
                   "3: Mostrar Resultados\n" +
                   "4: Buscar Personas por edad\n" +
                   "5: Salir\n" +
                   "================================\n";
            Console.Write(texto);
            return Operaciones.getEntero("Ingrese una opción: ", texto);
        }

        public static int EncuestaVacunacion()
        {
            string texto = " ================================\n" +
                "Encuesta de vacunación\n" +
                "================================\n";
            Console.Write(texto);
            int EDAD = Operaciones.getENTERO("¿Qué edad tienes: ");
            if (contador == 1000)
            {
                Console.WriteLine("La lista ya esta completa");
            }
            else
            {
                string texto2 = "Te has vacunado\n" +
                "1: Sí\n" +
                "2: No\n" +
                "================================\n";
                Console.Write(texto2);
                int Votacion;
                do
                {
                    Votacion = Operaciones.getENTERO("Ingrese una opción: ");

                    if (Votacion != 1 && Votacion != 2)
                    {
                        Console.WriteLine("Ingresa una opción valida");
                    }

                } while (Votacion != 1 && Votacion != 2);

                edad[contador] = EDAD;
                votoobtenido[contador] = Votacion;
                contador++;
            }

            Console.Clear();
            return GraciasPorParticipar();
        }

        public static int GraciasPorParticipar()
        {
            string texto = " ================================\n" +
                "Encuesta de vacunación\n" +
                "================================\n" +
                " \n" +
                " \n" +
                "¡Gracias por participar!\n" +
                " \n" +
                " \n" +
                "================================\n" +
                "1: Regresar al menú\n" +
                "================================\n";
            Console.Write(texto);
            int opcion = Operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;
        }

        public static int DatosEncuesta()
        {
            string texto = "================================\n" +
              "Datos de la encuesta\n" +
              "================================\n" +
              " \n" +
              "  ID |\tEdad |\tVacunado\n" +
              "================================\n";
            Console.Write(texto);

            if (contador == 0)
            {
                Console.WriteLine("No extisten notas");
            }
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"{i.ToString("D4")} | {edad[i].ToString().PadLeft(4)}  | {(votoobtenido[i] == 1 ? "Si" : "No").PadRight(2)}");
            }

            string texto2 = "================================\n" +
              "1: Regresar\n" +
              "================================\n";
            Console.Write(texto2);

            int opcion = Operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;
        }

        public static int MostrarResultados()
        {
            string texto = "================================\n" +
              "Resultados de la encuesta\n" +
              "================================\n";
            Console.Write(texto);

            int[] ConteoPorOpcion = new int[3];
            int[] ConteoPorEdad = new int[7];

            for (int i = 0; i < contador; i++)
            {
                int OPCION = votoobtenido[i];
                ConteoPorOpcion[OPCION]++;

                int Edad = edad[i];

                if (Edad >= 1 && Edad <= 20)
                {
                    ConteoPorEdad[1]++;
                }
                else if (Edad >= 21 && Edad <= 30)
                {
                    ConteoPorEdad[2]++;
                }
                else if (Edad >= 31 && Edad <= 40)
                {
                    ConteoPorEdad[3]++;
                }
                else if (Edad >= 41 && Edad <= 50)
                {
                    ConteoPorEdad[4]++;
                }
                else if (Edad >= 51 && Edad <= 60)
                {
                    ConteoPorEdad[5]++;
                }
                else if (Edad > 60)
                {
                    ConteoPorEdad[6]++;
                }
            }

            string texto2 = $"{ConteoPorOpcion[1]} personas se han vacunado\n" +
              $"{ConteoPorOpcion[2]} personas no se han vacunado\n" +
              " \n" +
              "Existen:\n" +
              $"{ConteoPorEdad[1]} personas entre 01 y 20 años\n" +
              $"{ConteoPorEdad[2]} personas entre 21 y 30 años\n" +
              $"{ConteoPorEdad[3]} personas entre 31 y 40 años\n" +
              $"{ConteoPorEdad[4]} personas entre 41 y 50 años\n" +
              $"{ConteoPorEdad[5]} personas entre 51 y 60 años\n" +
              $"{ConteoPorEdad[6]} personas de más de 61 años\n" +
              "================================\n" +
              "1: Regresar\n" +
              "================================\n";
            Console.Write(texto2);

            int opcion = Operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;
        }

        public static int BuscarPersona()
        {
            string texto = "================================\n" +
              "Busca a personas por edad\n" +
              "================================\n";
            Console.Write(texto);

            int valorBuscar = Operaciones.getENTERO("¿Qué edad quieres buscar?: ");
            int vacunados = 0;
            int nroVacunados = 0;
            bool numeroEncontrado = false;

            for (int i = 0; i < contador; i++)
            {
                if (valorBuscar == edad[i])
                {
                    if (votoobtenido[i] == 1)
                    {
                        vacunados++;
                    }
                    else if (votoobtenido[i] == 2)
                    {
                        nroVacunados++;
                    }
                    numeroEncontrado = true;
                }
            }
            if (!numeroEncontrado)
            {
                Console.WriteLine("\nEl número ingresado no existe");
            }
           else
            {
                Console.WriteLine("\n" + vacunados + " se vacunaron");
                Console.WriteLine(nroVacunados+ " no se vacunaron");
            }
            string texto2 = " \n" +
              "================================\n" +
              "1: Regresar\n" +
              "================================\n";
            Console.Write(texto2);

            int opcion = Operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;
        }
    }
}
