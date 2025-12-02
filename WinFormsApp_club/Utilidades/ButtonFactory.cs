using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp_club.Utilidades;

namespace WinFormsApp_club.Utilidades
{
    public static class ButtonFactory
    {
        public static void AgregarBotonVolver(Form form, Func<Form> crearFormDestino)
        {
            var btn = new Button
            {
                Text = "Volver",
                BackColor = Color.LightSteelBlue,
                Size = new Size(100, 35)
            };

            
            btn.Location = new Point(
                form.ClientSize.Width - btn.Width - 10, 
                10                                      
            );

           
            form.Resize += (s, e) =>
            {
                btn.Location = new Point(
                    form.ClientSize.Width - btn.Width - 10,
                    10
                );
            };

            btn.Click += (s, e) =>
            {
                try
                {
                    var destino = crearFormDestino?.Invoke();
                    if (destino == null) return;
                    destino.Show();
                    form.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir la pantalla destino:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            form.Controls.Add(btn);
        }
    }
}

//-------Implementación de boton-------//
//ButtonFactory.AgregarBotonVolver(this,
               //() => Application.OpenForms.OfType<Form>().FirstOrDefault(f => f.GetType().Name == "DashboardForm"));