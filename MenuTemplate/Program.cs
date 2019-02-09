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
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                ArgumentSystem.Arguments arguments = new ArgumentSystem.Arguments();
                if(args.Length == 0)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    //Application.Run(new cFMDE100010());
                    Application.Run(new Forms.cFRT150010());
                }
                else
                {
                    arguments.Verification(args);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(String.Format("Main: {0}", ex), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
