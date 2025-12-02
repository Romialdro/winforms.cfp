using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp_club.Utilities;

namespace WinFormsApp_club.Forms
{
    public partial class VerSociosForm : FormBase
    {
        private readonly string connectionString = "server=localhost;database=club_app;user=root;password=;";

        public VerSociosForm()
        {
            InitializeComponent();
            // La inicialización pesada se hace en OnLoad.
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            
            if (IsInDesignMode()) return;

            CargarFiltros();
            ActivarEventos();
            ConfigurarGrid();
            AplicarEstiloDataGrid();   // ⭐ AGREGADO SOLO ESTO
            CargarSocios();
        }

        private bool IsInDesignMode()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime) || this.DesignMode;
        }

        private void ActivarEventos()
        {
            button1.Click -= Buscar_Click;
            button2.Click -= Limpiar_Click;
            button4.Click -= Editar_Click;
            button3.Click -= Eliminar_Click;

            button1.Click += Buscar_Click;
            button2.Click += Limpiar_Click;
            button4.Click += Editar_Click;
            button3.Click += Eliminar_Click;
        }

        private void CargarFiltros()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("activo");
            comboBox1.Items.Add("inactivo");
            comboBox1.SelectedIndex = -1;

            comboBox2.Items.Clear();
            comboBox2.Items.Add("Nombre");
            comboBox2.Items.Add("DNI");
            comboBox2.SelectedIndex = -1;
        }

        private void ConfigurarGrid()
        {
            dgvSocios.AutoGenerateColumns = false;
            dgvSocios.Columns.Clear();

            dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSocios.MultiSelect = false;
            dgvSocios.AllowUserToAddRows = false;
            dgvSocios.AllowUserToDeleteRows = false;
            dgvSocios.ReadOnly = true;

            // estilo global
            dgvSocios.EnableHeadersVisualStyles = false;
            dgvSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // =========================
            // COLUMNAS
            // =========================

            dgvSocios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "ID",
                DataPropertyName = "id",
                Width = 60,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvSocios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Nombre",
                DataPropertyName = "nombre_apellido",
                Width = 260
            });

            dgvSocios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "DNI",
                DataPropertyName = "dni",
                Width = 120,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvSocios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Estado",
                DataPropertyName = "estado",
                Width = 100,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }


        //ESTO PUEDO HEREDAR DE LA CLASE FORMBASE***VER DE IMPLEMENTAR 
        private void AplicarEstiloDataGrid()
        {
            dgvSocios.BorderStyle = BorderStyle.None;
            dgvSocios.BackgroundColor = Color.White;
            dgvSocios.GridColor = Color.LightGray;
            dgvSocios.EnableHeadersVisualStyles = false;

            // Estilo encabezado
            dgvSocios.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dgvSocios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSocios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvSocios.ColumnHeadersHeight = 32;

            // Estilo filas
            dgvSocios.DefaultCellStyle.BackColor = Color.White;
            dgvSocios.DefaultCellStyle.ForeColor = Color.Black;
            dgvSocios.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvSocios.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvSocios.RowHeadersVisible = false;

            dgvSocios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 250, 255);
            dgvSocios.RowTemplate.Height = 26;
        }

        private void CargarSocios(string condicion = "")
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string query = "SELECT id, nombre_apellido, dni, estado FROM socios WHERE 1=1 " +
                               condicion + " ORDER BY nombre_apellido LIMIT 1000";

                using var da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSocios.DataSource = dt;
            }
            catch (MySqlException mex)
            {
                MessageBox.Show("Error de base de datos al cargar socios:\n" + mex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar socios:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            string estado = comboBox1.Text;
            string filtro = comboBox2.Text;
            string valor = textBox1.Text.Trim().Replace("'", "''");

            string condicion = "";

            if (!string.IsNullOrEmpty(estado))
                condicion += $" AND estado = '{estado}'";

            if (!string.IsNullOrEmpty(filtro) && !string.IsNullOrEmpty(valor))
            {
                if (filtro == "Nombre")
                    condicion += $" AND nombre_apellido LIKE '%{valor}%'";
                else if (filtro == "DNI")
                    condicion += $" AND dni LIKE '%{valor}%'";
            }

            CargarSocios(condicion);
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox1.Clear();
            CargarSocios();
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            if (dgvSocios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un socio para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvSocios.SelectedRows[0].Cells[0].Value);

            using var form = new SociosForm(id);
            var result = form.ShowDialog();

            CargarSocios();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (dgvSocios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un socio para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nombre = dgvSocios.SelectedRows[0].Cells[1].Value.ToString();
            int id = Convert.ToInt32(dgvSocios.SelectedRows[0].Cells[0].Value);

            var confirm = MessageBox.Show(
                $"¿Seguro querés dar de baja a {nombre}? Esta acción solo marcará como inactivo.",
                "Confirmar baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.No) return;

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string query = "UPDATE socios SET activo = 0, estado = 'inactivo' WHERE id = @id";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Socio dado de baja correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarSocios();
                }
                else
                {
                    MessageBox.Show("No se encontró el socio o no se pudo actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (MySqlException mex)
            {
                MessageBox.Show("Error de BD al eliminar:\n" + mex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSocios_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}

