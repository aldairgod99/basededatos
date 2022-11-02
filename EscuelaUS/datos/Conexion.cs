using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaUS.datos
{
    class Conexion
    {
        SqlConnection con;//instacia
        String Conexionstring = "Data Source=DESKTOP-MCFVOER;Database=SQLEXPRESS;Integrated Security = false; User ID =Aldair; Password=aldygod7;";
        private SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
       
        public Conexion() //Constructor inicialice la clase con valores
        {
            con = new SqlConnection(Conexionstring);
        }
        public SqlConnection conectar()//metodo para conectar
        {
            con.Open();
            return con; 
        }
        public bool desconectar()//metodo para desconectar
        {
            con.Close();
            return true;
        }
    }
}
