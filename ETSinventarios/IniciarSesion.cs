using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using MiLibreria;

namespace ETSinventarios
{
    public partial class IniciarSesion : Form
    {
        public IniciarSesion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string CMD = string.Format("SELECT * FROM Usuario WHERE Nombre = '{0}' AND Clave = '{1}'", texUsuario.Text.Trim(), texPassword.Text.Trim());

                DataSet ds = Utilidades.Ejecutar(CMD);

                string cuenta = ds.Tables[0].Rows[0]["Nombre"].ToString().Trim();
                string password = ds.Tables[0].Rows[0]["Clave"].ToString().Trim();

                if(cuenta == texUsuario.Text.Trim() && password == texPassword.Text.Trim())
                {
                    MessageBox.Show("Has iniciado sesión","BIENVENIDO", MessageBoxButtons.OK,MessageBoxIcon.Information);

                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Verifica los datos", "Error", MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
