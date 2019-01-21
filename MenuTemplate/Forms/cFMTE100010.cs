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
using DataLayer;

namespace MenuTemplate.Forms
{
    public partial class cFMTE100010 : Form
    {
        public JobBLL JobBll = new JobBLL();

        public cFMTE100010()
        {
            InitializeComponent();
        }

        private void cFMTE100010_Load(object sender, EventArgs e)
        {

        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            JobDAL job = new JobDAL
            {
                Id = 0,
                Name = textBoxNombre.Text,
                Description = textBoxDescripcion.Text,
                IdUserInsert = 1
            };

            JobBll.Save(job);
        }
    }
}
