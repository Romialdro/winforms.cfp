using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_club.Utilities
{
    public class FormBase : Form
    {
        // Uso de la interfaz requerida proyecto
        private readonly IDataGridStyler _gridStyler;

        public FormBase()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

          
            _gridStyler = new BlueDataGridStyler();

            this.Load += FormBase_Load;
        }

        private void FormBase_Load(object sender, System.EventArgs e)
        {
            AplicarEstiloATodosLosDataGrid(this);
        }

        private void AplicarEstiloATodosLosDataGrid(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is DataGridView dgv)
                {
                    _gridStyler.AplicarEstilo(dgv); 
                }

                if (c.HasChildren)
                {
                    AplicarEstiloATodosLosDataGrid(c);
                }
            }
        }
    }
}
