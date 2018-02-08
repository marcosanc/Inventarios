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
using MyLibrary;

namespace ETSinventarios
{
    public partial class IniciarSesion : Form
    {
        public IniciarSesion()
        {
            InitializeComponent();
        }

        public static String Codigo = "";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string CMD = string.Format("SELECT * FROM Usuario WHERE Nombre = '{0}' AND Clave = '{1}'", texUsuario.Text.Trim(), texPassword.Text.Trim());

                DataSet ds = Utilidades.Ejecutar(CMD);

                Codigo = ds.Tables[0].Rows[0]["Id_Usuario"].ToString().Trim();

                string cuenta = ds.Tables[0].Rows[0]["Nombre"].ToString().Trim();
                string password = ds.Tables[0].Rows[0]["Clave"].ToString().Trim();

                if(cuenta == texUsuario.Text.Trim() && password == texPassword.Text.Trim())
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Tipo"]) == true)
                    {
                        MessageBox.Show("Has iniciado sesión como Administrador","BIENVENIDO", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Administrador administrador = new Administrador();
                        administrador.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Has iniciado sesión como Invitado", "BIENVENIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Usuario usuario = new Usuario();
                        usuario.Show();
                        this.Hide();
                    }

                    /*Menu menu = new Menu();
                    menu.Show();
                    this.Hide();*/ 
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

        private void IniciarSesion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void IniciarSesion_Load(object sender, EventArgs e)
        {

        }
    }
}
