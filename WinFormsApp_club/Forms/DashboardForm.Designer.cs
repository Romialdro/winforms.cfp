using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_club.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelMenu = new Panel();
            btnCerrarSesion = new Button();
            btnReportes = new Button();
            btnUsuarios = new Button();
            btnInscripciones = new Button();
            btnPagos = new Button();
            btnActividades = new Button();
            btnSocios = new Button();
            panelContenido = new Panel();
            lblBienvenida = new Label();
            lblTotalSocios = new Label();
            lblTotalActividades = new Label();
            lblUltimosPagos = new Label();
            dgvUltimosPagos = new DataGridView();
            colSocio = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colMonto = new DataGridViewTextBoxColumn();

            panelMenu.SuspendLayout();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUltimosPagos).BeginInit();
            SuspendLayout();

            this.BackColor = Color.White;
            this.ClientSize = new Size(1000, 600);
            this.Text = "Panel principal";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            panelMenu.BackColor = Color.FromArgb(220, 235, 250);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Width = 150;
            panelMenu.Controls.AddRange(new Control[] {
                btnCerrarSesion, btnReportes, btnUsuarios,
                btnInscripciones, btnPagos, btnActividades, btnSocios
            });

            btnSocios.Text = "Socios";
            btnSocios.Click += new EventHandler(btnSocios_Click);
            btnActividades.Text = "Actividades";
            btnActividades.Click += new EventHandler(btnActividades_Click);
            btnPagos.Text = "Pagos";
            btnPagos.Click += new EventHandler(btnPagos_Click);
            btnInscripciones.Text = "Inscripciones";
            btnInscripciones.Click += new EventHandler(btnInscripciones_Click);
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.Click += new EventHandler(btnUsuarios_Click);


            btnReportes.Text = "Reportes";
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.Click += new EventHandler(btnCerrarSesion_Click);

            panelContenido.BackColor = Color.White;
            panelContenido.Dock = DockStyle.Fill;

            lblBienvenida.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBienvenida.Location = new Point(20, 20);
            lblBienvenida.Size = new Size(400, 60);
            lblBienvenida.Text = "Bienvenida";

            lblTotalSocios.Font = new Font("Segoe UI", 10F);
            lblTotalSocios.Location = new Point(20, 90);
            lblTotalSocios.Size = new Size(250, 25);

            lblTotalActividades.Font = new Font("Segoe UI", 10F);
            lblTotalActividades.Location = new Point(20, 120);
            lblTotalActividades.Size = new Size(250, 25);

            lblUltimosPagos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUltimosPagos.Location = new Point(20, 160);
            lblUltimosPagos.Size = new Size(200, 25);
            lblUltimosPagos.Text = "Últimos pagos";

            dgvUltimosPagos.Location = new Point(20, 190);
            dgvUltimosPagos.Size = new Size(600, 200);
            dgvUltimosPagos.BackgroundColor = Color.White;
            dgvUltimosPagos.BorderStyle = BorderStyle.None;
            dgvUltimosPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUltimosPagos.Columns.AddRange(new DataGridViewColumn[] {
                colSocio, colFecha, colMonto
            });

            colSocio.HeaderText = "Socio";
            colSocio.Width = 200;
            colFecha.HeaderText = "Fecha";
            colFecha.Width = 150;
            colMonto.HeaderText = "Monto";
            colMonto.Width = 150;

            panelContenido.Controls.Add(lblBienvenida);
            panelContenido.Controls.Add(lblTotalSocios);
            panelContenido.Controls.Add(lblTotalActividades);
            panelContenido.Controls.Add(lblUltimosPagos);
            panelContenido.Controls.Add(dgvUltimosPagos);

            Controls.Add(panelContenido);
            Controls.Add(panelMenu);

            panelMenu.ResumeLayout(false);
            panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUltimosPagos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panelContenido;
        private Button btnSocios;
        private Button btnActividades;
        private Button btnPagos;
        private Button btnInscripciones;
        private Button btnUsuarios;
        private Button btnReportes;
        private Button btnCerrarSesion;
        private Label lblBienvenida;
        private Label lblTotalSocios;
        private Label lblTotalActividades;
        private Label lblUltimosPagos;
        private DataGridView dgvUltimosPagos;
        private DataGridViewTextBoxColumn colSocio;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colMonto;
    }
}