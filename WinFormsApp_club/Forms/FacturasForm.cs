using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WinFormsApp_club.Utilities;

namespace WinFormsApp_club.Forms
{
    public partial class FacturasForm : FormBase
    {
        private readonly string connectionString = "Server=localhost;Database=club_app;Uid=root;Pwd=;";
        private int pagoId;

        // ============================
        //   CONSTRUCTORES
        // ============================
        public FacturasForm()
        {
            InitializeComponent();
        }

        public FacturasForm(int idPago)
        {
            InitializeComponent();
            pagoId = idPago;
            CargarFactura(idPago);
        }

        // ============================
        //   CARGAR FACTURA
        // ============================
        private void CargarFactura(int id)
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = @"SELECT p.id, p.fecha, p.monto, p.vencimiento, p.pagado, p.actividades,
                             p.uuid_pago, p.link_mp,
                             s.nombre_apellido, s.dni
                             FROM pagos p
                             LEFT JOIN socios s ON s.id = p.socio_id
                             WHERE p.id = @id LIMIT 1";

                using var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", id);

                using var rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    lblFecha.Text = Convert.ToDateTime(rdr["fecha"]).ToString("yyyy-MM-dd");
                    lblSocio.Text = rdr["nombre_apellido"].ToString();
                    lblMonto.Text = Convert.ToDecimal(rdr["monto"]).ToString("0.00");
                    lblVencimiento.Text = rdr["vencimiento"] == DBNull.Value ?
                                          "-" : Convert.ToDateTime(rdr["vencimiento"]).ToString("yyyy-MM-dd");

                    lblLink.Text = rdr["link_mp"] == DBNull.Value ?
                                   "Sin link generado" : rdr["link_mp"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando factura:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================
        //   → EXPORTAR FACTURA
        // ============================
        public string GetFacturaTexto()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = @"SELECT p.id, p.fecha, p.monto, p.vencimiento, p.pagado, p.actividades,
                             p.uuid_pago, p.link_mp,
                             s.nombre_apellido, s.dni
                             FROM pagos p
                             LEFT JOIN socios s ON s.id = p.socio_id
                             WHERE p.id = @id LIMIT 1";

                using var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", pagoId);

                using var rdr = cmd.ExecuteReader();
                if (!rdr.Read())
                    return "FACTURA NO ENCONTRADA";

                var sb = new StringBuilder();

                sb.AppendLine("----- FACTURA SIMULADA -----");
                sb.AppendLine($"Pago ID: {rdr["id"]}");
                sb.AppendLine($"Fecha: {Convert.ToDateTime(rdr["fecha"]):yyyy-MM-dd}");
                sb.AppendLine($"Socio: {rdr["nombre_apellido"]}");
                sb.AppendLine($"DNI: {rdr["dni"]}");
                sb.AppendLine($"Monto: {Convert.ToDecimal(rdr["monto"]):0.00}");
                sb.AppendLine($"Vencimiento: {(rdr["vencimiento"] == DBNull.Value ? "-" : Convert.ToDateTime(rdr["vencimiento"]).ToString("yyyy-MM-dd"))}");
                sb.AppendLine($"Pagado: {(Convert.ToInt32(rdr["pagado"]) == 1 ? "Sí" : "No")}");
                sb.AppendLine($"Actividades: {rdr["actividades"]}");

                if (rdr["uuid_pago"] != DBNull.Value)
                    sb.AppendLine($"UUID: {rdr["uuid_pago"]}");

                if (rdr["link_mp"] != DBNull.Value)
                    sb.AppendLine($"Link: {rdr["link_mp"]}");

                sb.AppendLine("----------------------------");
                sb.AppendLine("Factura generada automáticamente.");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "Error generando texto:\n" + ex.Message;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Handler vacío para evitar errores--fallos de copilación
        }
    }
}
