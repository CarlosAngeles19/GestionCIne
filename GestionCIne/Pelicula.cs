using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    internal class Pelicula
    {
        public string Nombre { get; set; }
        public string Horario { get; set; }
        public decimal Precio { get; set; }

        public Pelicula(string nombre, string horario, decimal precio)
        {
            Nombre = nombre;
            Horario = horario;
            Precio = precio;
        }
    }
}
