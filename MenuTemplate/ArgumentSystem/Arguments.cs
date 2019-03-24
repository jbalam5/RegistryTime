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
using Connection_BLL;

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
                    if (ValidLicense())
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
                                //Application.Run(new Forms.Migrate.cFMCG100010()); Se comenta para subir cambios favor de revisar
                                break;
                            case "CHECK":
                                //DateTime Horaini = DateTime.Now;


                                if (ArgumentsList.Length > 3 && Convert.ToDateTime(ArgumentsList[4].ToString()) > Convert.ToDateTime(ArgumentsList[3].ToString()))
                                    ProcessMigrate(Convert.ToDateTime(ArgumentsList[3]), Convert.ToDateTime(ArgumentsList[4]), Convert.ToInt32(ArgumentsList[5]));
                                ////Application.Run(new Forms.TestCheck());


                                //DateTime HoraiF = DateTime.Now;
                                //MessageBox.Show((HoraiF - Horaini).ToString());

                                //Migrate2

                                break;
                            case "FCRP":
                                Application.Run(new Forms.Reports.cFMRP100010());
                                break;
                            case "RP12":
                                Application.Run(new Forms.Reports.cFMRP130010());
                                break;
                            case "MIGRATE":
                                if (ArgumentsList.Length > 3 && Convert.ToDateTime(ArgumentsList[4].ToString()) > Convert.ToDateTime(ArgumentsList[3].ToString()))
                                {
                                    Forms.Migrate.cFMMI100010 frm = new Forms.Migrate.cFMMI100010(Convert.ToDateTime(ArgumentsList[3]), Convert.ToDateTime(ArgumentsList[4]), Convert.ToInt32(ArgumentsList[5]));
                                    Application.Run(frm);
                                }
                                break;
                            case "TEST":
                                Application.Run(new cMRT1000101());
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
                }
            }catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.Verification: {1}", core, ex.Message));
            }
        }

        public void ProcessMigrate(DateTime Inicio , DateTime Fin,int dividendo)
        {
            try
            {
                CheckInHoursBLL CheckInoursBLL = new CheckInHoursBLL();
                //CheckInoursBLL.Migrate(Inicio, Fin, dividendo);
                CheckInoursBLL.Migrate2(dividendo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Arguments->ProcessMigrate: {0}", ex.Message),"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Boolean VerificationUser(String USER, String PASSWORD)
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
                throw new Exception(String.Format("{0}.VerificationUser: {1}", core, ex.Message));
            }
        }

        public bool ValidLicense()
        {
            try
            {
                return true;

                //LicenseBLL licenseBLL = new LicenseBLL();
                //int idLicense = licenseBLL.hasLicense();
                //if ( idLicense > 0)
                //{
                //    if (licenseBLL.isExpires(idLicense))
                //    {
                //        MessageBox.Show("La licencia ha expirado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return false;
                //    }

                //    return true;
                //}

                //Applications app = new Applications();
                //app.execute("Connection.exe", "EXLIC");

                //return false;
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.ValidLicense: {1}", core, ex.Message));
            }

        }
    }
}
