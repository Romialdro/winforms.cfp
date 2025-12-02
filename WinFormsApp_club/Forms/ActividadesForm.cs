using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp_club.Utilidades;
using WinFormsApp_club.Utilities;

namespace WinFormsApp_club.Forms
{
    public partial class ActividadesForm : FormBase
    {
        private readonly string connectionString = "Server=localhost;Database=club_app;Uid=root;Pwd=;";
        private int? actividadIdSeleccionada = null;

        // ==================================================
        // CONSTRUCTORES
        // ==================================================
        public ActividadesForm()
        {
            InitializeComponent();
            if (!IsInDesignMode())
                Inicializar();
        }

        public ActividadesForm(int id)
        {
            InitializeComponent();
            if (!IsInDesignMode())
                Inicializar();

            actividadIdSeleccionada = id;
            CargarActividadPorID(id);
            SeleccionarNodoEnTree(id);
        }

        private bool IsInDesignMode()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime) || this.DesignMode;
        }

        // ==================================================
        // INICIALIZACIÓN
        // ==================================================
        private void Inicializar()
        {
            ButtonFactory.AgregarBotonVolver(this,
                () => Application.OpenForms.OfType<Form>().FirstOrDefault(f => f.GetType().Name == "DashboardForm"));

            CargarCombos();
            ConfigurarTree();
            CargarTreeDesdeDB();
            ActivarEventos();
            LimpiarFormulario();
        }

        private void ActivarEventos()
        {
            treeView1.AfterSelect -= TreeView1_AfterSelect;
            treeView1.AfterSelect += TreeView1_AfterSelect;

            button2.Click -= ButtonAgregar_Click;
            button2.Click += ButtonAgregar_Click;

            button5.Click -= ButtonEditar_Click;
            button5.Click += ButtonEditar_Click;

            button3.Click -= ButtonEliminar_Click;
            button3.Click += ButtonEliminar_Click;

            button6.Click -= ButtonLimpiar_Click;
            button6.Click += ButtonLimpiar_Click;

            button4.Click -= ButtonSubirImagen_Click;
            button4.Click += ButtonSubirImagen_Click;
        }

        // ==================================================
        // COMBOS
        // ==================================================
        private void CargarCombos()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            for (int i = 0; i <= 99; i++)
            {
                comboBox1.Items.Add(i.ToString());
                comboBox2.Items.Add(i.ToString());
            }

            comboBox5.Items.Clear();
            comboBox5.Items.AddRange(new object[] { "libre", "grupal", "individual", "online" });

            comboBox3.Items.Clear(); 

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                using var cmd = new MySqlCommand("SELECT id, nombre FROM profesores ORDER BY nombre", conn);
                using var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    comboBox3.Items.Add(new ComboItem
                    {
                        Text = rdr.GetString("nombre"),
                        Value = rdr.GetInt32("id")
                    });
                }
            }
            catch { }
        }

        // ==================================================
        // TREE
        // ==================================================
        private void ConfigurarTree()
        {
            treeView1.Nodes.Clear();
            treeView1.ImageList = new ImageList();
        }

        private void CargarTreeDesdeDB()
        {
            treeView1.Nodes.Clear();

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = @"SELECT id, nombre, categoria 
                             FROM actividades 
                             WHERE estado='activa'
                             ORDER BY categoria, nombre";

                using var cmd = new MySqlCommand(q, conn);
                using var rdr = cmd.ExecuteReader();

                var categorias = new System.Collections.Generic.Dictionary<string, TreeNode>();

                while (rdr.Read())
                {
                    int id = rdr.GetInt32("id");
                    string nombre = rdr.GetString("nombre");
                    string categoria = rdr.IsDBNull("categoria") ? "Sin categoría" : rdr.GetString("categoria");

                    if (!categorias.ContainsKey(categoria))
                    {
                        var nodeCat = new TreeNode(categoria) { Tag = null };
                        categorias[categoria] = nodeCat;
                        treeView1.Nodes.Add(nodeCat);
                    }

                    categorias[categoria].Nodes.Add(new TreeNode(nombre) { Tag = id });
                }

                if (treeView1.Nodes.Count > 0)
                    treeView1.Nodes[0].Expand();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando actividades:\n" + ex.Message);
            }
        }

        // ==================================================
        // SELECCIÓN EN TREE
        // ==================================================
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            actividadIdSeleccionada = e.Node?.Tag as int?;

            if (actividadIdSeleccionada.HasValue)
                CargarActividadPorID(actividadIdSeleccionada.Value);
        }

        // ==================================================
        // CARGAR ACTIVIDAD POR ID
        // ==================================================
        private void CargarActividadPorID(int id)
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = @"SELECT id, nombre, descripcion, edad_min, edad_max, profesor_id, horario, modalidad, precio, categoria
                             FROM actividades
                             WHERE id=@id";

                using var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", id);

                using var rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    textBox1.Text = rdr.GetString("nombre");
                    textBox2.Text = rdr.GetString("descripcion");

                    comboBox1.Text = rdr["edad_min"].ToString();
                    comboBox2.Text = rdr["edad_max"].ToString();

                    int profID = rdr.IsDBNull("profesor_id") ? 0 : rdr.GetInt32("profesor_id");
                    SelectComboValue(comboBox3, profID);

                    comboBox4.Text = rdr["horario"].ToString();
                    comboBox5.Text = rdr["modalidad"].ToString();
                    textBox4.Text = rdr["precio"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar actividad:\n" + ex.Message);
            }
        }

        private void SelectComboValue(ComboBox cb, int value)
        {
            foreach (var item in cb.Items)
            {
                if (item is ComboItem ci && (int)ci.Value == value)
                {
                    cb.SelectedItem = ci;
                    return;
                }
            }
            cb.SelectedIndex = -1;
        }

        // ==================================================
        // AGREGAR
        // ==================================================
        private bool ValidarFormulario(out string msg)
        {
            msg = "";
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                msg = "Ingrese un nombre.";
                return false;
            }

            if (!decimal.TryParse(textBox4.Text, out _))
            {
                msg = "Ingrese un precio válido.";
                return false;
            }

            return true;
        }

        private void ButtonAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario(out string msg))
            {
                MessageBox.Show(msg);
                return;
            }

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string categoria = ObtenerCategoriaSeleccionada();

                string q = @"INSERT INTO actividades
                             (nombre, descripcion, edad_min, edad_max, profesor_id, horario, modalidad, precio, categoria, estado)
                             VALUES (@n,@d,@emin,@emax,@p,@h,@m,@precio,@c,'activa')";

                using var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@n", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@d", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@emin", ToIntOrNull(comboBox1.Text));
                cmd.Parameters.AddWithValue("@emax", ToIntOrNull(comboBox2.Text));
                cmd.Parameters.AddWithValue("@p", comboBox3.SelectedItem is ComboItem ci ? ci.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@h", comboBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@m", comboBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@precio", decimal.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@c", categoria);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Actividad agregada ✔");
                CargarTreeDesdeDB();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar:\n" + ex.Message);
            }
        }

        // ==================================================
        // EDITAR (CON FIX)
        // ==================================================
        private void ButtonEditar_Click(object sender, EventArgs e)
        {
            if (!actividadIdSeleccionada.HasValue)
            {
                MessageBox.Show("Seleccione una actividad.");
                return;
            }

            if (!ValidarFormulario(out string msg))
            {
                MessageBox.Show(msg);
                return;
            }

            int idActual = actividadIdSeleccionada.Value; 

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = @"UPDATE actividades SET
                                nombre=@n, descripcion=@d, edad_min=@emin, edad_max=@emax,
                                profesor_id=@p, horario=@h, modalidad=@m, precio=@precio
                             WHERE id=@id";

                using var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@n", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@d", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@emin", ToIntOrNull(comboBox1.Text));
                cmd.Parameters.AddWithValue("@emax", ToIntOrNull(comboBox2.Text));
                cmd.Parameters.AddWithValue("@p", comboBox3.SelectedItem is ComboItem ci ? ci.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@h", comboBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@m", comboBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@precio", decimal.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@id", idActual);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Actividad editada correctamente.");

                
                CargarTreeDesdeDB();
                SeleccionarNodoEnTree(idActual);
                CargarActividadPorID(idActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar:\n" + ex.Message);
            }
        }

        
        private void SeleccionarNodoEnTree(int id)
        {
            foreach (TreeNode cat in treeView1.Nodes)
            {
                foreach (TreeNode act in cat.Nodes)
                {
                    if (act.Tag is int actId && actId == id)
                    {
                        treeView1.SelectedNode = act;
                        act.EnsureVisible();
                        return;
                    }
                }
            }
        }

        // ==================================================
        // ELIMINAR
        // ==================================================
        private void ButtonEliminar_Click(object sender, EventArgs e)
        {
            if (!actividadIdSeleccionada.HasValue)
            {
                MessageBox.Show("Seleccione una actividad.");
                return;
            }

            if (MessageBox.Show("¿Marcar como inactiva?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string q = "UPDATE actividades SET estado='inactiva' WHERE id=@id";

                using var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", actividadIdSeleccionada.Value);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Actividad eliminada ✔");
                CargarTreeDesdeDB();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error eliminando:\n" + ex.Message);
            }
        }

        // ==================================================
        // AUXILIARES
        // ==================================================
        private object ToIntOrNull(string s)
            => int.TryParse(s, out int v) ? (object)v : DBNull.Value;

        private string ObtenerCategoriaSeleccionada()
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag == null)
                    return treeView1.SelectedNode.Text;

                if (treeView1.SelectedNode.Parent != null)
                    return treeView1.SelectedNode.Parent.Text;
            }
            return "Sin categoría";
        }

        private void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            actividadIdSeleccionada = null;
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            textBox4.Clear();
            pictureBox1.Image = null;
        }

        private void ButtonSubirImagen_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog { Filter = "Imagen|*.jpg;*.png" };
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(ofd.FileName);
        }

        private class ComboItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString() => Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ver = new VerActividadesForm();
            ver.ShowDialog();
        }
    }
}
