using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp_club.Utilities;

namespace WinFormsApp_club.Forms
{
    public partial class PagosForm : FormBase
    {
        private readonly string connectionString = "Server=localhost;Database=club_app;Uid=root;Pwd=;";
        private int ultimoPagoIdGenerado = 0;
        private string currentGeneratedLink = "";

        // ======================================================
        //   OCIO PRE-CARGADO DESDE OTRA PANTALLA
        // ======================================================
        private int? socioPrecargadoId = null;

        public PagosForm()
        {
            InitializeComponent();

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            button2.Click += Registrar_Click;
            button3.Click += Actualizar_Click;
            button4.Click += Limpiar_Click;
            button8.Click += VerPreview_Click;
            button5.Click += DescargarFactura_Click;
            button6.Click += EnviarMail_Click;

            ConfigurarNumericMonto();
            CargarSocios();
            CargarPagos();
        }

        // ======================================================
        //  CONSTRUCTOR SOCIO PRE-SELECCIONADO
        // ======================================================
        public PagosForm(int socioIdPreSeleccionado) : this()
        {
            try
            {
                socioPrecargadoId = socioIdPreSeleccionado;
                comboBox1.SelectedValue = socioIdPreSeleccionado;

                // Bloqueo el combo para evitar cambios del usuario
                comboBox1.Enabled = false;
            }
            catch
            {
                // si falla no rompe nada
            }
        }

        private void ConfigurarNumericMonto()
        {
            try
            {
                numericUpDown1.DecimalPlaces = 2;
                numericUpDown1.Maximum = 10000000m;
                numericUpDown1.Minimum = 0m;
                numericUpDown1.ReadOnly = true;
                numericUpDown1.Enabled = true;
                numericUpDown1.BackColor = System.Drawing.Color.White;
            }
            catch { }
        }

        private void CargarSocios()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = "SELECT id, nombre_apellido FROM socios WHERE estado='activo' ORDER BY nombre_apellido";
                using var da = new MySqlDataAdapter(q, conn);
                var dt = new DataTable();
                da.Fill(dt);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "nombre_apellido";
                comboBox1.ValueMember = "id";
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando socios:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetSelectedSocioId()
        {
            try
            {
                var sel = comboBox1.SelectedValue;
                if (sel == null || sel == DBNull.Value) return null;

                if (sel is int i) return i;
                if (sel is long l) return Convert.ToInt32(l);
                if (sel is decimal d) return Convert.ToInt32(d);
                if (int.TryParse(sel.ToString(), out int parsed)) return parsed;

                if (comboBox1.SelectedItem is DataRowView drv)
                {
                    if (drv.Row.Table.Columns.Contains("id") && drv["id"] != DBNull.Value)
                    {
                        if (int.TryParse(drv["id"].ToString(), out int id2))
                            return id2;
                    }
                }
            }
            catch { }

            return null;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var socioId = GetSelectedSocioId();
                if (!socioId.HasValue)
                {
                    SafeSetNumericValue(0m);
                    return;
                }

                decimal total = CalcularTotalMes(socioId.Value);
                SafeSetNumericValue(total);
            }
            catch
            {
                SafeSetNumericValue(0m);
            }
        }

        private void SafeSetNumericValue(decimal value)
        {
            try
            {
                if (numericUpDown1 == null) return;

                if (value < numericUpDown1.Minimum) value = numericUpDown1.Minimum;
                if (value > numericUpDown1.Maximum) value = numericUpDown1.Maximum;

                numericUpDown1.Value = value;
            }
            catch
            {
                try
                {
                    if (value < numericUpDown1.Minimum) numericUpDown1.Value = numericUpDown1.Minimum;
                    else numericUpDown1.Value = numericUpDown1.Maximum;
                }
                catch { }
            }
        }

        private decimal CalcularTotalMes(int socioId)
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = @"SELECT IFNULL(SUM(subtotal), 0)
                             FROM inscripciones
                             WHERE socio_id = @s
                             AND fecha IS NOT NULL
                             AND MONTH(fecha) = MONTH(CURDATE())
                             AND YEAR(fecha) = YEAR(CURDATE());";

                using var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@s", socioId);

                var res = cmd.ExecuteScalar();
                if (res == null || res == DBNull.Value) return 0m;

                decimal total = Convert.ToDecimal(res);
                if (total < 0) total = 0m;
                return total;
            }
            catch
            {
                return 0m;
            }
        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            try
            {
                var socioId = GetSelectedSocioId();
                if (!socioId.HasValue)
                {
                    MessageBox.Show("Seleccioná un socio válido.");
                    return;
                }

                decimal monto = numericUpDown1.Value;
                if (monto <= 0m)
                {
                    MessageBox.Show("Este socio no tiene deuda.");
                    return;
                }

                DateTime vencimiento = dateTimePicker1.Value.Date;
                int pagado = checkBox1.Checked ? 1 : 0;

                string uuid = Guid.NewGuid().ToString();
                string link = checkBox2.Checked ? $"https://mp.fake/{uuid}" : null;

                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string qInsert = @"INSERT INTO pagos (socio_id, fecha, monto, vencimiento, pagado, uuid_pago, link_mp)
                                   VALUES (@s, NOW(), @m, @v, @p, @u, @l);";

                using (var tx = conn.BeginTransaction())
                using (var cmd = new MySqlCommand(qInsert, conn, tx))
                {
                    cmd.Parameters.AddWithValue("@s", socioId.Value);
                    cmd.Parameters.AddWithValue("@m", monto);
                    cmd.Parameters.AddWithValue("@v", vencimiento);
                    cmd.Parameters.AddWithValue("@p", pagado);
                    cmd.Parameters.AddWithValue("@u", uuid);
                    cmd.Parameters.AddWithValue("@l", (object)link ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    using var cmdId = new MySqlCommand("SELECT LAST_INSERT_ID()", conn, tx);
                    var idObj = cmdId.ExecuteScalar();
                    ultimoPagoIdGenerado = Convert.ToInt32(idObj);

                    string qUpd = @"UPDATE inscripciones SET monto_pagado = subtotal
                                   WHERE socio_id = @s
                                   AND fecha IS NOT NULL
                                   AND MONTH(fecha) = MONTH(CURDATE())
                                   AND YEAR(fecha) = YEAR(CURDATE());";

                    using var cmdUpd = new MySqlCommand(qUpd, conn, tx);
                    cmdUpd.Parameters.AddWithValue("@s", socioId.Value);
                    cmdUpd.ExecuteNonQuery();

                    tx.Commit();
                }

                currentGeneratedLink = link ?? "";

                MessageBox.Show("Pago registrado correctamente ✔");

                SafeSetNumericValue(0m);
                CargarPagos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error registrando pago:\n" + ex.Message);
            }
        }

        private void CargarPagos()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = @"SELECT p.id, COALESCE(s.nombre_apellido,'') AS nombre_apellido,
                                     p.fecha, p.monto, p.pagado
                              FROM pagos p
                              LEFT JOIN socios s ON s.id = p.socio_id
                              ORDER BY p.id DESC";

                using var da = new MySqlDataAdapter(q, conn);
                var dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                // Ajustes estéticos seguros (si fallan, no rompen)
                try
                {
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.BackgroundColor = System.Drawing.Color.White;
                    dataGridView1.GridColor = System.Drawing.Color.LightGray;
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
                    dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
                catch { /* no crítico */ }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando pagos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        //  ACTUALIZAR / LIMPIAR
        // =========================
        private void Actualizar_Click(object sender, EventArgs e) => CargarPagos();

        private void Limpiar_Click(object sender, EventArgs e)
        {
            SafeSetNumericValue(0m);
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            currentGeneratedLink = "";
            ultimoPagoIdGenerado = 0;
            comboBox1.SelectedIndex = -1;

           
            if (socioPrecargadoId.HasValue)
            {
                comboBox1.SelectedValue = socioPrecargadoId.Value;
                comboBox1.Enabled = false;
            }
        }

        // =========================
        //  VER PREVIEW -> FacturasForm
        // =========================
        private void VerPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (ultimoPagoIdGenerado == 0)
                {
                    MessageBox.Show("Primero registrá un pago para generar la factura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var f = new FacturasForm(ultimoPagoIdGenerado);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error mostrando preview:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        //  DESCARGAR / ENVIAR (SIMULADO)
        // =========================
        private void DescargarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (ultimoPagoIdGenerado == 0)
                {
                    MessageBox.Show("No hay factura generada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var f = new FacturasForm(ultimoPagoIdGenerado);
                string texto = f.GetFacturaTexto();

                SaveFileDialog sfd = new SaveFileDialog { Filter = "Archivo de texto (*.txt)|*.txt" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(sfd.FileName, texto);
                    MessageBox.Show("Factura descargada correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error descargando factura:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnviarMail_Click(object sender, EventArgs e)
        {
            try
            {
                if (ultimoPagoIdGenerado == 0)
                {
                    MessageBox.Show("No hay factura para enviar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Simulación:
                MessageBox.Show("Mail enviado correctamente (simulado).", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enviando mail:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
