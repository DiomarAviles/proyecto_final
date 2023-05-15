using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using static proyecto_final.menu;



namespace proyecto_final
{
    public partial class menu : Form
    {

        private int direccion = 0;
        private string wpalabra = "";
        private char caracter;
        private int columna = 0;
        private string wlinea = "";
        private string wsalida = "";
        private int[,] matriz = new int[10, 17];
        private bool espalreservada;
        private int estado = 0;
        private string token = "";
        private int posicion = 0;
        private int renglon = 0;
        string server = "Data Source = LAPTOP-CBI4OL1I\\SQLEXPRESS; Initial Catalog= proyecto;User ID=sa; Password=hola123;";
        SqlConnection conexion = new SqlConnection();
        public menu()
        {
            InitializeComponent();
            Login login = new Login();
            login.Close();
        }
        Login login = new Login();
        static int idusua =Login.idusu;
        string idusus= idusua.ToString();    
        public class Lenguaje
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            public Lenguaje(int id, string nombre)
            {
                Id = id;
                Nombre = nombre;
            }

            public override string ToString()
            {
                return Nombre;
            }
        }

        public void buscarID()
        {
            bool encontro;
            int renglon2;
            encontro = false;
            renglon2 = 0;
            while ((!encontro) && (renglon2 < listBox2.Items.Count))
            {
                listBox2.SelectedIndex = renglon2;
                if (string.Equals(token.ToUpper(),  listBox2.Text.ToUpper()))
                {
                    encontro = true;
                    direccion = renglon2;
                }
                renglon2 = renglon2 + 1;
            }
            if ((!encontro))
            {
                direccion = listBox2.Items.Add(token);
                direccion = listBox2.Items.Count - 1;
            }
        }
        public void buscarEnteras()
        {
            bool encontro = false;
            int renglon2 = 0;
            while (!encontro && renglon2 < listBox6.Items.Count)
            {
                listBox6.SelectedIndex = renglon2;
                if (string.Equals(token.ToUpper(), listBox6.Text.ToUpper()))
                {
                    encontro = true;
                    direccion = renglon2;
                }
                renglon2 = renglon2 + 1;
            }
            if (!encontro)
            {
                direccion = listBox6.Items.Add(token);
                direccion = listBox6.Items.Count - 1;
            }
        }
        public void buscarReales()
        {
            bool encontro;
            int renglon2;
            encontro = false;
            renglon2 = 0;
            while ((!encontro) && (renglon2 < listBox5.Items.Count))
            {
                listBox5.SelectedIndex = renglon2;
                if (string.Equals(token.ToUpper(), listBox5.Text.ToUpper()))
                {
                    encontro = true;
                    direccion = renglon2;
                }
                renglon2 = renglon2 + 1;
            }
            if (!encontro)
            {
                direccion = listBox5.Items.Add(token);
                direccion = listBox5.Items.Count - 1;
            }
        }
        public void buscarString()
        {
            bool encontro;
            int renglon2;
            encontro = false;
            renglon2 = 0;
            while (!encontro && (renglon2 < listBox7.Items.Count))
            {
                listBox7.SelectedIndex = renglon2;
                if (string.Equals(token.ToUpper(), listBox7.Text.ToUpper()))
                {
                    encontro = true;
                    direccion = renglon2;
                }
                renglon2 = renglon2 + 1;
            }
            if (!encontro)
            {
                direccion = listBox7.Items.Add(token);
                direccion = listBox7.Items.Count - 1;
            }
        }
        public void ReconocerTokens()
        {

            if (estado == 100)
            {
                espalreservada = false;
                buscarPR();
                if (espalreservada)
                {
                    wsalida = token + " PR " + direccion.ToString();
                }
                else
                {
                    buscarID();
                    wsalida = token + " ID " + direccion.ToString();
                }
                posicion = posicion - 1;
            }
            if (estado == 101)
            {
               // buscarEnteras();
                wsalida = token + " Cte.Entera " + direccion.ToString();
                listBox4.Items.Add(wsalida);
                posicion = posicion - 1;
            }
            if (estado == 102)
            {
                buscarReales();
                wsalida = token + " Cte.Real " + direccion.ToString();
                listBox4.Items.Add(wsalida);
                posicion = posicion - 1;
            }
            if (estado == 103)
            {
                buscarString();
                wsalida = token + " Cte.String " + direccion.ToString();
                listBox4.Items.Add(wsalida);
                //posicion = posicion - 1;
            }
            if (estado == 104)
            {
                wsalida = caracter + " operador ";
                listBox4.Items.Add(wsalida);
            }
            if (estado == 105)
            {
                wsalida = caracter + " operador ";
                listBox4.Items.Add(wsalida);
            }
            if (estado == 106)
            {
                wsalida = caracter + " operador ";
                listBox4.Items.Add(wsalida);
            }
            if (estado == 107)
            {
                wsalida = caracter + " operador ";
                listBox4.Items.Add(wsalida);
            }
            if (estado == 108)
            {
                wsalida = caracter + " operador ";
                listBox4.Items.Add(wsalida);
            }
            if (estado == 109)
            {
                wsalida = token + " comentario ";
                listBox4.Items.Add(wsalida);
            }
            if (estado == 110)
            {
                wsalida = caracter + " operador ";
                listBox4.Items.Add(wsalida);
            }
            if (estado == 111)
            {
                wsalida = caracter + " operador ";
                listBox4.Items.Add(wsalida);
            }
            if (estado == 115)
            {
                wsalida = caracter + " caract. esp ";
                listBox4.Items.Add(wsalida);
            }
            if (estado == 114)
            {
                wsalida = caracter + " caract. esp ";
                listBox4.Items.Add(wsalida);
            }
        }

        public void CalcularColumna()
        {
            if (char.IsLetter(caracter) && caracter >= 'A' && caracter <= 'Z' || char.IsLetter(caracter) && caracter >= 'a' && caracter <= 'z')
            {
                columna = 1;
            }
            else if (caracter == ' ' || caracter == ' ')
            {
                columna = 14;
                //posicion = posicion - 1;
            }
            else if (caracter.Equals(","))
            {
                columna = 15;
            }
            else if (caracter.Equals(";"))
            {
                columna = 16;
            }
            else if (caracter.Equals("'") || caracter.Equals("'"))
            {
                columna = 4;
            }
            else if (caracter.Equals("?") || caracter.Equals("?"))
            {
                columna = 10;
            }
            else if (caracter.Equals("=") || caracter.Equals(" = "))
            {
                columna = 5;
            }
            else if (caracter.Equals("+") || caracter.Equals(" + "))
            {
                columna = 6;
            }
            else if (caracter.Equals("-") || caracter.Equals(" - "))
            {
                columna = 7;
            }
            else if (caracter.Equals("/") || caracter.Equals(" / "))
            {
                columna = 8;
            }
            else if (caracter.Equals("^") || caracter.Equals(" ^ "))
            {
                columna = 9;
            }
            else if (caracter.Equals("*") || caracter.Equals(" * "))
            {
                columna = 11;
            }
            else if (double.TryParse(caracter.ToString(), out double result) && result >= 0.0 && result <= 9.9)
            {
                columna = 3;
                if (!caracter.Equals("."))
                {
                    if (int.TryParse(caracter.ToString(), out int intResult) && intResult >= 0 && intResult <= 9)
                    {
                        columna = 2;
                    }
                }
            }
        }
        public void BuscarToken()
        {
            string apa;
            estado = 0;
            token = "";
            posicion = 1;
            while (posicion <= wlinea.Length)
            {
                apa = wlinea.Substring(posicion - 1, 1);
                caracter = apa.FirstOrDefault();
                CalcularColumna();
                estado = matriz[estado, columna];
                if (estado >= 100)
                {
                    if (token.Length > 0 || caracter.ToString().Length > 0)
                    {
                        ReconocerTokens();
                    }
                    estado = 0;
                    token = "";
                }
                else
                {
                    if (estado != 0)
                    {
                        token = token + caracter.ToString();
                    }
                }
                posicion = posicion + 1;
            }
            if (token.Length > 0)
            {
                caracter = ' ';
                CalcularColumna();
                estado = matriz[estado, columna];
                ReconocerTokens();
            }
        }
        public void buscarPR()
        {
            int renglon2;
            renglon2 = 0;
            direccion = -1;
            while (!(espalreservada) && (renglon2 < listBox1.Items.Count))
            {
                listBox1.SelectedIndex = renglon2;

                if ((token.ToUpper() == listBox1.Text.ToUpper()))
                {

                    espalreservada = true;
                    direccion = renglon2;
                }
                renglon2 = renglon2 + 1;

            }
        }

        private void menu_Load(object sender, EventArgs e)
        {

            conexion.ConnectionString = server;

            string query = "select id_len,dir_est from Lenguaje";


            SqlCommand command = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Lenguaje> lenguajes = new List<Lenguaje>();
            while (reader.Read())
            {
                int id = (int)reader["id_len"];
                string nombre = (string)reader["dir_est"];
                Lenguaje leng = new Lenguaje(id, nombre);
                lenguajes.Add(leng);
            }
            conexion.Close();

            cbleng.DataSource = lenguajes;
            cbleng.DisplayMember = "nombre";
            cbleng.ValueMember = "id";


        }

        private void cbleng_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btsele_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            conexion.ConnectionString = server;
            string nombre = "";
            string query = "select id_len,dir_PR from Lenguaje where id_len ='" + cbleng.SelectedValue + "'";
            SqlCommand command = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                nombre = (string)reader["dir_PR"];
            }
            conexion.Close();
            string ruta = "C:\\Users\\isaia\\source\\repos\\proyecto final\\proyecto final\\bin\\Debug\\idiomas\\" + nombre + ".txt";
            StreamReader sr = new StreamReader(ruta);
            string linea;
            while ((linea = (string)sr.ReadLine()) != null)
            {
                listBox1.Items.Add(linea);
            }
            sr.Close();
            // Crear un objeto StreamReader para leer el archivo
            string rutas = "C:\\Users\\isaia\\source\\repos\\proyecto final\\proyecto final\\bin\\Debug\\idiomas\\" + cbleng.Text + ".txt";
            StreamReader readera = new StreamReader(rutas);

            // Leer el archivo línea por línea
            for (int i = 0; i < 10; i++)
            {
                string lineas = (string)readera.ReadLine();

                // Dividir la línea en sus elementos y almacenarlos en la matriz
                string[] elementos = lineas.Split(',');
                for (int j = 0; j < 16; j++)
                {
                    matriz[i, j] = int.Parse(elementos[j]);
                }
            }
            readera.Close();
            reader.Close();
            // Cerrar el objeto StreamReader





        }

        private void btbuscar_Click(object sender, EventArgs e)
        {
            // Mostrar el diálogo de apertura de archivo
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            openFileDialog1.Title = "Seleccione un archivo de texto";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Cargar el contenido del archivo en el ListBox
                listBox1.Items.Clear();
                string[] lineas = File.ReadAllLines(openFileDialog1.FileName);
                foreach (string linea in lineas)
                {
                    listBox3.Items.Add(linea);
                }
            }



        }

        private void btcompilar_Click(object sender, EventArgs e)
        {

            renglon = 0;
            while (renglon < listBox3.Items.Count)
            {
                listBox3.SelectedIndex = (int)renglon;
                wlinea = listBox3.Text;
                BuscarToken();
                renglon = renglon + 1;
            }
           
            string name = cbleng.SelectedValue + idusus + dateTimePicker1.Text;
            Random rnd = new Random();
            string rutaguar= "C:\\Users\\isaia\\source\\repos\\proyecto final\\proyecto final\\bin\\Debug\\archivoguardado/output"+name+rnd+".txt";
            StreamWriter wri = new StreamWriter(rutaguar);
            
            for (int i = 0; i < listBox4.Items.Count; i++)
                {
                    wri.WriteLine((string)listBox4.Items[i]);
                }
            wri.Close();
            conexion.Open();
            string query = "insert into registro (FK_Id_usuario,FK_Id_leng,fechahora) values (@FK_Id_usuario,@FK_Id_leng,@hora)";
            using (SqlCommand command = new SqlCommand(query, conexion))
            {
                command.Parameters.AddWithValue("@FK_Id_usuario", idusus);
                command.Parameters.AddWithValue("@FK_Id_leng", cbleng.SelectedValue);
                DateTime dateTime = dateTimePicker1.Value;
                command.Parameters.AddWithValue("@hora",dateTime );
                command.ExecuteNonQuery();
            }
            conexion.Close();

            }

        private void button1_Click(object sender, EventArgs e)
        {

           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dstod ds = new dstod();
            ds.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}

