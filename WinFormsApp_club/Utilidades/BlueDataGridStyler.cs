using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_club.Utilities
{
    public class BlueDataGridStyler : IDataGridStyler
    {
        public void AplicarEstilo(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.LightGray;
            dgv.EnableHeadersVisualStyles = false;

            // === ENCABEZADO ===
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 32;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // === CELDAS ===
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            // === FILAS ALTERNADAS ===
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 250, 255);

            // === AJUSTES ===
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 26;

            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
