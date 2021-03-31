using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clase_Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clase_Biblioteca.Controllers
{
    public class LibrosController : Controller
    {
        public IActionResult Index()
        {
            List<Book> lista = new List<Book>();
            using (BibliotecaDBContext db = new BibliotecaDBContext())
            {
                //select * from Libros
                //LINQ
                var consulta = from s in db.Libros
                               select new Book
                               {
                                   id_libro = s.id_libro,
                                   titulo = s.titulo,
                                   autor = s.autor,
                                   anio = s.anio,
                                   multapordia = s.multapordia
                               };
                lista = consulta.ToList();
            }
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            try
            {
                using (BibliotecaDBContext db = new BibliotecaDBContext())
                {
                    Libro libro = new Libro();
                    libro.anio = book.anio;
                    libro.autor = book.autor;
                    libro.id_libro = book.id_libro;
                    libro.multapordia = book.multapordia;
                    libro.titulo = book.titulo;

                    db.Libros.Add(libro);

                    int filasAfectadas = db.SaveChanges();
                    if (filasAfectadas > 0)
                    {
                        Console.WriteLine("Agregado exitosamente");
                        TempData["mensaje"] = "Se ha creado exitosamente el nuevo libro.";
                    }                        
                    else
                    {
                        Console.WriteLine("Hubo un error");
                        ViewBag.resCreate = 1;
                        return View(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hubo un error");
                ViewBag.resCreate = 1;
                return View(book);
            }            
            return RedirectToAction("Index");
        }

        public Book buscarLibro(int id)
        {
            Book book = new Book();
            using (BibliotecaDBContext db = new BibliotecaDBContext())
            {
                Libro libro = db.Libros.Find(id);
                if (libro == null)
                    return null;
                book.id_libro = libro.id_libro;
                book.autor = libro.autor;
                book.multapordia = libro.multapordia;
                book.anio = libro.anio;
                book.titulo = libro.titulo;
            }
            return book;
        }

        //GET /Libros/Details/id
        public IActionResult Details(int id)
        {
            using (BibliotecaDBContext db = new BibliotecaDBContext())
            {
                Book book = this.buscarLibro(id);
                return View(book);
            }
        }

        //GET /Libros/Edit/id
        public IActionResult Edit(int id)
        {
            using (BibliotecaDBContext db = new BibliotecaDBContext())
            {
                Book book = this.buscarLibro(id);
                return View(book);
            }
        }

        //POST /Libros/Edit
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            using (BibliotecaDBContext db = new BibliotecaDBContext())
            {
                Libro libro = db.Libros.Find(book.id_libro);
                libro.anio = book.anio;
                libro.autor = book.autor;
                libro.multapordia = book.multapordia;
                libro.titulo = book.titulo;
                int filasAfectadas = db.SaveChanges();
                if (filasAfectadas > 0)
                    Console.WriteLine("Modificado exitosamente");
                else
                {
                    Console.WriteLine("Hubo un error");
                    return View(book);
                }
            }
            return RedirectToAction("Index");
        }

        //GET /Libros/Delete/id
        public IActionResult Delete(int id)
        {
            using (BibliotecaDBContext db = new BibliotecaDBContext())
            {
                Book book = this.buscarLibro(id);
                return View(book);
            }
        }

        //POST /Libros/Delete/id
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            using (BibliotecaDBContext db = new BibliotecaDBContext())
            {
                Libro libro = db.Libros.Find(id);
                db.Libros.Remove(libro);
                int filasAfectadas = db.SaveChanges();
                if (filasAfectadas > 0)
                    Console.WriteLine("Eliminado exitosamente");
                else
                {
                    Console.WriteLine("Hubo un error");
                    Book encontrado = this.buscarLibro(id);
                    return View(encontrado);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
