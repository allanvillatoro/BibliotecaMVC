using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Clase_Biblioteca
{
    public class BibliotecaDBContext: DbContext
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BibliotecaDB;Integrated Security=True";
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(connectionString);

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
    }

    public class Libro
    {
        [Key]
        public int id_libro { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public int anio { get; set; }
        public decimal multapordia { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; } //es para hacer consultas inner join
    }

    public class Alumno
    {
        [Key]
        public int cuenta { get; set; }
        public string nombres { get; set; }
        public string carrera { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; } //es para hacer consultas inner join
    }

    public class Prestamo
    {
        [Key]
        public int id_prestamo { get; set; }
        public DateTime fecha_entrega { get; set; }
        public DateTime fecha_a_devolver { get; set; }
        public DateTime? fecha_devolucion { get; set; }
        public string observaciones { get; set; }

        public virtual Alumno Alumnos { get; set; } //opcional, para hacer los inner join
        [ForeignKey("Alumnos")]
        public int alumno_cuenta { get; set; }

        public virtual Libro Libros { get; set; } //opcional, para hacer los inner join

        [ForeignKey("Libros")]
        public int libro_id { get; set; }
    }

}
