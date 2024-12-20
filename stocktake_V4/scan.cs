using MetroFramework.Forms;
using stocktake_V4.Class;
using stocktake_V4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stocktake_V4
{
    public partial class scan : MetroForm
    {
        siixsem_stocktake_dbEntities m_db = new siixsem_stocktake_dbEntities();
        private int m_id_user;
        List<getZonesQty_Result> m_zones;
        CAlert m_alerts;
        public scan()
        {
            InitializeComponent();
            m_id_user = 0;
        }
        public scan(int id_user)
        {
            InitializeComponent();
            m_id_user = id_user;
            m_zones = new List<getZonesQty_Result>();
            m_alerts = new CAlert();
        }
        private void scan_Load(object sender, EventArgs e)
        {
            getLastFive();
            getZonesCount();
        }

        private void txtLabel_KeyPress(object sender, KeyPressEventArgs e)
        {
            dlgMessage dlgMessage = new dlgMessage("");
            if (e.KeyChar == (char)13)
            {
                if (!String.IsNullOrEmpty(txtLabel.Text))
                {
                    String barcode = txtLabel.Text.Replace("'","-").Replace("]","|");

                    txtLabel.Text = barcode;
                    int result = m_db.updateCheckedV2(barcode, m_id_user).First().RESULT;

                    if (result == 1)
                    {
                        //txtMessage.ForeColor = Color.Green;
                        //txtMessage.Text = "Saved successfully!";
                        //MessageBox.Show("Se guardo con exito la validación!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_alerts.playSuccess();
                        getLastFive();
                        getZonesCount();

                    }
                    else
                    {
                        if (result == -2)
                        {

                            m_alerts.playWarning();

                            dlgMessage.Message = "La etiqueta ya se escaneo!";
                            dlgMessage.ShowDialog();
                        }
                        else
                        {
                            //MessageBox.Show("La etiqueta escaneada no existe o fue borrada!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dlgMessage.Message = "La etiqueta escaneada no existe o fue borrada!";
                            dlgMessage.ShowDialog();
                        }
                    }
                }
                else
                {
                    txtMessage.ForeColor = Color.Red;
                    txtMessage.Text = "The field can be empty!";
                }
                txtLabel.Text = "";
                txtLabel.Focus();
                timer1.Start();
            }
        }
        private void getLastFive()
        {
            var last = m_db.getLastFiveScan(m_id_user);
            dataLast.DataSource = last;
        }

        private void getZonesCount()
        {
            var zones = m_db.getZonesQty();
            int y = 35;   
            foreach(getZonesQty_Result zone in zones)
            {
                Control c = Controls.Find("progressBar" + zone.ZONE, true).FirstOrDefault();
                TextProgressBar b = null;
                if (c == null)
                {

                    b = new TextProgressBar();
                    b.Location = new System.Drawing.Point(40, y);
                    b.Name = "progressBar" + zone.ZONE;
                    b.Width = 200;
                    b.Height = 20;
                    b.Minimum = 0;
                    b.Maximum = Convert.ToInt32(zone.TOTAL);
                    b.Step = 1;
                    b.Value = Convert.ToInt32(zone.COUNT);
                    b.Text = zone.ZONE + " " + Convert.ToString(zone.COUNT) + " de " + Convert.ToString(zone.TOTAL);
                    Controls.Add(b);
                }
                else
                {
                    b = (TextProgressBar)c;
                    b.Maximum = Convert.ToInt32(zone.TOTAL);
                    b.Value = Convert.ToInt32(zone.COUNT);
                    b.Text = zone.ZONE + " " + Convert.ToString(zone.COUNT) + " de " + Convert.ToString(zone.TOTAL);

                }

                b.BringToFront();
                this.Invalidate();
                y += 25;


            }
  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            timer1.Stop();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void scan_Shown(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void dataLast_Click(object sender, EventArgs e)
        {
            txtLabel.Focus();
        }
    }
}
