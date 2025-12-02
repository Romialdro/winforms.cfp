using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using WinFormsApp_club.Utilities; 

namespace WinFormsApp_club.Forms
{

    public partial class LoginForm : FormBase
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // herencia de clase FormBase en utilidades
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            if (usuario == "" || clave == "")
            {
                MessageBox.Show("Por favor completá usuario y contraseña");
                return;
            }

            // Aplica SHA256 a la clave ingresada, a futuro usare bcrypt
            string claveHash = GetSha256(clave);

            string connectionString = "Server=localhost;Database=club_app;Uid=root;Pwd=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM usuarios WHERE usuario = @usuario AND clave = @clave";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@clave", claveHash);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string rol = reader["rol"]?.ToString() ?? "sin rol";
                        MessageBox.Show("Bienvenida " + usuario + " (" + rol + ")");

                        DashboardForm dashboard = new DashboardForm(usuario, rol);
                        dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message);
                }
            }
        }

        // Función para obtener el hash SHA256 de la contraseña -->
        private string GetSha256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}