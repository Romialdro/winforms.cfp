using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp_club.Utilities;


namespace WinFormsApp_club.Forms
{
    public partial class InscripcionesForm : FormBase
    {
        private readonly string connectionString = "Server=localhost;Database=club_app;Uid=root;Pwd=;";
        private string aptoColumnName = null;
        private bool hasFechaInsColumn = false;

        public InscripcionesForm()
        {
            InitializeComponent();
            if (!IsInDesignMode())
                Inicializar();
        }

        private bool IsInDesignMode()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime) || this.DesignMode;
        }

        // ===============================================================
        //  INICIALIZACIÓN
        // ===============================================================
        private void Inicializar()
        {
            DetectarColumnasExtras();
            CargarSocios();
            CargarActividades();
            ConfigurarGrid();
            ActivarEventos();
        }

        private void ActivarEventos()
        {

            Inscribir.Click -= Inscribir_Click;
            Inscribir.Click += Inscribir_Click;

            comboBox1.SelectedIndexChanged -= ComboSocio_Changed;
            comboBox1.SelectedIndexChanged += ComboSocio_Changed;

            comboBox2.SelectedIndexChanged -= ComboActividad_Changed;
            comboBox2.SelectedIndexChanged += ComboActividad_Changed;

            button1.Click -= Eliminar_Click;
            button1.Click += Eliminar_Click;

            button3.Click -= Limpiar_Click;
            button3.Click += Limpiar_Click;

            button4.Click -= Editar_Click;
            button4.Click += Editar_Click;
        }

        // ===============================================================
        //  Detectar columnas opcionales en la BD
        // ===============================================================
        private void DetectarColumnasExtras()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();


                using (var cmd = new MySqlCommand("SHOW COLUMNS FROM socios LIKE 'apto_fisico_vencimiento'", conn))
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                        aptoColumnName = "apto_fisico_vencimiento";
                    rdr.Close();
                }

                if (aptoColumnName == null)
                {
                    using (var cmd = new MySqlCommand("SHOW COLUMNS FROM socios LIKE 'certificado_vencimiento'", conn))
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                            aptoColumnName = "certificado_vencimiento";
                        rdr.Close();
                    }
                }


                using (var cmd = new MySqlCommand("SHOW COLUMNS FROM inscripciones LIKE 'fecha_inscripcion'", conn))
                using (var rdr = cmd.ExecuteReader())
                {
                    hasFechaInsColumn = rdr.Read();
                    rdr.Close();
                }
            }
            catch
            {

                aptoColumnName = null;
                hasFechaInsColumn = false;
            }
        }

        // ===============================================================
        //  CARGA DE SOCIOS Y ACTIVIDADES
        // ===============================================================
        private void CargarSocios()
        {
            comboBox1.Items.Clear();
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = aptoColumnName != null
                    ? $"SELECT id, nombre_apellido, `{aptoColumnName}` FROM socios WHERE estado='activo' ORDER BY nombre_apellido"
                    : "SELECT id, nombre_apellido FROM socios WHERE estado='activo' ORDER BY nombre_apellido";

                using var cmd = new MySqlCommand(q, conn);
                using var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var item = new SocioItem
                    {
                        Id = rdr.GetInt32("id"),
                        Nombre = rdr.GetString("nombre_apellido"),
                        AptoVence = null
                    };

                    if (aptoColumnName != null)
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal(aptoColumnName)))
                            item.AptoVence = Convert.ToDateTime(rdr[aptoColumnName]);
                    }

                    comboBox1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando socios:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarActividades()
        {
            comboBox2.Items.Clear();
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = "SELECT id, nombre, precio FROM actividades WHERE estado='activa' ORDER BY nombre";
                using var cmd = new MySqlCommand(q, conn);
                using var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    comboBox2.Items.Add(new ActividadItem
                    {
                        Id = rdr.GetInt32("id"),
                        Nombre = rdr.GetString("nombre"),
                        Precio = rdr["precio"] == DBNull.Value ? 0 : Convert.ToDecimal(rdr["precio"])
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando actividades:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================================================
        //  CONFIG GRID
        // ===============================================================
        private void ConfigurarGrid()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
        }

        // ===============================================================
        //  AL CAMBIAR SOCIO → mostrar apto + actividades inscritas
        // ===============================================================
        private void ComboSocio_Changed(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is not SocioItem socio)
            {

                label5.Text = aptoColumnName == null ? "Apto/certificado no registrado" : "Apto físico vigente hasta";
                label5.BackColor = Color.Yellow;
                dataGridView1.DataSource = null;
                return;
            }

            MostrarApto(socio.AptoVence);
            CargarInscripcionesSocio(socio.Id);
        }

        private void MostrarApto(DateTime? vence)
        {
            if (vence == null)
            {
                label5.Text = "Apto físico no registrado solicitar el mismo";
                label5.BackColor = Color.Red;
                return;
            }

            DateTime v = vence.Value.Date;
            DateTime hoy = DateTime.Today;

            // tolerancia: si venció hace <= 30 días 
            if (v < hoy)
            {
                var dias = (hoy - v).TotalDays;
                if (dias <= 30)
                {
                    label5.Text = $"Apto vencido recientemente dar plazo ({v:dd/MM/yyyy})";
                    label5.BackColor = Color.Yellow;
                }
                else
                {
                    label5.Text = $"Apto vencido ({v:dd/MM/yyyy})";
                    label5.BackColor = Color.Red;
                }
            }
            else if ((v - hoy).TotalDays <= 7)
            {
                label5.Text = $"Apto próximo a vencer ({v:dd/MM/yyyy})";
                label5.BackColor = Color.Yellow;
            }
            else
            {
                label5.Text = $"Apto vigente hasta {v:dd/MM/yyyy}";
                label5.BackColor = Color.LightGreen;
            }
        }

        private void CargarInscripcionesSocio(int socioId)
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();


                string campoFecha = hasFechaInsColumn ? "i.fecha_inscripcion" : "NULL AS fecha_inscripcion";


                string q = $@"
                    SELECT i.id,
                           a.nombre AS actividad,
                           {campoFecha},
                           a.precio AS monto
                    FROM inscripciones i
                    LEFT JOIN actividades a ON a.id = i.actividad_id
                    WHERE i.socio_id = @s
                    ORDER BY i.id DESC";

                using var da = new MySqlDataAdapter(q, conn);
                da.SelectCommand.Parameters.AddWithValue("@s", socioId);

                var dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando inscripciones:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================================================
        //  AL CAMBIAR ACTIVIDAD → actualiza precio en el textbox
        // ===============================================================
        private void ComboActividad_Changed(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem is ActividadItem act)
            {

                textBox1.Text = act.Precio.ToString("0.00");
            }
            else
            {
                textBox1.Text = "";
            }
        }

        // ===============================================================
        //  INSCRIBIR
        // ===============================================================
        private void Inscribir_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is not SocioItem socio)
            {
                MessageBox.Show("Seleccioná un socio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox2.SelectedItem is not ActividadItem act)
            {
                MessageBox.Show("Seleccioná una actividad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            decimal monto = act.Precio;

            // ---  permitida inscripción si apto vencido hace <= 30 días (1 mes de plazo)
            if (socio.AptoVence != null)
            {
                DateTime v = socio.AptoVence.Value.Date;
                DateTime hoy = DateTime.Today;

                if (v < hoy)
                {
                    double diasVencidos = (hoy - v).TotalDays;
                    if (diasVencidos > 30)
                    {
                        
                        MessageBox.Show($"No se puede inscribir: el apto físico venció hace {Math.Floor(diasVencidos)} días ({v:dd/MM/yyyy}).\nSe permite un plazo máximo de 30 días.", "Apto vencido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // si vencido <=30 días → permitimos extensión un mes
                }
            }
            else
            {
                // Si no existe apto registrado, mantenemos el comportamiento previo:
               //bloqueo solo bien vencido
            }

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = hasFechaInsColumn
               ? @"INSERT INTO inscripciones (socio_id, actividad_id, fecha, subtotal, monto_pagado) 
               VALUES (@s, @a, @f, @m, 0)"
               : @"INSERT INTO inscripciones (socio_id, actividad_id, fecha, subtotal, monto_pagado)
               VALUES (@s, @a, CURDATE(), @m, 0)";


                using var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@s", socio.Id);
                cmd.Parameters.AddWithValue("@a", act.Id);
                cmd.Parameters.AddWithValue("@m", monto);

                if (hasFechaInsColumn)
                    cmd.Parameters.AddWithValue("@f", dtpFecha.Value.Date);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Inscripción registrada ✔", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarInscripcionesSocio(socio.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inscribir:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================================================
        //  ELIMINAR
        // ===============================================================
        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná una inscripción.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id;
            try
            {
                id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            }
            catch
            {
                MessageBox.Show("No se pudo leer la inscripción seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                using var cmd = new MySqlCommand("DELETE FROM inscripciones WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Inscripción eliminada.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (comboBox1.SelectedItem is SocioItem s)
                    CargarInscripcionesSocio(s.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error eliminando:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================================================
        //  LIMPIAR
        // ===============================================================
        private void Limpiar_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox1.Text = "";
            dtpFecha.Value = DateTime.Today;

            label5.Text = "Apto físico vigente hasta";
            label5.BackColor = Color.Yellow;

            dataGridView1.DataSource = null;
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función Editar pendiente.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    
        // ===============================================================
        //  CLASES INTERNAS
        // ===============================================================
        private class SocioItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public DateTime? AptoVence { get; set; }
            public override string ToString() => Nombre;
        }

        private class ActividadItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public override string ToString() => Nombre;
        }

        // Handlers que el Designer puede usar --> evito error
        private void InscripcionesForm_Load(object sender, EventArgs e) { /* () */ }
        private void label3_Click(object sender, EventArgs e) { /* () */ }
    }


}
