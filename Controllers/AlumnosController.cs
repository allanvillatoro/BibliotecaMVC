using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clase_Biblioteca.Models;

namespace Clase_Biblioteca.Controllers
{
    public class AlumnosController : Controller
    {
        ConexionBiblioteca conexion = new ConexionBiblioteca();

        //GET /Alumnos/Index
        public IActionResult Index()
        {
            IEnumerable<Estudiante> lista = conexion.getAlumnos();
            return View(lista);
        }

        //GET /Alumnos/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST /Alumnos/Create
        [HttpPost]
        public IActionResult Create(Estudiante es)
        {
            int filasAfectadas = conexion.addAlumno(es);
            if (filasAfectadas > 0)
                Console.WriteLine("Se agregaron a la bd");
            else
                Console.WriteLine("Hubo un error");

            return RedirectToAction("Index");
        }

        //GET /Alumnos/Details/id
        public IActionResult Details (int id)
        {
            Estudiante es = conexion.getAlumno(id);
            return View(es);
        }

        //GET /Alumnos/Edit/id
        public IActionResult Edit(int id)
        {
            Estudiante es = conexion.getAlumno(id);
            return View(es);
        }

        //GET /Alumnos/Delete/id
        public IActionResult Delete(int id)
        {
            Estudiante es = conexion.getAlumno(id);
            return View(es);
        }

        //POST /Alumnos/Edit/id
        [HttpPost]
        public IActionResult Edit (Estudiante es)
        {
            int filasAfectadas = conexion.updateAlumno(es);
            if (filasAfectadas > 0)
                Console.WriteLine("Se modificó en la bd");
            else
            {
                Console.WriteLine("Hubo un error");
                return View(es);
            }
            return RedirectToAction("Index");
        }

        //POST /Alumnos/Delete/id
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed (int id)
        {
            int filasAfectadas = conexion.deleteAlumno(id);
            if (filasAfectadas > 0)
                Console.WriteLine("Se eliminó de la bd");
            else
            {
                Console.WriteLine("Hubo un error");
                Estudiante estu = conexion.getAlumno(id);
                return View(estu);
            }
            return RedirectToAction("Index");
        }
    }
}
