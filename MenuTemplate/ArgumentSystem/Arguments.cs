using RegistryTime.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using ModelLayer;
using BussinesLayer;

namespace RegistryTime.ArgumentSystem
{
    public class Arguments
    {
        public String core ="enuTemplate.ArgumentSystem.Arguments";

        /// <summary>
        /// Argumentos PARA ACCESO RAPIDO
        /// 1.- USUARIO
        /// 2.- PASSWORD
        /// 3.- PANTALLA
        /// </summary>
        /// <param name="arguments"></param>
        public void Verification(String [] ArgumentsList)
        {
            try
            {
                if (ArgumentsList.Length > 2 && VerificationUser(ArgumentsList[0], ArgumentsList[1]) == true)
                {
                    switch (ArgumentsList[2])
                    {
                        case "FMCX":
                            //Application.Run(new cFMCX000010());
                            break;
                        case "RTEM":
                            Application.Run(new RegistryTime.Forms.CFRT140010());
                            break;
                        case "RTLG":
                            Application.Run(new RegistryTime.Forms.cFRT150010());
                            break;
                        case "RTAL":
                            Application.Run(new Alerts.cFAT100010("Informacion", "Texto descripcion", MessageBoxIcon.Information));
                            break;
                        case "test":
                            Application.Run(new cMRT1000101());
                            break;
                        case "FCGL":
                            Application.Run(new Forms.cFMCG100010());
                            break;
                        case "CHECK":
                            ProcessMigrate(Convert.ToDateTime(ArgumentsList[3]), Convert.ToDateTime(ArgumentsList[4]));
                            //Application.Run(new Forms.TestCheck());
                            //MessageBox.Show("migrac")
                            break;
                        case "FCRP":
                            Application.Run(new Forms.Reports.cFMRP100010());
                            break;
                        default:
                            MessageBox.Show("Errror");
                            break;
                    }
                }
                else
                {
                    Alerts.cFAT100010 Alert = new Alerts.cFAT100010("Error", "El USUARIO O CONTRASEÑA SON INCORRECTOS", MessageBoxIcon.Error);
                    Alert.ShowDialog();
                }
            }catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.Verification: {1}", core, ex));
            }
        }

        public void ProcessMigrate(DateTime Inicio , DateTime Fin)
        {
            CheckInoursBLL CheckInoursBLL = new CheckInoursBLL();
            CheckInoursBLL.Migrate(Inicio, Fin);
        }

        public Boolean VerificationUser(String USER , String PASSWORD)
        {
            try
            {
                UsersBLL UsersBLL = new UsersBLL();
                UsersML UsersML = new UsersML() { UserName = USER, Password = PASSWORD };
                GlobalBLL.userML = UsersBLL.IsUser(UsersML);
                if (GlobalBLL.userML == null)
                    return false;
                else
                    return true;

                

            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.VerificationUser: {1}", core, ex));
            }
        }
    }
}
