using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistryTime.CustomControls
{
    public partial class LoaderControl : UserControl
    {
        public bool _IsVisible = false;

        public bool Isvisible {
            get{
                return _IsVisible;
            }
            set
            {
                _IsVisible = value;
                this.Visible = value;
            }
        }

        public string title {
            get
            {
                return TitleLabel.Text;
            }
            set
            {
                TitleLabel.Text = value;
            }
        }
        public string description {
            get
            {
                return DescriptionLabel.Text;
            }
            set
            {
                DescriptionLabel.Text = value;
            }
        }

        public LoaderControl()
        {
            InitializeComponent();
        }


    }
}
