using RegistryTime.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

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
                        default:
                            break;
                    }
                }
            }catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.Verification: {1}", core, ex));
            }
        }

        public Boolean VerificationUser(String USER , String PASSWORD)
        {
            try
            {
                Boolean response = true;
                return response; 
            }catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.VerificationUser: {1}", core, ex));
            }
        }
    }
}
