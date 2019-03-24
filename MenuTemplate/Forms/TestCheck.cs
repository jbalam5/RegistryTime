using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLayer;

namespace RegistryTime.Forms
{
    public partial class TestCheck : Form
    {

        public TestCheck()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //DateTime inicio = Convert.ToDateTime("2017-01-25");
            //DateTime Fin = Convert.ToDateTime("2017-01-31");
            CheckInHoursBLL CheckInoursBLL = new CheckInHoursBLL();
            /*dataGridViewHours.DataSource = */
            //CheckInoursBLL.Migrate(Convert.ToDateTime("2017-01-25"),Convert.ToDateTime("2017-01-31"));


        }
    }
}
