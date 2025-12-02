namespace WinFormsApp_club.Forms
{
    partial class InscripcionesForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            Inscribir = new Button();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            textBox1 = new TextBox();
            label5 = new Label();
            checkBox1 = new CheckBox();
            label7 = new Label();
            label8 = new Label();
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            label6 = new Label();
            dtpFecha = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 51);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 81);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 1;
            label2.Text = "Socio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(463, 81);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 2;
            label3.Text = "Actividad";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(79, 164);
            label4.Name = "label4";
            label4.Size = new Size(104, 20);
            label4.TabIndex = 3;
            label4.Text = "Monto abonar";
            // 
            // Inscribir
            // 
            Inscribir.BackColor = SystemColors.Highlight;
            Inscribir.Location = new Point(81, 324);
            Inscribir.Name = "Inscribir";
            Inscribir.Size = new Size(160, 29);
            Inscribir.TabIndex = 4;
            Inscribir.Text = "+Inscribir";
            Inscribir.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(78, 113);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(334, 28);
            comboBox1.TabIndex = 5;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(463, 113);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(278, 28);
            comboBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(81, 197);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 27);
            textBox1.TabIndex = 7;
            textBox1.ReadOnly = true; 
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(300, 197);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(150, 27);
            dtpFecha.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Yellow;
            label5.Location = new Point(463, 204);
            label5.Name = "label5";
            label5.Size = new Size(173, 20);
            label5.TabIndex = 8;
            label5.Text = "Apto fisico vigente hasta";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(463, 254);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(207, 24);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Otorgar plazo Excepcional";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(58, 379);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(360, 270);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 14;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Location = new Point(423, 399);
            button1.Name = "button1";
            button1.Size = new Size(160, 29);
            button1.TabIndex = 15;
            button1.Text = "Eliminar";
            button1.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaption;
            button3.Location = new Point(79, 359);
            button3.Name = "button3";
            button3.Size = new Size(160, 29);
            button3.TabIndex = 17;
            button3.Text = "Limpiar";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Yellow;
            button4.Location = new Point(607, 399);
            button4.Name = "button4";
            button4.Size = new Size(160, 29);
            button4.TabIndex = 18;
            button4.Text = "Editar";
            button4.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(74, 457);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(704, 188);
            dataGridView1.TabIndex = 19;        
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(73, 414);
            label6.Name = "label6";
            label6.Size = new Size(127, 20);
            label6.TabIndex = 20;
            label6.Text = "Actividad del Socio";
            // 
            // InscripcionesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 682);
            Controls.Add(dtpFecha);
            Controls.Add(label6);
            Controls.Add(dataGridView1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(checkBox1);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(Inscribir);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "InscripcionesForm";
            Text = "Inscripciones 📝";
            Load += InscripcionesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button Inscribir;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private TextBox textBox1;
        private Label label5;
        private CheckBox checkBox1;
        private Label label7;
        private Label label8;
        private Button button1;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView1;
        private Label label6;
        private DateTimePicker dtpFecha;
    }
}
