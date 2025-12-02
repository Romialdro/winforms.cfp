namespace WinFormsApp_club.Forms
{
    partial class UsuariosForm
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
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(35, 35);
            label1.Font = new Font("Segoe UI", 14, FontStyle.Bold); 
            label1.ForeColor = Color.DarkSlateBlue;                
            label1.Text = "Usuarios ";                           

            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(217, 69);
            label2.Text = "Nombre";

            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(521, 69);
            label3.Text = "Correo";

            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(217, 162);
            label4.Text = "Password";

            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(521, 162);
            label5.Text = "Tipo";

            button1.BackColor = System.Drawing.SystemColors.Highlight;
            button1.Location = new System.Drawing.Point(521, 258);
            button1.Size = new System.Drawing.Size(94, 29);
            button1.Text = "+Crear";

            button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            button2.Location = new System.Drawing.Point(653, 258);
            button2.Size = new System.Drawing.Size(94, 29);
            button2.Text = "Limpiar";

            textBox1.Location = new System.Drawing.Point(217, 92);
            textBox1.Size = new System.Drawing.Size(226, 27);

            textBox2.Location = new System.Drawing.Point(521, 92);
            textBox2.Size = new System.Drawing.Size(223, 27);

            textBox3.Location = new System.Drawing.Point(217, 185);
            textBox3.Size = new System.Drawing.Size(226, 27);

            comboBox1.Location = new System.Drawing.Point(518, 185);
            comboBox1.Size = new System.Drawing.Size(226, 28);

            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(35, 329);
            dataGridView1.Size = new System.Drawing.Size(712, 168);

            ClientSize = new System.Drawing.Size(800, 523);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Text = "Usuarios 👥";

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
    }
}
