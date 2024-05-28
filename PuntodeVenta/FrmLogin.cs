using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntodeVenta
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtContraseña.Text;
            bool loginSuccessful = false; 

            if (!File.Exists("login.txt"))
            {
                using (StreamWriter sw = File.CreateText("login.txt"))
                {
                    sw.WriteLine("admin|12345");
                }
            }

            if (File.Exists("login.txt"))
            {
                using (StreamReader sr = new StreamReader("login.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts[0] == username && parts[1] == password)
                        {
                            loginSuccessful = true; 
                            break;
                        }
                    }
                }
            }

            if (loginSuccessful)
            {
                MessageBox.Show("Inicio de sesión exitoso.");
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
}



   
        




