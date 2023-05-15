using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Data;
using System.Security.Cryptography;
using Azure.Core;

namespace proyecto_final
{
    public partial class singup : Form
    {
        string server = "Data Source = LAPTOP-CBI4OL1I\\SQLEXPRESS; Initial Catalog= proyecto;User ID=sa; Password=hola123;";
        SqlConnection conexion = new SqlConnection();

        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la contraseña en un arreglo de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convertir el arreglo de bytes a una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
        public singup()
        {
            InitializeComponent();
        }
        

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void BTN_LOG_Click(object sender, EventArgs e)
        {
           string psw = tbpsw.Text; 
            string hashpsw = HashPassword(psw);
            MessageBox.Show(hashpsw);
            conexion.ConnectionString = server;
            conexion.Open();
            SqlCommand cms = new SqlCommand("InsertarUsuario", conexion);
            cms.CommandType = CommandType.StoredProcedure;
            cms.Parameters.AddWithValue("@nom_usu",tbname.Text);
            cms.Parameters.AddWithValue("@app_usu", tbapp.Text);
            cms.Parameters.AddWithValue("@usuario", tbuser.Text);
            cms.Parameters.AddWithValue("@pwd_usu", hashpsw);
            cms.Parameters.AddWithValue("@telefono", tbcel.Text);
            cms.Parameters.AddWithValue("@correo", tbcorr.Text);
            try

            {
                cms.ExecuteNonQuery();
                MessageBox.Show("cuenta creada");
                this.Close();
                 }
            catch (SqlException ex) {
                MessageBox.Show(ex.ToString());
                throw;
            }    
            conexion.Close();



        }
    }
   
}
