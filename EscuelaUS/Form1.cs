using EscuelaUS.datos;
using EscuelaUS.datos.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaUS
{
    public partial class Universidad : Form
    {
        private  Conexion con = new Conexion();
        private void limpiarTextos()
        {
            formNombre.Text = "";
            formCalificacion.Text = "";
        } 

        private void refresh()

        {
            string consulta = "select * from Alumnos ";
            SqlCommand comando = new SqlCommand(consulta, con.conectar());
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            _ = adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
            con.desconectar();
        }
        public Universidad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //boton guardar
        {
            //validar campos del formulario formNombre formCalificacion
            if (formNombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese un nombre");
            }
            else if (formNombre.Text.Trim().Length <= 5)
            {
                MessageBox.Show("Ingrese un nombre mayor a 5 caracteres");
            }
            else
            {
                //llamar al modelo
                Alumno al =new Alumno();
                al.Nombre = formNombre.Text.Trim().ToUpper();//paso del formulario al atributo del modelo
                al.Calificacion = Convert.ToInt32(formCalificacion.Text.Trim());

                if (AlumnoController.guardar(al)) //llamo a guardar y espero respuesta
                {
                    MessageBox.Show("Alumno guardado");
                    refresh();
                    limpiarTextos();
                }
                else
                {
                    MessageBox.Show("Fallo la inserción");
                    limpiarTextos();
                }
            }       
            //insertarlos
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = (dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            bool resultado = AlumnoController.eliminar(id);
            if (resultado)
            {
                MessageBox.Show("alumno elimnado");
                refresh();
                limpiarTextos();

            }
            else
            {
                MessageBox.Show("no se pudo eliminar el alumno");
                limpiarTextos();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           

           
            string id = (dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            
            Alumno alumno = new Alumno();
            alumno.Nombre = formNombre.Text;
            alumno.Calificacion = Convert.ToInt32(formCalificacion.Text);
            bool resultado = AlumnoController.actualizar(alumno, id);
            if (resultado)
            {
                MessageBox.Show("alumno actualizado");
                refresh();
                limpiarTextos();

            }
            else
            {
                MessageBox.Show("no se pudo actualizar el alumno");
                limpiarTextos();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nombre = formNombre.Text;
            string consulta = "select * from Alumnos where nombre like '%" +nombre+"%'";
            SqlCommand comando = new SqlCommand(consulta, con.conectar());
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            _ = adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
            con.desconectar();
        }

        private void formNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Universidad_Load(object sender, EventArgs e)
        {
            refresh();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
