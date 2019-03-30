using RegistryTime.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistryTime
{
    static class Program
    {
        private const String FILENAME = "ConnectionString.config";
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                if (System.IO.File.Exists(FILENAME))
                {
                    ArgumentSystem.Arguments arguments = new ArgumentSystem.Arguments();
                    if (args.Length == 0)
                    {
                        if (arguments.ValidLicense())
                        {
                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);
                            Application.Run(new cMRT100010());
                        }
                    }
                    else
                    {
                        arguments.Verification(args);
                    }
                }
                else
                {
                    Alerts.cFAT100010 alrt = new Alerts.cFAT100010("Información", "No se ha encontrado la conexión a la Base de datos", MessageBoxIcon.Error);
                    alrt.ShowDialog();

                    //ArgumentSystem.Applications execApp = new ArgumentSystem.Applications();
                    //execApp.execute("Connection.exe", "SERVER");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(String.Format("Main: {0}", ex.Message), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
