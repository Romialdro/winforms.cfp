namespace WinFormsApp_club.Forms
{
    partial class PagosForm
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
            numericUpDown1 = new NumericUpDown();
            dateTimePicker1 = new DateTimePicker();
            Socio = new Label();
            label2 = new Label();
            label1 = new Label();
            checkBox1 = new CheckBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label4 = new Label();
            button5 = new Button();
            button6 = new Button();
            label5 = new Label();
            button8 = new Button();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            checkBox2 = new CheckBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(135, 26);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(135, 75);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(483, 77);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 2;
            // 
            // Socio
            // 
            Socio.AutoSize = true;
            Socio.Location = new Point(28, 29);
            Socio.Name = "Socio";
            Socio.Size = new Size(50, 20);
            Socio.TabIndex = 3;
            Socio.Text = "Socio ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 77);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 4;
            label2.Text = "Monto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(374, 77);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 5;
            label1.Text = "Vencimiento";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(135, 126);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(18, 17);
            checkBox1.TabIndex = 7;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 123);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 8;
            label3.Text = "Pagado";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.Location = new Point(479, 29);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 9;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.Location = new Point(483, 141);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 10;
            button2.Text = "Registrar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(639, 141);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 11;
            button3.Text = "Actualizar";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.Highlight;
            button4.Location = new Point(639, 29);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 12;
            button4.Text = "Limpiar";
            button4.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 189);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 13;
            label4.Text = "Factura";
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ActiveCaption;
            button5.Location = new Point(149, 189);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 14;
            button5.Text = "Descargar";
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.ActiveCaption;
            button6.Location = new Point(300, 189);
            button6.Name = "button6";
            button6.Size = new Size(156, 29);
            button6.TabIndex = 15;
            button6.Text = "Enviar por Mail";
            button6.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 300);
            label5.Name = "label5";
            label5.Size = new Size(136, 20);
            label5.TabIndex = 17;
            label5.Text = "Vista previa factura";
            // 
            // button8
            // 
            button8.BackColor = SystemColors.Highlight;
            button8.Location = new Point(234, 296);
            button8.Name = "button8";
            button8.Size = new Size(173, 29);
            button8.TabIndex = 18;
            button8.Text = "Ver preview";
            button8.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 331);
            label6.Name = "label6";
            label6.Size = new Size(188, 20);
            label6.TabIndex = 19;
            label6.Text = "Tabla de pagos registrados";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(34, 375);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(754, 123);
            dataGridView1.TabIndex = 20;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(560, 194);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(173, 24);
            checkBox2.TabIndex = 21;
            checkBox2.Text = "Generar Link de pago";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(580, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(208, 27);
            textBox1.TabIndex = 22;
            // 
            // PagosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 520);
            Controls.Add(textBox1);
            Controls.Add(checkBox2);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            Controls.Add(button8);
            Controls.Add(label5);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(label4);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(checkBox1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(Socio);
            Controls.Add(dateTimePicker1);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBox1);
            Name = "PagosForm";
            Text = "Pagos 💳";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label Socio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
