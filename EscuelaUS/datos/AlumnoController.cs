using EscuelaUS.datos.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaUS.datos
{
    class AlumnoController
    {
        public static bool guardar(Alumno al)//juan,95
        {
            //conectarme a la bd
            Conexion con = new Conexion();
            //pasar la consulta INSERT INTO Alumno(nombre, calificacion) VALUES('juan',95))
            string sql = "INSERT INTO Alumnos(nombre, calificacion) VALUES('"+al.Nombre+"','"+al.Calificacion+"')";
            //acceder a la base y pasarle la consulta
            SqlCommand inserta = new SqlCommand(sql, con.conectar());//(INSERT INTO Alumno(nombre, calificacion) VALUES('juan',95)),("Data Source=DESKTOP-CFRSQB1\\SQLEXPRESS;Initial Catalog=Universidad;Integrated Security=True")
            //contar las filas insertadas
            int insertados = inserta.ExecuteNonQuery();//1
            if(insertados == 1)
            {
                con.desconectar();//cierro conexion
                return true;
            }
            else
            {
                con.desconectar();
                return false;
            }

        }
        public static bool actualizar (Alumno al,string id) 
        {
            Conexion con = new Conexion();
            string sql = "update Alumnos set nombre = ' " + al.Nombre + "',calificacion =" + al.Calificacion + "where id =" + id;
            SqlCommand inserta = new SqlCommand(sql, con.conectar());
            int insertados = inserta.ExecuteNonQuery();
            if (insertados == 1)
            {
                con.desconectar();//cierro conexion
                return true;
            }
            else
            {
                con.desconectar();
                return false;
            }
        }
        public static bool eliminar (string id)
        {
            Conexion con = new Conexion();
            string sql = "delete from Alumnos where id = " + id; 
            SqlCommand elimina = new SqlCommand(sql, con.conectar());
            int eliminados = elimina.ExecuteNonQuery();
            if (eliminados == 1)
            {
                con.desconectar();//cierro conexion
                return true;
            }
            else
            {
                con.desconectar();
                return false;
            }
        }
    }

}
