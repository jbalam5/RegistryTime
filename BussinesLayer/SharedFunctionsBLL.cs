using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public class SharedFunctionsBLL
    {
        public const string DirectoryFiles = "SharedFiles";
        public void CreateFileTXT(String FileName, string TextBody)
        {
            string PathFile = String.Format("{0}/{1}", DirectoryFiles, FileName);
            System.IO.File.AppendAllText(PathFile, TextBody);

        }
    }
}
