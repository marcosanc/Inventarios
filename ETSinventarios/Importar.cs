using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using MyLibrary;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ETSinventarios
{
    class Importar
    {
        OleDbConnection conn;
        OleDbDataAdapter MyDataAdapter;
        DataTable dt;
        DataSet ds;

        public void importarExcel(DataGridView dgv, String nombreHoja)
        {
            String ruta = "";
            try
            {
                OpenFileDialog openfile1 = new OpenFileDialog();
                openfile1.Filter = "Excel Files | *.xlsx";
                openfile1.Title = "Seleccione el archivo de Excel";

                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openfile1.FileName.Equals("") == false)
                    {
                        ruta = openfile1.FileName;
                    }
                }

                conn = new OleDbConnection("Provider = Microsoft.Jet.OleDb.4.0; Data Source =" + ruta + ";Extended Properties = \"Excel 8.0;HDR = Yes\"");
                MyDataAdapter = new OleDbDataAdapter("select * from [" + nombreHoja + "$]", conn);
                dt = new DataTable();
                MyDataAdapter.Fill(dt);
                dgv.DataSource = dt;

                SqlBulkCopy exportar = default(SqlBulkCopy);
                exportar = new SqlBulkCopy(ruta);
                exportar.DestinationTableName = "Catalogo";
                exportar.WriteToServer(ds.Tables[0]);

                conn.Close();

                MessageBox.Show("Se guardo exitosamente el Catálogo");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
