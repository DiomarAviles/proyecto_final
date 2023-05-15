using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace proyecto_final
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }
        internal static int idusu=0;
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
        private bool CheckCredentials(string user, string hashedPassword)
        {
            string connectionString = "Data Source = LAPTOP-CBI4OL1I\\SQLEXPRESS; Initial Catalog= proyecto;User ID=sa; Password=hola123;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM USUARIO WHERE usuario=@Username AND pwd_usu=@Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user);
                    command.Parameters.AddWithValue("@Password", hashedPassword);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            singup frm = new singup();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu frm = new menu();
            frm.Show();
        }

        private void BTN_LOG_Click(object sender, EventArgs e)
        {
            string user = tbusu.Text;
            string password = tbpsw.Text;
            string hashedPassword = HashPassword(password);
            string connectionString = "Data Source = LAPTOP-CBI4OL1I\\SQLEXPRESS; Initial Catalog= proyecto;User ID=sa; Password=hola123;";
            SqlConnection connection = new SqlConnection(connectionString);
            
                string query = "SELECT id_usu FROM USUARIO WHERE usuario=@Username AND pwd_usu=@Password";
                
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", user);
            command.Parameters.AddWithValue("@Password", hashedPassword);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                idusu = (int)reader["id_usu"];
            }
            connection.Close(); 
        
            
            if (CheckCredentials(user, hashedPassword))
            {
                // Login successful
               
                menu frm = new menu();
                frm.Show();

                this.Hide();
                
            }
            else
            {
                // Login failed
                MessageBox.Show("Invalid username or password.");
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}