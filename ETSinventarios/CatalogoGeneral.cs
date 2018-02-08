using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MyLibrary;
using System.Data.SqlClient;

namespace ETSinventarios
{
    public partial class CatalogoGeneral : Form
    {
        public CatalogoGeneral()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string con = "Provider = Microsoft.Jet.OleDb.4.0; Data Source = C:/Users/marco/Documents/Proyectos/Catalogo1.xlsx;Extended Properties = \"Excel 8.0;HDR = Yes\"";

            OleDbConnection conector = default(OleDbConnection);
            conector = new OleDbConnection(con);
            conector.Open();

            OleDbCommand consulta = default(OleDbCommand);
            consulta = new OleDbCommand("select * from [Hoja1$]",conector);

            OleDbDataAdapter adaptador = new OleDbDataAdapter();
            adaptador.SelectCommand = consulta;

            DataSet ds = new DataSet();

            adaptador.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            conector.Close();

            //----------------exportar a SQL------------

            SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=InventariosSI;Integrated Security=True");
            conexion.Open();

            SqlBulkCopy exportar = default(SqlBulkCopy);
            exportar = new SqlBulkCopy(conexion);
            exportar.DestinationTableName = "Catalogo";
            exportar.WriteToServer(ds.Tables[0]);

            conexion.Close();

            MessageBox.Show("Se Exporo exitosamente el Catálogo");

            //new Importar().importarExcel(dataGridView1, "Hoja1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
