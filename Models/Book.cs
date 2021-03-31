using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase_Biblioteca.Models
{
    public class Book
    {
        public int id_libro { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public int anio { get; set; }
        public decimal multapordia { get; set; }
    }
}
