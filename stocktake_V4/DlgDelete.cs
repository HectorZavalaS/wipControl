using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stocktake_V4
{
    public partial class DlgDelete : Form
    {
        public DlgDelete()
        {
            InitializeComponent();
        }

        private void DlgDelete_Load(object sender, EventArgs e)
        {
            txtSerial.Focus();
        }
    }
}
