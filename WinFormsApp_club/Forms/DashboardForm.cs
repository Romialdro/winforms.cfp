//using System;
//using System.Drawing;
//using System.Windows.Forms;
using WinFormsApp_club.Utilities;

namespace WinFormsApp_club.Forms
{
    public partial class DashboardForm : FormBase
    {
        private readonly string _nombreUsuario;

        public DashboardForm(string nombreUsuario, string rol)
        {
            InitializeComponent();

            _nombreUsuario = nombreUsuario;

            lblBienvenida.Text = $"Bienvenida, {nombreUsuario} 👋";
            lblBienvenida.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.Black;
            //lblBienvenida.Text += $"\nRol: {rol}";

            lblTotalSocios.Text = "Total socios activos: 178";
            lblTotalActividades.Text = "Total actividades: 09";

            dgvUltimosPagos.Rows.Add("Romina", "14/05/2024", "500,00");
            dgvUltimosPagos.Rows.Add("José", "12/05/2024", "450,00");
            dgvUltimosPagos.Rows.Add("Carolina", "10/05/2024", "590,00");
            dgvUltimosPagos.Rows.Add("Florencia", "18/05/2024", "590,00");

            var botones = new[]
            {
                btnSocios, btnActividades, btnPagos, btnInscripciones,
                btnUsuarios, btnReportes, btnCerrarSesion
            };

            foreach (var btn in botones)
            {
                btn.Dock = DockStyle.Top;
                btn.Height = 40;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                btn.BackColor = Color.White;
            }

            btnCerrarSesion.BackColor = Color.SteelBlue;
            btnCerrarSesion.ForeColor = Color.White;
        }

        private void dgvUltimosPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSocios_Click(object sender, EventArgs e)
        {
            var sociosForm = new SociosForm();
            sociosForm.ShowDialog();
        }

        private void btnActividades_Click(object sender, EventArgs e)
        {
            var actividadesForm = new ActividadesForm();
            actividadesForm.ShowDialog();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            PagosForm pagosForm = new PagosForm();
            pagosForm.ShowDialog();
        }

        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            InscripcionesForm inscripcionesForm = new InscripcionesForm();
            inscripcionesForm.ShowDialog();
        }


        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            UsuariosForm form = new UsuariosForm();
            form.Show();
        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
         //despedida 
            MessageBox.Show($"Adiós, nos vemos pronto {_nombreUsuario} 👋",
                            "Cerrar sesión",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}