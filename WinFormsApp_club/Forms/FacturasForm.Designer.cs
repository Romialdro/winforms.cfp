namespace WinFormsApp_club.Forms
{
    partial class FacturasForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();

            lblFecha = new Label();
            lblSocio = new Label();
            lblMonto = new Label();
            lblVencimiento = new Label();
            lblLink = new Label();

            SuspendLayout();

            // Label FECHA
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(50, 50);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(124, 20);
            label1.Text = "Fecha de Emisión:";
            label1.Click += label1_Click;

            lblFecha.AutoSize = true;
            lblFecha.Location = new System.Drawing.Point(220, 50);
            lblFecha.Text = "-";

            // Label SOCIO
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(50, 100);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(128, 20);
            label2.Text = "Nombre del socio:";

            lblSocio.AutoSize = true;
            lblSocio.Location = new System.Drawing.Point(220, 100);
            lblSocio.Text = "-";

            // Label MONTO
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(50, 150);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(97, 20);
            label3.Text = "Total a pagar:";

            lblMonto.AutoSize = true;
            lblMonto.Location = new System.Drawing.Point(220, 150);
            lblMonto.Text = "-";

            // Label VENCIMIENTO
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(50, 200);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(91, 20);
            label4.Text = "Vencimiento:";

            lblVencimiento.AutoSize = true;
            lblVencimiento.Location = new System.Drawing.Point(220, 200);
            lblVencimiento.Text = "-";

            // Label LINK PAGO
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(50, 250);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(176, 20);
            label5.Text = "Link de pago generado:";

            lblLink.AutoSize = true;
            lblLink.Location = new System.Drawing.Point(220, 250);
            lblLink.MaximumSize = new System.Drawing.Size(500, 0);
            lblLink.Text = "-";

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(750, 350);

            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);

            Controls.Add(lblFecha);
            Controls.Add(lblSocio);
            Controls.Add(lblMonto);
            Controls.Add(lblVencimiento);
            Controls.Add(lblLink);

            Name = "FacturasForm";
            Text = "Factura (Vista previa)";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;

        private Label lblFecha;
        private Label lblSocio;
        private Label lblMonto;
        private Label lblVencimiento;
        private Label lblLink;
    }
}
