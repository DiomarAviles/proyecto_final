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
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;



namespace proyecto_final
{
    public partial class dstod : Form
    {
        string server = "Data Source = LAPTOP-CBI4OL1I\\SQLEXPRESS; Initial Catalog= proyecto;User ID=sa; Password=hola123;";
        SqlConnection conexion = new SqlConnection();

        public dstod()
        {
            InitializeComponent();
        }
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
        public class usuarios
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            public usuarios(int id, string nombre)
            {
                Id = id;
                Nombre = nombre;
            }

            public override string ToString()
            {
                return Nombre;
            }
        }
        private void dstod_Load(object sender, EventArgs e)
        {
            
            SqlConnection conexion = new SqlConnection(server);
            conexion.Open();
            DataSet dataSet = new DataSet();
            string query = "SELECT r.id_reg,u.usuario as usuario,l.nombre as lenguaje,r.fechahora as 'fecha/hora' FROM registro r,Lenguaje l,USUARIO u where r.FK_Id_usuario = u.id_usu and r.FK_Id_leng=l.id_len";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);

            // Llenar el DataSet con los datos de la base de datos
            adapter.Fill(dataSet);

            // Asignar los datos del DataSet al DataGridView
            dataGridView1.DataSource = dataSet.Tables[0];
            conexion.Close();



            conexion.ConnectionString = server;

            string querys = "select id_usu,usuario from USUARIO";


            SqlCommand command = new SqlCommand(querys, conexion);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<usuarios> usuario = new List<usuarios>();
            while (reader.Read())
            {
                int id = (int)reader["id_usu"];
                string nombre = (string)reader["usuario"];
                usuarios leng = new usuarios(id, nombre);
                usuario.Add(leng);
            }
            conexion.Close();

                comboBox1.DataSource = usuario;
                comboBox1.DisplayMember = "nombre";
                comboBox1.ValueMember = "id";


            conexion.ConnectionString = server;

            string query3 = "select id_len,nombre from Lenguaje";


            SqlCommand cone = new SqlCommand(query3, conexion);
            conexion.Open();
            SqlDataReader reader2 = cone.ExecuteReader();
            List<Lenguaje> lenguajes = new List<Lenguaje>();
            while (reader2.Read())
            {
                int id = (int)reader2["id_len"];
                string nombre = (string)reader2["nombre"];
                Lenguaje leng = new Lenguaje(id, nombre);
                lenguajes.Add(leng);
            }
            conexion.Close();

            cbleng.DataSource = lenguajes;
            cbleng.DisplayMember = "nombre";
            cbleng.ValueMember = "id";


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateTime = dateTimePicker1.Value;
           
            MessageBox.Show(dateTime.ToString());
            dataGridView1.DataSource = null;
            string query="";
            SqlConnection conexion = new SqlConnection(server);
            conexion.Open();
            DataSet dataSet = new DataSet();
            if (radioButton1.Checked)
            {
                query = "SELECT r.id_reg,u.usuario as usuario,l.nombre as lenguaje,r.fechahora as 'fecha/hora' FROM registro r,Lenguaje l,USUARIO u where r.FK_Id_usuario = u.id_usu and u.id_usu=" + comboBox1.SelectedValue+"  and r.FK_Id_leng=l.id_len";

            }
            if (radioButton2.Checked)
            {
                query = "SELECT r.id_reg,u.usuario as usuario,l.nombre as lenguaje,r.fechahora as 'fecha/hora' FROM registro r,Lenguaje l,USUARIO u where r.FK_Id_usuario = u.id_usu and l.id_len=r.FK_Id_leng and r.FK_Id_leng=" + cbleng.SelectedValue;

            }
            if (radioButton3.Checked)
            {
                query = "SELECT r.id_reg,u.usuario as usuario,l.nombre as lenguaje,r.fechahora as 'fecha/hora'FROM registro r,Lenguaje l,USUARIO u where r.FK_Id_usuario = u.id_usu and r.FK_Id_leng=l.id_len and r.fechahora between'' and'May 15 2023  1:50PM'";


            }
            SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);

            // Llenar el DataSet con los datos de la base de datos
            adapter.Fill(dataSet);

            // Asignar los datos del DataSet al DataGridView
            dataGridView1.DataSource = dataSet.Tables[0];
            conexion.Close();


        }



        // Exportar a archivo csv

        public void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            // Crear una instancia de Excel
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet sheet = (Excel.Worksheet)workbook.ActiveSheet;

            try
            {
                // Encabezados de columna
                for (int i = 1; i <= dataGridView.Columns.Count; i++)
                {
                    sheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                }

                // Datos de las filas
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        sheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // Guardar el archivo Excel
                workbook.SaveAs(filePath);
                workbook.Close();
                excel.Quit();

                MessageBox.Show("Exportación exitosa");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message);
            }
            finally
            {
                ReleaseObject(sheet);
                ReleaseObject(workbook);
                ReleaseObject(excel);
            }
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Error al liberar el objeto: " + ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string filePath = "C:\\Users\\isaia\\OneDrive\\Escritorio\\archivo.xlsx";
            ExportToExcel(dataGridView1, filePath);
        }

        private void btnExportarTxt_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Crear archivo de texto y escribir los datos
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string linea = "";
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            linea += dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t";
                        }
                        sw.WriteLine(linea);
                    }
                }
            }
        }

        private void btnExportarCsv_Click_1(object sender, EventArgs e)
        {
            // Mostrar cuadro de diálogo para seleccionar la ubicación del archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de valores separados por comas (*.csv)|*.csv";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Crear archivo csv y escribir los datos
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string linea = "";
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            linea += dataGridView1.Rows[i].Cells[j].Value.ToString() + ",";
                        }
                        sw.WriteLine(linea.TrimEnd(','));
                    }
                }
            }
        }
    }
}
