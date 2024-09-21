using GestionCine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCIne
{
    internal class Program
    {
     
        // Variable para almacenar la selección de película
        private static List<Pelicula> peliculasSeleccionadas = new List<Pelicula>();
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            int opcion;

            do
            {
                Console.Clear();
                opcion = Pantallas.PantallaPrincipal();

                switch (opcion)
                {
                    case 1:
                        Pantallas.MenuRolCliente();
                        break;
                    case 2:
                        Pantallas.MenuRolTrabajador();
                        break;
                    case 3:
                        Pantallas.MenuRolAdminFun();
                        break;
                    case 0:

                        break;
                }
            } while (opcion != 4);
        }
    }
}
