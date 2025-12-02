namespace WinFormsApp_club.Forms
{
    partial class ActividadesForm
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
            treeView1 = new System.Windows.Forms.TreeView();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            comboBox1 = new System.Windows.Forms.ComboBox();
            comboBox2 = new System.Windows.Forms.ComboBox();
            comboBox3 = new System.Windows.Forms.ComboBox();
            comboBox4 = new System.Windows.Forms.ComboBox();
            button4 = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            textBox4 = new System.Windows.Forms.TextBox();
            comboBox5 = new System.Windows.Forms.ComboBox();
            button5 = new System.Windows.Forms.Button();
            button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new System.Drawing.Point(12, 55);
            treeView1.Name = "treeView1";
            treeView1.Size = new System.Drawing.Size(231, 446);
            treeView1.TabIndex = 0;
            // 
            // button1 - Ver Todas 
            // 
            button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            button1.Location = new System.Drawing.Point(12, 532);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(217, 29);
            button1.TabIndex = 1;
            button1.Text = "Ver Todas";
            button1.Click += new System.EventHandler(this.button1_Click);
            button1.UseVisualStyleBackColor = false;
            // 
            // button2 - Agregar
            // 
            button2.BackColor = System.Drawing.Color.Lime;
            button2.Location = new System.Drawing.Point(12, 574);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(217, 29);
            button2.TabIndex = 2;
            button2.Text = "+ Agregar ";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3 - Eliminar
            // 
            button3.BackColor = System.Drawing.Color.Red;
            button3.Location = new System.Drawing.Point(12, 620);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(217, 29);
            button3.TabIndex = 3;
            button3.Text = "Eliminar";
            button3.UseVisualStyleBackColor = false;
            // 
            // labels & inputs
            // 
            label1.AutoSize = true; label1.Location = new System.Drawing.Point(311, 43); label1.Name = "label1"; label1.Size = new System.Drawing.Size(64, 20); label1.TabIndex = 4; label1.Text = "Nombre";
            label2.AutoSize = true; label2.Location = new System.Drawing.Point(548, 43); label2.Name = "label2"; label2.Size = new System.Drawing.Size(87, 20); label2.TabIndex = 5; label2.Text = "Descripción";
            label3.AutoSize = true; label3.Location = new System.Drawing.Point(311, 129); label3.Name = "label3"; label3.Size = new System.Drawing.Size(72, 20); label3.TabIndex = 6; label3.Text = "Edad Min";
            label4.AutoSize = true; label4.Location = new System.Drawing.Point(548, 129); label4.Name = "label4"; label4.Size = new System.Drawing.Size(75, 20); label4.TabIndex = 7; label4.Text = "Edad Max";
            label5.AutoSize = true; label5.Location = new System.Drawing.Point(311, 239); label5.Name = "label5"; label5.Size = new System.Drawing.Size(64, 20); label5.TabIndex = 8; label5.Text = "Profesor";
            label6.AutoSize = true; label6.Location = new System.Drawing.Point(548, 239); label6.Name = "label6"; label6.Size = new System.Drawing.Size(66, 20); label6.TabIndex = 9; label6.Text = "Horarios";
            label7.AutoSize = true; label7.Location = new System.Drawing.Point(311, 346); label7.Name = "label7"; label7.Size = new System.Drawing.Size(108, 20); label7.TabIndex = 10; label7.Text = "Vista Actividad";
            label9.AutoSize = true; label9.Location = new System.Drawing.Point(311, 500); label9.Name = "label9"; label9.Size = new System.Drawing.Size(50, 20); label9.TabIndex = 12; label9.Text = "Precio";
            label10.AutoSize = true; label10.Location = new System.Drawing.Point(548, 500); label10.Name = "label10"; label10.Size = new System.Drawing.Size(82, 20); label10.TabIndex = 13; label10.Text = "Modalidad";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(311, 77);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(194, 27);
            textBox1.TabIndex = 14;
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(549, 77);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(183, 27);
            textBox2.TabIndex = 15;
            // 
            // comboBox1 - edad min
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(311, 174);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(194, 28);
            comboBox1.TabIndex = 16;
            // 
            // comboBox2 - edad max
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new System.Drawing.Point(548, 174);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(183, 28);
            comboBox2.TabIndex = 17;
            // 
            // comboBox3 - profesor
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new System.Drawing.Point(311, 286);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(190, 28);
            comboBox3.TabIndex = 18;
            // 
            // comboBox4 - horarios
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new System.Drawing.Point(548, 286);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new System.Drawing.Size(183, 28);
            comboBox4.TabIndex = 19;
            // 
            // button4 - subir imagen
            // 
            button4.Location = new System.Drawing.Point(311, 402);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(190, 29);
            button4.TabIndex = 20;
            button4.Text = "Subir Imagen";
            button4.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(549, 346);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(183, 118);
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // textBox4 - precio
            // 
            textBox4.Location = new System.Drawing.Point(311, 534);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(190, 27);
            textBox4.TabIndex = 23;
            // 
            // comboBox5 - modalidad
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new System.Drawing.Point(559, 534);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new System.Drawing.Size(183, 28);
            comboBox5.TabIndex = 24;
            // 
            // button5 - editar
            // 
            button5.BackColor = System.Drawing.Color.Yellow;
            button5.Location = new System.Drawing.Point(313, 620);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(188, 29);
            button5.TabIndex = 25;
            button5.Text = "Editar";
            button5.UseVisualStyleBackColor = false;
            // 
            // button6 - limpiar
            // 
            button6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            button6.Location = new System.Drawing.Point(562, 620);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(180, 29);
            button6.TabIndex = 26;
            button6.Text = "Limpiar";
            button6.UseVisualStyleBackColor = false;
            // 
            // ActividadesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.ClientSize = new System.Drawing.Size(800, 673);
            this.Controls.Add(button6);
            this.Controls.Add(button5);
            this.Controls.Add(comboBox5);
            this.Controls.Add(textBox4);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(button4);
            this.Controls.Add(comboBox4);
            this.Controls.Add(comboBox3);
            this.Controls.Add(comboBox2);
            this.Controls.Add(comboBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(textBox1);
            this.Controls.Add(label10);
            this.Controls.Add(label9);
            this.Controls.Add(label7);
            this.Controls.Add(label6);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(button3);
            this.Controls.Add(button2);
            this.Controls.Add(button1);
            this.Controls.Add(treeView1);
            this.Name = "ActividadesForm";
            this.Text = "Actividades 🎯";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}
