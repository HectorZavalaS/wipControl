using stocktake_V4.Models;
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

    public partial class FormSheet : Form
    {
        private siixsem_sys_lblPrint_dbEntities m_db;
        public FormSheet()
        {
            InitializeComponent();
            m_db = new siixsem_sys_lblPrint_dbEntities();
        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                //var AllModels = m_db.ge|(datIni, datFin);
                var allmodels = m_db.getDjbySerial("352875");
                List<getDjbySerial_Result> data = allmodels.ToList();
                if (data == null) { 
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }
    }
}
