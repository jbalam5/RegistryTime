///
///    Experimented By : Ozesh Thapa
///    Email: dablackscarlet@gmail.com
///
using System;
using System.Collections.Generic;
using System.Text;
using BiometricCore;
using ModelLayer;

namespace BussinesLayer
{
    public class ZKTecoDeviceBLL
    {

        public ZKTekoBiometric objZKTeko;
        public string IP;
        public int port;
        private static int machineNumber = 1;

        Action<object, string> RaiseDeviceEvent;

        public ZKTecoDeviceBLL()
        {
            this.objZKTeko = new ZKTekoBiometric(RaiseDeviceEvent);
        }

        public bool connect()
        {
            try
            {
                ReaderConnectionBLL readerConnectionBLL = new ReaderConnectionBLL();
                ReaderConnectionML readerConnectionML = readerConnectionBLL.GetActiveConnection();

                if (readerConnectionML != null)
                    return connect(readerConnectionML.ip, int.Parse(readerConnectionML.port));
                else
                    throw new Exception("No se encontró una conexión valida");

            }catch(Exception ex)
            {
                throw new Exception(string.Format("ZKTecoDeviceBLL.connect: {0}", ex.Message));
            }
        }

        public bool connect(string Ip, int port = 0)
        {
            if (string.IsNullOrEmpty(Ip) || port <= 0)
                throw new Exception("No se encontrarón la IP/Puerto del Lector");

            return objZKTeko.Connect_Net(Ip, port);
        }

        //private void RaiseDeviceEvent(object sender, string actionType)
        //{
        //}
        /// <summary>
        /// Obtiene la lista de usuarios registrados en el lector
        /// </summary>
        /// <returns></returns>
        public ICollection<UserInfo> GetAllUserInfo()
        {
            if (connect())
            {
                string sdwEnrollNumber = string.Empty, sName = string.Empty, sPassword = string.Empty, sTmpData = string.Empty;
                int iPrivilege = 0, iTmpLength = 0, iFlag = 0, idwFingerIndex;
                bool bEnabled = false;

                ICollection<UserInfo> lstFPTemplates = new List<UserInfo>();

                objZKTeko.ReadAllUserID(machineNumber);
                objZKTeko.ReadAllTemplate(machineNumber);

                while (objZKTeko.SSR_GetAllUserInfo(machineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))
                {
                    for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                    {
                        if (objZKTeko.GetUserTmpExStr(machineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))
                        {
                            UserInfo fpInfo = new UserInfo();
                            fpInfo.MachineNumber = machineNumber;
                            fpInfo.EnrollNumber = sdwEnrollNumber;
                            fpInfo.Name = sName;
                            fpInfo.FingerIndex = idwFingerIndex;
                            fpInfo.TmpData = sTmpData;
                            fpInfo.Privelage = iPrivilege;
                            fpInfo.Password = sPassword;
                            fpInfo.Enabled = bEnabled;
                            fpInfo.iFlag = iFlag.ToString();

                            lstFPTemplates.Add(fpInfo);
                        }
                    }

                }
                return lstFPTemplates;
            }
            return null;
        }

        public int SetUserInfo(int UserID, string Name, int iPrivilege, string Cardnumber, string Password)
        {

            if (connect())
            {
                if (UserID == 0) throw new Exception("*Please input data first!");

                bool bFlag = false;
                if (iPrivilege == 5) throw new Exception("*User Defined Role is Error! Please Register again!");

                int iPIN2Width = 0;
                int iIsABCPinEnable = 0;
                int iT9FunOn = 0;
                string strTemp = "";
                //objZKTeko.GetSysOption(machineNumber, "~PIN2Width", out strTemp);
                //iPIN2Width = Convert.ToInt32(strTemp);
                //objZKTeko.GetSysOption(machineNumber, "~IsABCPinEnable", out strTemp);
                //iIsABCPinEnable = Convert.ToInt32(strTemp);
                //objZKTeko.GetSysOption(machineNumber, "~T9FunOn", out strTemp);
                //iT9FunOn = Convert.ToInt32(strTemp);

                //if (UserID.ToString().Length > iPIN2Width) return -1022;

                //if (iIsABCPinEnable == 0 || iT9FunOn == 0)
                //{
                //    if (UserID.ToString().Substring(0, 1) == "0")
                //        throw new Exception("*User ID error! The first letter can not be as 0");

                //    foreach (char tempchar in UserID.ToString().ToCharArray())
                //    {
                //        if (!(char.IsDigit(tempchar)))
                //            throw new Exception("*User ID error! User ID only support digital");
                //    }
                //}

                int idwErrorCode = 0;
                string sdwEnrollNumber = UserID.ToString();
                string sName = Name.ToString();
                string sCardnumber = Cardnumber.ToString();
                string sPassword = Password.ToString();

                bool bEnabled = true;

                objZKTeko.EnableDevice(machineNumber, false);
                //objZKTeko.SetStrCardNumber(sCardnumber);//Before you using function SetUserInfo,set the card number to make sure you can upload it to the device

                if (!objZKTeko.SSR_SetUserInfo(machineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload the user's information(card number included)
                {
                    objZKTeko.GetLastError(ref idwErrorCode);
                    throw new Exception("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
                }

                objZKTeko.RefreshData(machineNumber);//the data in the device should be refreshed
                objZKTeko.EnableDevice(machineNumber, true);

                return UserID;
            }
            return 0;
        }
        
        public UserInfo GetUserInfoById(int UserID)
        {
            if (connect())
            {
                if (UserID == 0) throw new Exception("*Please input user id first!");

                int iPIN2Width = 0;
                string strTemp = "";
                objZKTeko.GetSysOption(machineNumber, "~PIN2Width", out strTemp);
                iPIN2Width = Convert.ToInt32(strTemp);

                if (UserID.ToString().Length > iPIN2Width)
                    throw new Exception("*User ID error! The max length is " + iPIN2Width.ToString());


                int idwErrorCode = 0;
                int iPrivilege = 0;
                string strName = "";
                string strPassword = "";
                bool bEnabled = false;
                UserInfo UserInfo = null;

                objZKTeko.EnableDevice(machineNumber, false);
                if (objZKTeko.SSR_GetUserInfo(machineNumber, UserID.ToString(), out strName, out strPassword, out iPrivilege, out bEnabled))//upload the user's information(card number included)
                {
                    //objZKTeko.GetStrCardNumber(out strCardno);
                    //if (strCardno.Equals("0"))
                    //{
                    //    strCardno = "";
                    //}
                    UserInfo = new UserInfo()
                    {
                        Name = strName,
                        Password = strPassword,
                        EnrollNumber = UserID.ToString(),
                        Privelage = iPrivilege,
                        Enabled = bEnabled,
                        MachineNumber = machineNumber
                    };
                }
                else
                {
                    objZKTeko.GetLastError(ref idwErrorCode);
                    throw new Exception("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
                }
                objZKTeko.EnableDevice(machineNumber, true);

                return UserInfo;
            }
            return null;
        }
        public ICollection<HoursAssistanceInfo> GetLogData()
        {
            string dwEnrollNumber1 = "";
            int dwVerifyMode = 0;
            int dwInOutMode = 0;
            int dwYear = 0;
            int dwMonth = 0;
            int dwDay = 0;
            int dwHour = 0;
            int dwMinute = 0;
            int dwSecond = 0;
            int dwWorkCode = 0;

            objZKTeko.EnableDevice(machineNumber, false);
            ICollection<HoursAssistanceInfo> lstEnrollData = new List<HoursAssistanceInfo>();

            if (objZKTeko.ReadAllGLogData(machineNumber))
            {
                while (objZKTeko.SSR_GetGeneralLogData(machineNumber, out dwEnrollNumber1, out dwVerifyMode, out dwInOutMode, out dwYear, out dwMonth, out dwDay, out dwHour, out dwMinute, out dwSecond, ref dwWorkCode))
                {
                    string inputDate = new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond).ToString();

                    HoursAssistanceInfo objInfo = new HoursAssistanceInfo();
                    objInfo.MachineNumber = machineNumber;
                    objInfo.IndRegID = int.Parse(dwEnrollNumber1);
                    objInfo.DateTimeRecord = inputDate;
                    objInfo.VerifyType = dwVerifyMode;
                    objInfo.WorkCode = dwWorkCode;
                    objInfo.VerifyState = dwInOutMode;
                    lstEnrollData.Add(objInfo);
                }

            }

            objZKTeko.EnableDevice(machineNumber, true);
            return lstEnrollData;
        }

        public ICollection<HoursAssistanceInfo> GetLogDataByDate(string startDate, string endDate)
        {
            string dwEnrollNumber1 = "";
            int dwVerifyMode = 0;
            int dwInOutMode = 0;
            int dwYear = 0;
            int dwMonth = 0;
            int dwDay = 0;
            int dwHour = 0;
            int dwMinute = 0;
            int dwSecond = 0;
            int dwWorkCode = 0;

            objZKTeko.EnableDevice(machineNumber, false);

            ICollection<HoursAssistanceInfo> lstEnrollData = new List<HoursAssistanceInfo>();

            if (objZKTeko.ReadGLogDataByDate(machineNumber, startDate, endDate))
            {
                while (objZKTeko.SSR_GetGeneralLogData(machineNumber, out dwEnrollNumber1, out dwVerifyMode, out dwInOutMode, out dwYear, out dwMonth, out dwDay, out dwHour, out dwMinute, out dwSecond, ref dwWorkCode))
                {
                    string inputDate = new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond).ToString();

                    HoursAssistanceInfo objInfo = new HoursAssistanceInfo();
                    objInfo.MachineNumber = machineNumber;
                    objInfo.IndRegID = int.Parse(dwEnrollNumber1);
                    objInfo.DateTimeRecord = inputDate;
                    objInfo.VerifyType = dwVerifyMode;
                    objInfo.WorkCode = dwWorkCode;
                    objInfo.VerifyState = dwInOutMode;
                    lstEnrollData.Add(objInfo);
                }

            }

            objZKTeko.EnableDevice(machineNumber, true);
            return lstEnrollData;
        }

        public ICollection<UserIDInfo> GetAllUserID()
        {
            if (connect())
            {
                int dwEnrollNumber = 0;
                int dwEMachineNumber = 0;
                int dwBackUpNumber = 0;
                int dwMachinePrivelage = 0;
                int dwEnabled = 0;

                ICollection<UserIDInfo> lstUserIDInfo = new List<UserIDInfo>();

                while (objZKTeko.GetAllUserID(machineNumber, ref dwEnrollNumber, ref dwEMachineNumber, ref dwBackUpNumber, ref dwMachinePrivelage, ref dwEnabled))
                {
                    UserIDInfo userID = new UserIDInfo();
                    userID.BackUpNumber = dwBackUpNumber;
                    userID.Enabled = dwEnabled;
                    userID.EnrollNumber = dwEnrollNumber;
                    userID.MachineNumber = dwEMachineNumber;
                    userID.Privelage = dwMachinePrivelage;
                    lstUserIDInfo.Add(userID);
                }
                return lstUserIDInfo;
            }

            return null;
        }

        public ICollection<UserInfo> GetListAllUserInfo()
        {
            if (connect())
            {
                int dwEnrollNumber = 0;
                int dwEMachineNumber = 0;
                int dwMachinePrivelage = 0;
                string dwname = "";
                string dwPassword = "";
                bool dwEnabled = false;

                ICollection<UserInfo> lstUserInfo = new List<UserInfo>();

                while (objZKTeko.GetAllUserInfo(dwEMachineNumber, ref dwEnrollNumber, ref dwname, ref dwPassword, ref dwMachinePrivelage, ref dwEnabled))
                {
                    UserInfo userInfo = new UserInfo();
                    userInfo.MachineNumber = dwEMachineNumber;
                    userInfo.Name = dwname;
                    userInfo.Password = dwPassword;
                    userInfo.Privelage = dwMachinePrivelage;
                    userInfo.Enabled = dwEnabled;
                    userInfo.EnrollNumber = dwEnrollNumber.ToString();
                    
                    lstUserInfo.Add(userInfo);
                }
                return lstUserInfo;
            }

            return null;
        }

        public void GetGeneratLog(string enrollNo)
        {
            string name = null;
            string password = null;
            int previlage = 0;
            bool enabled = false;
            byte[] byTmpData = new byte[2000];
            int tempLength = 0;

            int idwFingerIndex = 0;// [ <--- Enter your fingerprint index here ]
            int iFlag = 0;

            objZKTeko.ReadAllTemplate(machineNumber);

            while (objZKTeko.SSR_GetUserInfo(machineNumber, enrollNo, out name, out password, out previlage, out enabled))
            {
                if (objZKTeko.GetUserTmpEx(machineNumber, enrollNo, idwFingerIndex, out iFlag, out byTmpData[0], out tempLength))
                {
                    break;
                }
            }
        }


        public bool PushUserDataToDevice(string enrollNo)
        {
            string userName = string.Empty;
            string password = string.Empty;
            int privelage = 1;
            return objZKTeko.SSR_SetUserInfo(machineNumber, enrollNo, userName, password, privelage, true);
        }

        public bool UploadFTPTemplate(List<UserInfo> lstUserInfo)
        {
            string sdwEnrollNumber = string.Empty, sName = string.Empty, sTmpData = string.Empty;
            int idwFingerIndex = 0, iPrivilege = 0, iFlag = 1, iUpdateFlag = 1;
            string sPassword = "";
            string sEnabled = "";
            bool bEnabled = false;

            if (objZKTeko.BeginBatchUpdate(machineNumber, iUpdateFlag))
            {
                string sLastEnrollNumber = "";

                for (int i = 0; i < lstUserInfo.Count; i++)
                {
                    sdwEnrollNumber = lstUserInfo[i].EnrollNumber;
                    sName = lstUserInfo[i].Name;
                    idwFingerIndex = lstUserInfo[i].FingerIndex;
                    sTmpData = lstUserInfo[i].TmpData;
                    iPrivilege = lstUserInfo[i].Privelage;
                    sPassword = lstUserInfo[i].Password;
                    sEnabled = lstUserInfo[i].Enabled.ToString();
                    iFlag = Convert.ToInt32(lstUserInfo[i].iFlag);
                    bEnabled = true;

                    /* [ Identify whether the user 
                         information(except fingerprint templates) has been uploaded */

                    if (sdwEnrollNumber != sLastEnrollNumber)
                    {
                        if (objZKTeko.SSR_SetUserInfo(machineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload user information to the memory
                            objZKTeko.SetUserTmpExStr(machineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData);//upload templates information to the memory
                        else return false;
                    }
                    else
                    {
                        /* [ The current fingerprint and the former one belongs the same user,
                        i.e one user has more than one template ] */
                        objZKTeko.SetUserTmpExStr(machineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData);
                    }

                    sLastEnrollNumber = sdwEnrollNumber;
                }

                return true;
            }
            else
                return false;
        }

        public object ClearData(BiometricCore.Enums.ClearFlag clearFlag)
        {
            int iDataFlag = (int)clearFlag;

            if (objZKTeko.ClearData(machineNumber, iDataFlag))
                return objZKTeko.RefreshData(machineNumber);
            else
            {
                int idwErrorCode = 0;
                objZKTeko.GetLastError(ref idwErrorCode);
                return idwErrorCode;
            }
        }

        public bool ClearGLog()
        {
            return objZKTeko.ClearGLog(machineNumber);
        }


        public string FetchDeviceInfo()
        {
            StringBuilder sb = new StringBuilder();

            string returnValue = string.Empty;


            objZKTeko.GetFirmwareVersion(machineNumber, ref returnValue);
            if (returnValue.Trim() != string.Empty)
            {
                sb.Append("Firmware V: ");
                sb.Append(returnValue);
                sb.Append(",");
            }


            returnValue = string.Empty;
            objZKTeko.GetVendor(ref returnValue);
            if (returnValue.Trim() != string.Empty)
            {
                sb.Append("Vendor: ");
                sb.Append(returnValue);
                sb.Append(",");
            }

            string sWiegandFmt = string.Empty;
            objZKTeko.GetWiegandFmt(machineNumber, ref sWiegandFmt);

            returnValue = string.Empty;
            objZKTeko.GetSDKVersion(ref returnValue);
            if (returnValue.Trim() != string.Empty)
            {
                sb.Append("SDK V: ");
                sb.Append(returnValue);
                sb.Append(",");
            }

            returnValue = string.Empty;
            objZKTeko.GetSerialNumber(machineNumber, out returnValue);
            if (returnValue.Trim() != string.Empty)
            {
                sb.Append("Serial No: ");
                sb.Append(returnValue);
                sb.Append(",");
            }

            returnValue = string.Empty;
            objZKTeko.GetDeviceMAC(machineNumber, ref returnValue);
            if (returnValue.Trim() != string.Empty)
            {
                sb.Append("Device MAC: ");
                sb.Append(returnValue);
            }

            return sb.ToString();
        }

        public bool ReadGeneralLogData()
        {
            return objZKTeko.ReadAllGLogData(machineNumber);
        }

        //public bool GetGenralLogData(ZkemClient objZkeeper, int machineNumber)
        //{
        //    return objZkeeper.SSR_GetGeneralLogData(machineNumber,)
        //}
    }
}
