using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary;

namespace ETSinventarios
{
    public partial class Administrador : FormBase
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM Usuario WHERE Id_Usuario =" + IniciarSesion.Codigo;

            DataSet DS = Utilidades.Ejecutar(cmd);

            labId.Text = DS.Tables[0].Rows[0]["Id_Usuario"].ToString();
            labAdmin.Text = DS.Tables[0].Rows[0]["Nombre"].ToString();
            labCod.Text = DS.Tables[0].Rows[0]["Clave"].ToString();

            string url = DS.Tables[0].Rows[0]["Foto"].ToString();

            pictureBox1.Image = Image.FromFile(url);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditarUsuario editarUsuario = new EditarUsuario();
            editarUsuario.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas salir? .", "Aviso",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


    }
}
