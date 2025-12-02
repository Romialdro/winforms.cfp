using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp_club.Utilities;

namespace WinFormsApp_club.Forms
{
    public partial class SociosForm : FormBase
    {
        string connectionString = "Server=localhost;Database=club_app;Uid=root;Pwd=;";
        private int? socioId = null;

        // === Constructor para ALTA ===
        public SociosForm()
        {
            InitializeComponent();
            CargarCombos();
        }

        // === Constructor para EDITAR ===
        public SociosForm(int id)
        {
            InitializeComponent();
            socioId = id;
            CargarCombos();
            CargarSocioPorId(id);
        }


        private void CargarCombos()
        {
            comboBox3.Items.AddRange(new object[] { "F", "M", "Otro" });

            comboBox4.Items.AddRange(new object[] {
                "Padre","Madre","Hermano/a","Pareja","Tutor","Otro"
            });

            comboBox6.Items.AddRange(new object[] {
                "ninguno","descuento","vitalicio"
            });

            comboBox5.Items.AddRange(new object[] {
                "Ninguna","Alergias","Asma","Cardíaco","Otros"
            });

            comboBox2.Items.Clear();
            for (int i = 1; i <= 99; i++)
                comboBox2.Items.Add(i.ToString());
        }

        private void CargarSocioPorId(int id)
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string query = "SELECT * FROM socios WHERE id=@id";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                using var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    textBox1.Text = dr["nombre_apellido"].ToString();
                    textBox2.Text = dr["dni"].ToString();
                    textBox3.Text = dr["direccion"].ToString();
                    comboBox1.Text = dr["localidad"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(dr["fecha_nac"]);
                    comboBox3.Text = dr["sexo"].ToString();
                    textBox5.Text = dr["telefono"].ToString();
                    comboBox4.Text = dr["relacion"].ToString();
                    textBox6.Text = dr["mail"].ToString();
                    dateTimePicker2.Value = Convert.ToDateTime(dr["certificado_vencimiento"]);
                    comboBox5.Text = dr["observaciones_salud"].ToString();
                    comboBox6.Text = dr["beneficios"].ToString();
                    checkBox1.Checked = dr["activo"].ToString() == "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando socio:\n" + ex.Message);
            }
        }

        private void GuardarSocio()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string query = @"INSERT INTO socios 
                (nombre_apellido, dni, direccion, localidad, fecha_nac, sexo, telefono, relacion, mail,
                 certificado_vencimiento, observaciones_salud, beneficios, activo, estado)
                VALUES (@nombre,@dni,@dir,@loc,@fecha,@sexo,@tel,@rel,@mail,
                        @cert,@obs,@ben,@act,'activo');";

                using var cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
                cmd.Parameters.AddWithValue("@dni", textBox2.Text);
                cmd.Parameters.AddWithValue("@dir", textBox3.Text);
                cmd.Parameters.AddWithValue("@loc", comboBox1.Text);
                cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@sexo", comboBox3.Text);
                cmd.Parameters.AddWithValue("@tel", textBox5.Text);
                cmd.Parameters.AddWithValue("@rel", comboBox4.Text);
                cmd.Parameters.AddWithValue("@mail", textBox6.Text);
                cmd.Parameters.AddWithValue("@cert", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@obs", comboBox5.Text);
                cmd.Parameters.AddWithValue("@ben", comboBox6.Text);
                cmd.Parameters.AddWithValue("@act", checkBox1.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Socio guardado ✔");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardando:\n" + ex.Message);
            }
        }

        private void EditarSocio()
        {
            if (socioId == null)
            {
                MessageBox.Show("No hay socio cargado para editar.");
                return;
            }

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string query = @"UPDATE socios SET
                    nombre_apellido=@nombre, dni=@dni, direccion=@dir, localidad=@loc, 
                    fecha_nac=@fecha, sexo=@sexo, telefono=@tel, relacion=@rel, 
                    mail=@mail, certificado_vencimiento=@cert, observaciones_salud=@obs, 
                    beneficios=@ben, activo=@act
                    WHERE id=@id";

                using var cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", socioId);
                cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
                cmd.Parameters.AddWithValue("@dni", textBox2.Text);
                cmd.Parameters.AddWithValue("@dir", textBox3.Text);
                cmd.Parameters.AddWithValue("@loc", comboBox1.Text);
                cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@sexo", comboBox3.Text);
                cmd.Parameters.AddWithValue("@tel", textBox5.Text);
                cmd.Parameters.AddWithValue("@rel", comboBox4.Text);
                cmd.Parameters.AddWithValue("@mail", textBox6.Text);
                cmd.Parameters.AddWithValue("@cert", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@obs", comboBox5.Text);
                cmd.Parameters.AddWithValue("@ben", comboBox6.Text);
                cmd.Parameters.AddWithValue("@act", checkBox1.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Socio actualizado ✔");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error editando:\n" + ex.Message);
            }
        }

        private void EliminarSocio()
        {
            if (socioId == null)
            {
                MessageBox.Show("No hay socio cargado para eliminar.");
                return;
            }

            if (MessageBox.Show("¿Eliminar socio?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string query = "UPDATE socios SET activo=0, estado='inactivo' WHERE id=@id";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", socioId);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Socio eliminado ✔");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error eliminando:\n" + ex.Message);
            }
        }

        // === BOTONES ===

        private void button3_Click(object sender, EventArgs e)
        {
            if (socioId == null) GuardarSocio();
            else EditarSocio();
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            EditarSocio();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EliminarSocio();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var f = new VerSociosForm();
            f.ShowDialog();
        }

        //button subir imagen conectado a designer, solo por pantalla no sube a db***VER
        private void ButtonSubirImagen_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog { Filter = "Imagen|*.jpg;*.png" };
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(ofd.FileName);
        }
    }

    }
