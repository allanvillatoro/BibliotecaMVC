using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase_Biblioteca.Models
{
    public class Loan2
    {
        public int id_prestamo { get; set; }
        public int alumno_cuenta { get; set; }
        public string alumno_nombre { get; set; }
        public int libro_id { get; set; }
        public string libro_titulo { get; set; }
        public DateTime fecha_entrega { get; set; }
        public DateTime fecha_a_devolver { get; set; }
        public DateTime? fecha_devolucion { get; set; }
    }
}
