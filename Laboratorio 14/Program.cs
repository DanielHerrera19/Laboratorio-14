using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorio_14.LAB_14;

namespace Laboratorio_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = Interfaz.Menu();
            do
            {
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        opcion = Interfaz.EncuestaVacunacion();
                        break;
                    case 2:
                        opcion = Interfaz.DatosEncuesta();
                        break;
                    case 3:
                        opcion = Interfaz.MostrarResultados();
                        break;
                    case 4:
                        opcion = Interfaz.BuscarPersona();
                        break;
                    case 0:
                    default:
                        opcion = Interfaz.Menu();
                        break;
                }
            } while (opcion != 5);
        }
    }
}
