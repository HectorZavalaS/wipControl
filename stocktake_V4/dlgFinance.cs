using MetroFramework.Forms;
using stocktake_V4.Class;
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
    public partial class dlgFinance : MetroForm
    {
        siixsem_stocktake_dbEntities m_db = new siixsem_stocktake_dbEntities();
        private int m_id_user;
        List<getZonesQty_Result> m_zones;
        CAlert m_alerts;
        public dlgFinance()
        {
            InitializeComponent();
        }
        public dlgFinance(int id_user)
        {
            InitializeComponent();
            m_id_user = id_user;
            m_zones = new List<getZonesQty_Result>();
            m_alerts = new CAlert();
        }

        private void dlgFinance_Load(object sender, EventArgs e)
        {
            getLastFiveFin();
        }
        private void getLastFive()
        {
            var last = m_db.getLastFiveScan(m_id_user);
            dataLast.DataSource = last;
        }
        private void getLastFiveFin()
        {
            var last = m_db.getLastFiveFin(m_id_user);
            dataLast.DataSource = last;
        }

        private void txtLabel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                finQty.Focus();
            }
        }

        private void finQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            dlgMessage dlgMessage = new dlgMessage("");
            if (e.KeyChar == (char)13)
            {
                if (!String.IsNullOrEmpty(finQty.Text))
                {
                    if (!String.IsNullOrEmpty(txtLabel.Text))
                    {
                        String barcode = txtLabel.Text.Replace("'", "-").Replace("]", "|");

                        if ((Convert.ToInt32(finQty.Text) < 0 || Convert.ToInt32(finQty.Text) > 51) && barcode.Contains("MAG"))
                        {
                            m_alerts.playWarning();
                            dlgMessage.Message = "Para magazine la cantidad debe ser entre 1 a 50 pcb's!";
                            dlgMessage.ShowDialog();
                            finQty.Focus();
                            return;
                        }
                        else
                        {
                            if (Convert.ToInt32(finQty.Text) < 0)
                            {
                                m_alerts.playWarning();
                                dlgMessage.Message = "La cantidad debe ser mayor a 0!";
                                dlgMessage.ShowDialog();
                                finQty.Focus();
                                return;
                            }

                        }

                        txtLabel.Text = barcode;
                        int result = m_db.updateFinChecked(barcode, m_id_user, Convert.ToInt32(finQty.Text)).First().RESULT;

                        if (result == 1)
                        {
                            //txtMessage.ForeColor = Color.Green;
                            //txtMessage.Text = "Saved successfully!";
                            //MessageBox.Show("Se guardo con exito la validación!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            m_alerts.playSuccess();
                            getLastFiveFin();
                            // getZonesCount();

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
                                m_alerts.playWarning();
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
                    finQty.Text = "";
                    txtLabel.Focus();
                    //timer1.Start();
                }
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
