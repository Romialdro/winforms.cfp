using System;
using System.Windows.Forms;

namespace WinFormsApp_club
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada 
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Forms.LoginForm()); 
        }
    }
}