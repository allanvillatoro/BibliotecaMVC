using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clase_Biblioteca.Models;

namespace Clase_Biblioteca.Controllers
{
    public class PrestamosController : Controller
    {
        public IActionResult Index()
        {
            List<Loan2> lista = new List<Loan2>();
            using (BibliotecaDBContext db = new BibliotecaDBContext())
            {
                var consulta = from s in db.Prestamos
                               where s.Libros.titulo.Contains("Progra") && s.fecha_devolucion == null
                               orderby s.fecha_a_devolver ascending
                               select new Loan2
                               {
                                   id_prestamo = s.id_prestamo,
                                   alumno_cuenta = s.alumno_cuenta,
                                   alumno_nombre = s.Alumnos.nombres,
                                   libro_id = s.libro_id,
                                   libro_titulo = s.Libros.titulo,
                                   fecha_entrega = s.fecha_entrega,
                                   fecha_a_devolver = s.fecha_a_devolver,
                                   fecha_devolucion = s.fecha_devolucion
                               };
                lista = consulta.ToList();
            }
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
