namespace WinFormsApp_club.Forms
{
    partial class VerActividadesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Actividad";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(130, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(243, 28);
            this.comboBox1.TabIndex = 1;
            // 
            // button1 - Buscar
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(417, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2 - Limpiar
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Location = new System.Drawing.Point(583, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label2 - Buscar por
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Buscar por";
            // 
            // comboBox2 - Filtro
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(130, 104);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(243, 28);
            this.comboBox2.TabIndex = 5;
            // 
            // label3 - Texto filtro
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ingresar parámetros";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(565, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 27);
            this.textBox1.TabIndex = 7;
            // 
            // button3 - Eliminar
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(417, 217);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 29);
            this.button3.TabIndex = 8;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4 - Editar
            // 
            this.button4.BackColor = System.Drawing.Color.Yellow;
            this.button4.Location = new System.Drawing.Point(583, 217);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(160, 29);
            this.button4.TabIndex = 9;
            this.button4.Text = "Editar";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // label4 - Vista completa
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Vista completa actividades";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(33, 314);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(725, 312);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;

            // ========= FIX CRÍTICO =========
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.Columns.Clear();

            this.dataGridView1.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn()
            {
                Name = "id",
                HeaderText = "ID",
                DataPropertyName = "id",
                Width = 60
            });

            this.dataGridView1.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn()
            {
                Name = "nombre",
                HeaderText = "Nombre",
                DataPropertyName = "nombre",
                Width = 260
            });

            this.dataGridView1.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn()
            {
                Name = "categoria",
                HeaderText = "Categoría",
                DataPropertyName = "categoria",
                Width = 160
            });

            this.dataGridView1.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn()
            {
                Name = "precio",
                HeaderText = "Precio",
                DataPropertyName = "precio",
                Width = 120
            });
            // =================================

            // 
            // VerActividadesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.ClientSize = new System.Drawing.Size(800, 670);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "VerActividadesForm";
            this.Text = "Ver Actividades 🎯";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
