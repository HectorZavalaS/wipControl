using MetroFramework.Forms;
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
    public partial class dlgMessage : MetroForm
    {
        String m_Message;
        public dlgMessage(String Message)
        {
            InitializeComponent();
            lblMessage.Text = Message;
        }

        public string Message { get => m_Message; set => m_Message = value; }

        private void dlgMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && e.Shift)

            {
                this.Close();
            }
        }

        private void dlgMessage_Load(object sender, EventArgs e)
        {
            lblMessage.Text = m_Message;
            //lblMessage.Location = new Point(this.Left + (this.Width - lblMessage.Width) / 2, 20);
        }
    }
}
