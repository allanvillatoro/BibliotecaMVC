using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase_Biblioteca.Models
{
    public class ConexionBiblioteca
    {
        //Conexion local
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BibliotecaDB;Integrated Security=True";

        public IEnumerable<Estudiante> getAlumnos()
        {
            string sql = "select * from alumnos";
            List<Estudiante> lstStudent = new List<Estudiante>();
            using (SqlConnection conexionSQL = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conexionSQL);
                conexionSQL.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Estudiante student = new Estudiante();
                    student.cuenta = Convert.ToInt32(sqlDataReader["cuenta"]);
                    student.nombres = sqlDataReader["nombres"].ToString();
                    student.carrera = sqlDataReader["carrera"].ToString();
                    student.celular = sqlDataReader["celular"].ToString();
                    student.correo = sqlDataReader["correo"].ToString();

                    lstStudent.Add(student);
                }
                conexionSQL.Close();
                return lstStudent;
            }
        }

        public int addAlumno(Estudiante student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("insert into Alumnos values (@cuenta, @nombres, @carrera, @celular, @correo)", con);
                cmd.Parameters.AddWithValue("@cuenta", student.cuenta);
                cmd.Parameters.AddWithValue("@nombres", student.nombres);
                cmd.Parameters.AddWithValue("@carrera", student.carrera);
                cmd.Parameters.AddWithValue("@celular", student.celular);
                cmd.Parameters.AddWithValue("@correo", student.correo);
                con.Open();
                int filas = cmd.ExecuteNonQuery();
                con.Close();
                return filas;
            }
        }

        public Estudiante getAlumno(int? cuenta)
        {
            Estudiante student = new Estudiante();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Alumnos WHERE cuenta= " + cuenta;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    student.cuenta = Convert.ToInt32(rdr["cuenta"]);
                    student.nombres = rdr["nombres"].ToString();
                    student.carrera = rdr["carrera"].ToString();
                    student.celular = rdr["celular"].ToString();
                    student.correo = rdr["correo"].ToString();
                }
                con.Close();
            }
            return student;
        }

        public int updateAlumno(Estudiante student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("update Alumnos set nombres=@nombres, carrera=@carrera, celular=@celular, correo=@correo where cuenta=@cuenta", con);
                cmd.Parameters.AddWithValue("@cuenta", student.cuenta);
                cmd.Parameters.AddWithValue("@nombres", student.nombres);
                cmd.Parameters.AddWithValue("@carrera", student.carrera);
                cmd.Parameters.AddWithValue("@celular", student.celular);
                cmd.Parameters.AddWithValue("@correo", student.correo);
                con.Open();
                int filas = cmd.ExecuteNonQuery();
                con.Close();
                return filas;
            }
        }

        public int deleteAlumno(int? cuenta)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("delete from Alumnos where cuenta=@cuenta", con);
                cmd.Parameters.AddWithValue("@cuenta", cuenta);
                con.Open();
                int filas = cmd.ExecuteNonQuery();
                con.Close();
                return filas;
            }
        }
    }
}
