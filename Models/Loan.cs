using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase_Biblioteca.Models
{
    public class Loan
    {
        public int id_prestamo { get; set; }
        public int alumno_cuenta { get; set; }
        public int libro_id { get; set; }
        public System.DateTime fecha_entrega { get; set; }
        public System.DateTime fecha_a_devolver { get; set; }
        public System.DateTime? fecha_devolucion { get; set; }
        public string observaciones { get; set; }
    }
}
