using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WinFormsApp_club.Utilities;

namespace WinFormsApp_club.Forms
{
    public partial class UsuariosForm : FormBase
    {
        private readonly string connectionString = "Server=localhost;Database=club_app;Uid=root;Pwd=;";

        public UsuariosForm()
        {
            InitializeComponent();
            CargarRoles();
            CargarUsuarios();

            button1.Click += CrearUsuario_Click;
            button2.Click += Limpiar_Click;
        }

        // =========================
        // CARGAR ROLES
        // =========================
        private void CargarRoles()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("admin");
            comboBox1.Items.Add("operador");
            comboBox1.SelectedIndex = 0;
        }

        // =========================
        // CARGAR USUARIOS EN GRILLA
        // =========================
        private void CargarUsuarios()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = @"SELECT id, usuario, rol FROM usuarios ORDER BY id DESC";

                using var da = new MySqlDataAdapter(q, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando usuarios:\n" + ex.Message);
            }
        }

        // =========================
        // CREAR USUARIO
        // =========================
        private void CrearUsuario_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text.Trim();
            string correo = textBox2.Text.Trim(); 
            string clave = textBox3.Text.Trim();
            string rol = comboBox1.Text;

            if (usuario == "" || clave == "")
            {
                MessageBox.Show("Completá usuario y contraseña.");
                return;
            }

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = @"INSERT INTO usuarios (usuario, clave, rol)
                             VALUES (@u, @c, @r)";

                using var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@u", usuario);
                cmd.Parameters.AddWithValue("@c", clave); 
                cmd.Parameters.AddWithValue("@r", rol);

                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Usuario creado correctamente");

                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al crear usuario:\n" + ex.Message);
            }
        }

        // =========================
        // LIMPIAR
        // =========================
        private void Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = 0;
        }
    }
}

//FUTURAS IMPLEMENTACIONES: CRUD COMPLETO (EDITAR SOCIO, BORRAR SOCIO, RESETEAR CONTRASEÑA, DAR DE BAJA(ARMAR TRIGGER )
//NO IMPLEMENTADAS POR FALTA DE ESTRUCTURA EN BASE DE DATOS Y TIEMPO DE ENTREGA