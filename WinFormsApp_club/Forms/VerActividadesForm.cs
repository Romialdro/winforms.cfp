using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp_club.Utilidades;
using WinFormsApp_club.Utilities;

namespace WinFormsApp_club.Forms
{
    public partial class VerActividadesForm : FormBase
    {
        private readonly string connectionString = "Server=localhost;Database=club_app;Uid=root;Pwd=;";

        public VerActividadesForm()
        {
            InitializeComponent();

            if (!IsInDesignMode())
                Inicializar();
        }

        private bool IsInDesignMode()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime) || this.DesignMode;
        }

        // ============================================================
        //   INICIALIZACIÓN
        // ============================================================
        private void Inicializar()
        {
            ButtonFactory.AgregarBotonVolver(this, () =>
                Application.OpenForms.OfType<Form>()
                .FirstOrDefault(f => f is DashboardForm)
                ?? new DashboardForm("Usuario", "Admin")
            );

            CargarFiltros();
            ConfigurarGrid();
            CargarComboActividades();
            ActivarEventos();
            CargarGrid();
        }

        private void ActivarEventos()
        {
            button1.Click -= Buscar_Click;
            button1.Click += Buscar_Click;

            button2.Click -= Limpiar_Click;
            button2.Click += Limpiar_Click;

            button4.Click -= Editar_Click;
            button4.Click += Editar_Click;

            button3.Click -= Eliminar_Click;
            button3.Click += Eliminar_Click;

            dataGridView1.CellDoubleClick -= DataGridView1_CellDoubleClick;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        // ============================================================
        //   CARGA INICIAL
        // ============================================================
        private void CargarFiltros()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Nombre");
            comboBox2.Items.Add("Categoria");
            comboBox2.SelectedIndex = -1;
        }

        private void CargarComboActividades()
        {
            comboBox1.Items.Clear();

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = "SELECT id, nombre FROM actividades WHERE estado='activa' ORDER BY nombre";

                using var cmd = new MySqlCommand(q, conn);
                using var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    comboBox1.Items.Add(new ComboItem
                    {
                        Text = rdr.GetString("nombre"),
                        Value = rdr.GetInt32("id")
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar actividades:\n" + ex.Message);
            }
        }

        // ============================================================
        //   GRID
        // ============================================================
        private void ConfigurarGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;

            // *** COLUMNA ID (clave obligatoria)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "id",
                Name = "id",
                Width = 70
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "nombre",
                Name = "nombre",
                Width = 250
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Categoria",
                DataPropertyName = "categoria",
                Name = "categoria",
                Width = 180
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Precio",
                DataPropertyName = "precio",
                Name = "precio",
                Width = 120
            });
        }

        // ============================================================
        //   FILTROS Y BUSQUEDA
        // ============================================================
        private void Buscar_Click(object sender, EventArgs e)
        {
            string filtro = comboBox2.Text;
            string valor = textBox1.Text.Trim().Replace("'", "''");

            string condicion = "";

            if (!string.IsNullOrWhiteSpace(filtro) && !string.IsNullOrWhiteSpace(valor))
            {
                if (filtro == "Nombre")
                    condicion += $" AND nombre LIKE '%{valor}%'";
                else if (filtro == "Categoria")
                    condicion += $" AND categoria LIKE '%{valor}%'";
            }

            if (comboBox1.SelectedItem is ComboItem it)
                condicion += $" AND id = {it.Value}";

            CargarGrid(condicion);
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox1.Clear();
            CargarGrid();
        }

        private void CargarGrid(string condicion = "")
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = "SELECT id, nombre, categoria, precio FROM actividades " +
                           "WHERE estado='activa' " + condicion + " ORDER BY nombre";

                using var da = new MySqlDataAdapter(q, conn);
                var dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar actividades:\n" + ex.Message);
            }
        }

        // ============================================================
        //   EDITAR (BOTÓN)
        // ============================================================
        private void Editar_Click(object sender, EventArgs e)
        {
            AbrirActividadSeleccionada();
        }

        // ============================================================
        //   EDITAR (DOBLE CLICK)
        // ============================================================
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirActividadSeleccionada();
        }

        private void AbrirActividadSeleccionada()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná una actividad para editar.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

            var form = new ActividadesForm(id);
            form.ShowDialog();

            CargarGrid();
        }

        // ============================================================
        //   ELIMINAR
        // ============================================================
        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná una actividad para eliminar.");
                return;
            }

            string nombre = dataGridView1.SelectedRows[0].Cells["nombre"].Value.ToString();
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

            var confirm = MessageBox.Show(
                $"¿Seguro querés marcar inactiva la actividad '{nombre}'?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.No) return;

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = "UPDATE actividades SET estado='inactiva' WHERE id=@id";

                using var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Actividad marcada como inactiva.");
                CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar:\n" + ex.Message);
            }
        }

        // ============================================================
        //   ITEM DEL COMBOBOX
        // ============================================================
        private class ComboItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString() => Text;
        }
    }
}
