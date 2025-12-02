namespace WinFormsApp_club.Forms
{
    partial class VerSociosForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            comboBox2 = new ComboBox();
            textBox1 = new TextBox();
            label3 = new Label();
            dgvSocios = new DataGridView();
            button3 = new Button();
            button4 = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(154, 40);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(197, 28);
            comboBox1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 43);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 10;
            label1.Text = "Estado Socio";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.Location = new Point(395, 33);
            button1.Name = "button1";
            button1.Size = new Size(165, 40);
            button1.TabIndex = 9;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(598, 33);
            button2.Name = "button2";
            button2.Size = new Size(165, 40);
            button2.TabIndex = 8;
            button2.Text = "Limpiar";
            button2.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 115);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 7;
            label2.Text = "Filtrar por:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(159, 111);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(192, 28);
            comboBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(563, 112);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 27);
            textBox1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(400, 118);
            label3.Name = "label3";
            label3.Size = new Size(142, 20);
            label3.TabIndex = 4;
            label3.Text = "Ingresar parámetros";
            // 
            // dgvSocios
            // 
            dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSocios.Location = new Point(38, 210);
            dgvSocios.Name = "dgvSocios";
            dgvSocios.RowHeadersWidth = 51;
            dgvSocios.Size = new Size(719, 435);
            dgvSocios.TabIndex = 3;
            dgvSocios.CellContentClick += dgvSocios_CellContentClick;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.Location = new Point(649, 171);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "Eliminar";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Yellow;
            button4.Location = new Point(549, 171);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 1;
            button4.Text = "Editar";
            button4.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 175);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 0;
            label4.Text = "Lista socios";
            // 
            // VerSociosForm
            // 
            ClientSize = new Size(800, 666);
            Controls.Add(label4);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(dgvSocios);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "VerSociosForm";
            Text = "Ver Socios 👥";
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Label label2;
        private ComboBox comboBox2;
        private TextBox textBox1;
        private Label label3;
        private DataGridView dgvSocios;
        private Button button3;
        private Button button4;
        private Label label4;
    }
}
