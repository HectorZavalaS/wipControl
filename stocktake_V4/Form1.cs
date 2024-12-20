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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stocktake_V4
{
    public partial class Form1 : MetroForm
    {
        private CCogiscan m_cogiscan;
        Thread splashthread;
        CCogiscanCGSDW m_db_11;// = new CCogiscanCGSDW();
        COracle m_oracle;// = new COracle("172.25.0.15", "MXPRD");
        private CModelInfo m_model;
        siixsem_stocktake_dbEntities m_db_st;// = new siixsem_stocktake_dbEntities();
        siixsem_sys_lblPrint_dbEntities m_db_lb;
        siixsem_wip_config_dbEntities m_db_wip_cfg;
        CPrint m_print;// = new CPrint();
        int m_id_User;
        String m_user_name;
        private BackgroundWorker _bwUpdate;
        private BackgroundWorker _bwUpdateQty;
        int m_level;
        int type_cont;// = 0;
        dlgMessage m_dlgMessage;
        CAlert m_alerts;
        CSimosUser m_user;
        String m_zone;
        String m_area;
        bool m_quarantine;
        int m_id_area;

        delegate void addLineDelegate(string texto);
        private void addLine(string texto)
        {
            if (m_console.InvokeRequired)
            {
                addLineDelegate delegado = new addLineDelegate(addLine);
                object[] parametros = new object[] { texto };
                m_console.Invoke(delegado, parametros);
            }
            else
            {
                try
                {
                    if (m_console.TextLength > 100000)
                    {
                        m_console.Clear();
                    }
                    if (!String.IsNullOrEmpty(texto) && !String.IsNullOrWhiteSpace(texto))
                    {
                        m_console.AppendText(texto + "\n");
                    }

                }
                catch (Exception ex) { }
            }
        }
        private void initThreads()
        {
            try
            {
                _bwUpdate = new BackgroundWorker
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };
                _bwUpdate.DoWork += updateSemifinish;
                //_bwUpdate.ProgressChanged += bw_ProgressChanged;
                _bwUpdate.RunWorkerCompleted += bw_RunWorkerCompleted;

                _bwUpdateQty = new BackgroundWorker
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };
                _bwUpdateQty.DoWork += updateQty;
                //_bwUpdate.ProgressChanged += bw_ProgressChanged;
                _bwUpdateQty.RunWorkerCompleted += bw_RunWorkerCompleted;
            }
            catch (Exception ex)
            {
                //logger.Error(ex, "[initThreads] Error...");
            }

        }
        public Form1()
        {
            InitializeComponent();
            m_cogiscan = new CCogiscan();
            m_model = null;
            m_db_st = new siixsem_stocktake_dbEntities();
            m_db_lb = new siixsem_sys_lblPrint_dbEntities();
            m_db_wip_cfg = new siixsem_wip_config_dbEntities();
            m_print = new CPrint();
            m_id_User = 0;
            m_user_name = "";
            try
            {
                m_oracle = new COracle("192.168.0.23", "SEMPROD");
            }
            catch(Exception EX) { }
            m_db_11 = new CCogiscanCGSDW();
            initThreads();
        }

        public Form1(CSimosUser user, int type_scan, int zone, bool quar)
        {
            try
            {

                InitializeComponent();
                m_cogiscan = new CCogiscan();
                m_model = null;
                m_db_st = new siixsem_stocktake_dbEntities();
                m_db_lb = new siixsem_sys_lblPrint_dbEntities();
                m_db_wip_cfg = new siixsem_wip_config_dbEntities();
                m_print = new CPrint();
                m_id_User = user.Id;
                m_user_name = user.User_name;
                m_level = user.Level;
                type_cont = type_scan;
                m_dlgMessage = new dlgMessage("");
                m_alerts = new CAlert();
                Cursor = Cursors.WaitCursor;
                m_id_area = zone;
                getWipZonByIDArea_Result AREA = m_db_st.getWipZonByIDArea(zone).First();
                m_zone = AREA.WIP_ZONE;
                m_area = AREA.AREA;
                m_quarantine = quar;
                try
                {
                    m_oracle = new COracle("192.168.0.23", "SEMPROD");
                }
                catch(Exception ex)
                {

                }
                m_db_11 = new CCogiscanCGSDW();
                initThreads();
                Cursor = Cursors.Arrow;
                btnDelete.Visible = false;
                //type_cont = 2;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                addLine("[" + DateTime.Now.ToString() + "] " + ex.Message + " --- " + ex.InnerException);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtUser.Text = "Bienvenido " + m_user_name;
                if (m_level == 8 || m_level == 10)
                {
                    
                    btnPrintLabel.Enabled = false;
                    kryptonPanel3.Visible = false;
                    kryptonPanel2.Visible = false;
                    btnScaning.Visible = true;
                    kryptonPanel4.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    getZonesCount();
                    dataLast.Visible = false;
                    m_console.Visible = false;
                    if (m_level == 10) btnScaning.Text = "Escaneo finanzas";
                }
                else
                {
                    if (m_level == 9)
                    {
                        kryptonPanel4.Visible = false;

                        kryptonLabel7.Visible = false;
                        txtQty.Visible = false;
                        btnPrintLabel.Visible = false;
                        btnScaning.Visible = false;
                        pictureBox2.Visible = false;
                        pictureBox3.Visible = false;
                        pictureBox4.Visible = false;

                    }
                    else
                    {
                        var MAGS = m_db_st.getMagazines();
                        cmbMags.DataSource = MAGS;
                        cmbMags.DisplayMember = "DESCRIPTION";
                        cmbMags.ValueMember = "ID_MAG";

                        var loc = m_db_st.getLocators();
                        cmbLoc.DataSource = loc;
                        cmbLoc.DisplayMember = "DESCRIPTION";
                        cmbLoc.ValueMember = "ID_LOCATOR";

                        dataLast.Visible = true;
                        m_console.Visible = true;
                        getLastFive();
                        kryptonGroupBox1.Visible = false;
                        kryptonPanel3.Visible = true;
                        kryptonPanel2.Visible = true;
                        btnScaning.Visible = false;
                        kryptonPanel4.Visible = true;

                        kryptonLabel7.Visible = true;
                        txtQty.Visible = true;
                        btnPrintLabel.Visible = true;
                        //btnScaning.Visible = true;
                        if (type_cont == 1)
                        {
                            selBox.Checked = true;
                            //selMag.Checked = false;
                            //type_cont = 1;
                        }
                        if (type_cont == 2)
                        {
                            //selBox.Checked = false;
                            selMag.Checked = true;
                        }
                        if(m_quarantine)
                        {
                            pictureBox2.Visible = true;
                            pictureBox3.Visible = true;
                            pictureBox4.Visible = true;
                        }
                        else
                        {
                            pictureBox2.Visible = false;
                            pictureBox3.Visible = false;
                            pictureBox4.Visible = false;
                        }
                        Invalidate();
                    }
                }
                //timerUpdateQty.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //this.TopMost = true;
            txtSerial.Focus();

        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //MessageBox.Show("Hrw");
                if (!String.IsNullOrEmpty(txtSerial.Text))
                {
                    if (m_level == 8)
                        deleteLabel();
                    else
                        getSerialInfo();

                }
            }
        }
        private void deleteLabel()
        {
            DlgDelete m_dlgDelete = new DlgDelete();
            int result = 0;
            if(MessageBox.Show("Deseas dar de baja un magazine?", "Warning...", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (m_dlgDelete.ShowDialog() == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(m_dlgDelete.txtSerial.Text))
                    {
                        result = m_db_st.deleteLabel(m_dlgDelete.txtSerial.Text.Replace("'", "-").Replace("]", "|"), m_id_User).First().RESULT;
                        if (result == 1)
                        {
                            m_alerts.playSuccess();
                            MessageBox.Show("Se dio de baja el magazine.");
                        }
                        else
                            if (result == -1)
                        {
                            //MessageBox.Show("La etiqueta no existe.");
                            m_alerts.playWarning();
                            m_dlgMessage.Message = "La etiqueta no existe.";
                            m_dlgMessage.ShowDialog();
                        }
                        else
                        {
                            //MessageBox.Show("La etiqueta ya estaba borrada.");
                            m_alerts.playWarning();
                            m_dlgMessage.Message = "La etiqueta no existe.";
                            m_dlgMessage.ShowDialog();
                        }

                    }
                    txtSerial.Text = "";
                }
            }
            else
                txtSerial.Text = "";
        }

        private void getSerialInfo()
        {
            String semifinish = "";
            Cursor = Cursors.WaitCursor;
            if (!String.IsNullOrEmpty(txtSerial.Text)) {
                if (m_db_st.existsLabel(txtSerial.Text.Replace("'", "-").Replace("]", "|")).First().RESULT != -1)
                {
                    m_console.AppendText("[" + DateTime.Now.ToString() + "] " + "Quering serial " + txtSerial.Text.Replace("'", "-").Replace("]", "|") + " to COGISCAN...\n");
                    m_model = m_cogiscan.query_item(txtSerial.Text.Replace("'", "-").Replace("]", "|"));

                    if (m_model != null)
                    {
                        if (m_model.BatchId != "NG")
                        {
                            //if (type_cont == 2)
                            GetSemifinish(m_model.PartNumber, ref semifinish,m_model.Route);
                            //else
                            //{
                            //    if (type_cont == 1 && !m_user_name.Equals("box.final"))
                            //    {
                            //        GetBoxSemifinish(m_model.PartNumber, ref semifinish);
                            //    }
                            //    else
                            //    {
                            //        if (type_cont == 1 && m_user_name.Equals("box.final"))
                            //        {
                            //            GetFinalBoxSemifinish(m_model.PartNumber, ref semifinish);
                            //        }
                            //    }
                            //}
                            m_console.AppendText("[" + DateTime.Now.ToString() + "] " + "Serial found " + txtSerial.Text.Replace("'", "-").Replace("]", "|") + "\n");
                            m_console.AppendText("[" + DateTime.Now.ToString() + "] " + txtSerial.Text.Replace("'", "-").Replace("]", "|") + "\n");
                            m_console.AppendText("[" + DateTime.Now.ToString() + "] " + m_model.PartNumber + "\n");
                            m_console.AppendText("[" + DateTime.Now.ToString() + "] " + m_model.BatchId + "\n");
                            m_console.AppendText("[" + DateTime.Now.ToString() + "] " + m_model.Route + "\n");
                            m_console.AppendText("[" + DateTime.Now.ToString() + "] " + "PENDING\n");
                            m_console.AppendText("[" + DateTime.Now.ToString() + "] " + m_model.Operation + " - " + m_model.Status + "\n");

                            getCurrentStation();

                            txtScanedSerial.Text = txtSerial.Text.Replace("'", "-").Replace("]", "|");
                            txtModel.Text = m_model.PartNumber;
                            String temp = Regex.Replace(m_model.BatchId, "[A-Za-z]", "");
                            temp = temp.Trim(new Char[] { ' ', '*', '-', '/' });
                            if (temp.Length > 6 || temp.Length < 6)
                                temp = m_db_lb.getDjbySerial(txtSerial.Text.Replace("'", "-").Replace("]", "|")).First().DJ_GROUP;
                            txtDjGroup.Text = temp;
                            txtRoute.Text = m_model.Route;
                            txtReview.Text = m_model.REV;
                            txtSemi.Text = semifinish;
                            txtOp.Text = m_model.Operation;
                            txtStatus.Text = m_model.Status;
                            txtSerial.Text = "";
                            m_alerts.playSuccess();
                            txtQty.Focus();
                        }
                        else
                        {
                            processNotInWip(txtSerial.Text);
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("La etiqueta ya fue escaneada.\n No se imprimira la etiqueta.", "Print Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_alerts.playWarning();
                    m_dlgMessage.Message = "La etiqueta ya fue escaneada.\n No se imprimira la etiqueta.";
                    m_dlgMessage.ShowDialog();
                    txtSerial.Text = "";
                    CleanFields();
                    txtSerial.Focus();
                }
            }
            Cursor = Cursors.Arrow;
        }
        void processNotInWip(String serial)
        {
            notInWip dlgNotInWip = new notInWip(txtSerial.Text);
            dlgNotInWip.ShowDialog();

            if (dlgNotInWip.ResultRelease == true)
                getSerialInfo();
            else
            {
                txtSerial.Text = "";
                txtSerial.Focus();
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSerial.Text))
            {
                if (m_level == 8)
                    deleteLabel();
                else
                    getSerialInfo();
            }
        }

        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            printLabel();
        }

        private void printLabel()
        {
            try
            {
                if (!String.IsNullOrEmpty(txtScanedSerial.Text)){ ////txtQRLocation.Text
                    if (!String.IsNullOrEmpty(cmbMags.Text)){
                        if (!String.IsNullOrEmpty(txtQty.Text)){
                            if (!String.IsNullOrEmpty(cmbLoc.Text)){ /// txtScanedSerial.Text
                                if (Convert.ToInt32(txtQty.Text) > 50 && type_cont == 2)
                                {
                                    m_alerts.playWarning();
                                    m_dlgMessage.Message = "Los magazine no pueden tener mas de 50 piezas.";
                                    m_dlgMessage.ShowDialog();
                                    txtQty.Text = "";
                                    txtQty.Focus();
                                    return;
                                }

                                Cursor = Cursors.WaitCursor;
                                //setSemifinish();
                                Cursor = Cursors.Arrow;
                                String error = "";
                                String djGroup = txtDjGroup.Text;
                                String model = txtModel.Text;
                                String semifinish = txtSemi.Text;
                                String qty = txtQty.Text;
                                String cgsRoute = txtRoute.Text;
                                String namePrinter = "PRINTER_TSC";
                                String serial = txtScanedSerial.Text;
                                String type = type_cont == 1 ? "BOX" : "MAG";
                                int idU = m_id_User;
                                int printer = 1;


                                if (djGroup.Contains("No había ningún extremo"))
                                {
                                    m_alerts.playWarning();
                                    m_dlgMessage.Message = "No se puede guardar el registro. Escanea de nuevo el serial.";
                                    m_dlgMessage.ShowDialog();
                                    //MessageBox.Show("No se puede guardar el registro. Escanea de nuevo el serial.");
                                    CleanFields();
                                    return;
                                }

                                if (m_print.searchPrinter("PRINTER_TSC") && m_print.isOnline("PRINTER_TSC"))
                                {
                                    namePrinter = "PRINTER_TSC";
                                    printer = 1;
                                }
                                else
                                    if (m_print.searchPrinter("PRINTER_WIFI") && m_print.isOnline("PRINTER_WIFI"))
                                {
                                    namePrinter = "PRINTER_WIFI";
                                    printer = 2;
                                }
                                else
                                        if (m_print.searchPrinter("PRINTER_ZEBRA") && m_print.isOnline("PRINTER_ZEBRA"))
                                {
                                    namePrinter = "PRINTER_ZEBRA";
                                    printer = 3;
                                }
                                else
                                {
                                    MessageBox.Show("No se encontro ninguna de estas impresoras en linea o instaladas:" +
                                        "\n\n\t- PRINTER_TSC\n\t- PRINTER_WIFI\n\t- PRINTER_ZEBRA\n\nNo se imprimira ni guardara la información!.", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                String zone = m_zone;//m_db_st.getUserZone(idU).First().RESULT;
                                if (zone != "NOT_FOUND")
                                {
                                    int count = Convert.ToInt32(m_db_st.getLastQtyByUser(idU).First().COUNTLBL);
                                    int response = 0;
                                    String mag = cmbLoc.Text + "-" + cmbMags.Text;
                                    String qr = mag + "|" + model + "|" + djGroup + "|" + semifinish + "|" + qty + "|" + type;
                                    String template = m_db_st.getLabelSTSMT(model, djGroup, semifinish, cgsRoute, qty, qr, mag, printer, type_cont, m_user_name, m_area, m_quarantine == true ? 1 : 0, txtReview.Text).First().label;

                                    if (template != "DOESNT_EXIST")
                                    {
                                        response = m_db_st.insertLabel_V2(idU, serial, model, djGroup, semifinish, cgsRoute, qty, qr, mag, type_cont, m_quarantine == true ? 1 : 0, m_id_area, cmbMags.Text, cmbLoc.Text,txtReview.Text).First().RESULT;
                                        if (response > 0)
                                        {
                                            m_db_st.updateLastQtyByUser(idU, count);

                                            m_print.sendToPrinter(namePrinter, template, ref error, mag);
                                            //m_print.sendToPrinterIP("192.168.6.30", template, ref error);
                                            m_console.AppendText("[" + DateTime.Now.ToString() + "] " + "Se imprimio la etiqueta.\n");
                                            getLastFive();
                                            //_bwUpdate.RunWorkerAsync();
                                            m_alerts.playSuccess();
                                            //MessageBox.Show("Se imprimio la etiqueta.", "Print Successful...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            CleanFields();
                                        }
                                        else
                                        {
                                            if (response == -1)
                                            {
                                                m_alerts.playWarning();
                                                m_dlgMessage.Message = "La etiqueta ya fue escaneada.\n No se ingresa magazine.";
                                                m_dlgMessage.ShowDialog();
                                                CleanFields();
                                            }
                                            else
                                            {
                                                m_alerts.playWarning();
                                                m_dlgMessage.Message = "El magazine " + mag + " ya esta asignado a otra PCB.\n No se ingresa magazine.";
                                                m_dlgMessage.ShowDialog();
                                                CleanFields();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        m_alerts.playWarning();
                                        m_dlgMessage.Message = "No se encontro el código ZPL de la etiqueta Stocktake.";
                                        m_dlgMessage.ShowDialog();
                                        CleanFields();
                                    }

                                }
                                else
                                {
                                    m_alerts.playWarning();
                                    m_dlgMessage.Message = "No se encontro la zona del usuario.";
                                    m_dlgMessage.ShowDialog();
                                    CleanFields();
                                }
                            }
                            else
                            {

                                MessageBox.Show("No has escaneado el QR de la localidad.", "Print Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmbLoc.Focus();
                                //m_alerts.playWarning();
                                //m_dlgMessage.Message = "No has escaneado un serial.";
                                //m_dlgMessage.ShowDialog();
                                //CleanFields();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No has agregado la cantidad del magazine.", "Print Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtQty.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No has escaneado el QR del magazine.", "Print Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbMags.Focus();
                    }
                }
                else
                {
                    m_alerts.playWarning();
                    m_dlgMessage.Message = "No has escaneado un serial.";
                    m_dlgMessage.ShowDialog();
                    CleanFields();
                }
            }
            catch (Exception ex)
            {
                m_console.AppendText("[" + DateTime.Now.ToString() + "] " + ex.Message + "\n");
                MessageBox.Show(ex.Message);
            }
        }

        private void getLastFive()
        {
            var last = m_db_st.getLastFive(m_id_User);
            dataLast.DataSource = last;
        }

        private void CleanFields()
        {
            txtQty.Text = "";
            txtDjGroup.Text = "";
            txtModel.Text = "";
            txtOp.Text = "";
            txtRoute.Text = "";
            txtScanedSerial.Text = "";
            txtSemi.Text = "";
            txtStatus.Text = "";
            txtSide.Text = "";
            txtQRLocation.Text = "";
            txtQRMag.Text = "";
            txtReview.Text = "";
            txtSerial.Focus();
        }

        private void txtSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!String.IsNullOrEmpty(txtSerial.Text))
                {
                    if (m_level == 8)
                    {
                        deleteLabel();
                        getZonesCount();
                    }
                    else
                        getSerialInfo();
                }
            }
        }


        private void btnScaning_Click(object sender, EventArgs e)
        {
            if (m_level == 10) {
                dlgFinance scan = new dlgFinance(m_id_User);
                this.Hide();
                scan.ShowDialog();
                //getZonesCount();
            }
            else
            {
                scan scan = new scan(m_id_User);
                this.Hide();
                scan.ShowDialog();
                //getZonesCount();
            }
            getZonesCount();
            this.Show();
        }

        private void m_console_TextChanged(object sender, EventArgs e)
        {
            m_console.SelectionStart = m_console.Text.Length;
            m_console.ScrollToCaret();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            try
            {
                //this.TopMost = true;
                this.Focus();
                txtSerial.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //printLabel();
                cmbMags.Focus();
            }
        }
        void updateQty(object sender, DoWorkEventArgs e)
        {
            getZonesCount();
        }
        void updateSemifinish(object sender, DoWorkEventArgs e)
        {
            try
            {
                String semifinish = "";
                DataTable lastStation = null;
                String se_serial_read = txtScanedSerial.Text;
                addLine("[" + DateTime.Now.ToString() + "] " + "Se obtendra el semifishgod de: " + se_serial_read);
                //lastStation = m_db_11.getLastStation(se_serial_read);
                lastStation = m_db_11.getLastStation(se_serial_read);
                String strSer = "";
                if (lastStation.Rows.Count == 0)
                {
                    List<String> panel = m_cogiscan.get_panel(se_serial_read);
                    foreach (String ser in panel)
                    {
                        if (ser != se_serial_read)
                        {
                            strSer = ser;
                            break;
                        }
                    }
                    lastStation = m_db_11.getLastStation(strSer);

                }
                if (lastStation != null && lastStation.Rows.Count > 0)
                {
                    try
                    {
                        DataRow last = lastStation.Rows[0];
                        String operation = last["OPERATION_NAME"].ToString().ToUpper();
                        String djGroup = last["BATCH_ID"].ToString();
                        if (operation == "SMT" || operation == "REFLOW" || operation == "AOI INSPECTION" || operation == "PQC SMT"
                         || operation == "MIDDLE TEST" || operation == "CONFORMAL COATING" || operation == "ICT" || operation == "FCT (MIDDLE TEST)")
                        {
                            String Side = last["ROUTE_STEP_DESC"].ToString();
                            if (!String.IsNullOrEmpty(Side))
                                if (Side == "TOP" || Side == "BOTTOM")
                                    m_oracle.getSemifinish(djGroup, Side == "TOP" ? "SMTT" : "SMTB", ref semifinish);
                                else
                                    m_oracle.getSemifinish(djGroup, "SMTT", ref semifinish);
                            else
                                m_oracle.getSemifinish(djGroup, "SMTT", ref semifinish);
                        }
                        else
                        {
                            if (operation == "PACKING" || operation.Contains("FCT")|| operation == "OQC")
                                m_oracle.getSemifinish(djGroup, "OQC", ref semifinish);
                            else
                                if (operation == "ROUTER CUT" || operation.Contains("MANUAL INSERTION"))
                                m_oracle.getSemifinish(djGroup, "MANU", ref semifinish);
                        }
                        if (String.IsNullOrEmpty(semifinish)) semifinish = "PENDING";
                        //txtSemi.Text = semifinish;
                        m_db_st.updateSemifinish(se_serial_read, djGroup, semifinish);
                        }
                    catch (Exception ex) {
                         addLine("[" + DateTime.Now.ToString() + "] " + ex.Message + " --- " + ex.InnerException);
                    }
                }
                addLine("[" + DateTime.Now.ToString() + "] " + "Se actualizo el semifishgod de: " + se_serial_read);
                
            }
            catch (Exception ex)
            {
                addLine("[" + DateTime.Now.ToString() + "] " + ex.Message + " --- " + ex.InnerException);
            }
        }
        void getCurrentStation()
        {
            try
            {
                String semifinish = "";
                DataTable lastStation = null;
                String se_serial_read = txtSerial.Text;
                addLine("[" + DateTime.Now.ToString() + "] " + "Se obtendra el semifishgod de: " + se_serial_read);
                lastStation = m_db_11.getLastStation(se_serial_read);
                String strSer = "";
                if (lastStation.Rows.Count == 0)
                {
                    List<String> panel = m_cogiscan.get_panel(se_serial_read);
                    foreach (String ser in panel)
                    {
                        if (ser != se_serial_read)
                        {
                            strSer = ser;
                            break;
                        }
                    }
                    lastStation = m_db_11.getLastStation(strSer);

                }
                if (lastStation != null && lastStation.Rows.Count > 0)
                {
                    try
                    {
                        DataRow last = lastStation.Rows[0];
                        String operation = last["OPERATION_NAME"].ToString().ToUpper();
                        String Side = last["ROUTE_STEP_DESC"].ToString();
                        txtSemi.Text = operation;
                        if (Side == "TOP" || Side == "BOTTOM")
                            txtSide.Text = Side;
                        else
                            txtSide.Text = "NA";
                    }
                    catch (Exception ex)
                    {
                        addLine("[" + DateTime.Now.ToString() + "] " + ex.Message + " --- " + ex.InnerException);
                    }
                }
                addLine("[" + DateTime.Now.ToString() + "] " + "Se actualizo el semifishgod de: " + se_serial_read);

            }
            catch (Exception ex)
            {
                addLine("[" + DateTime.Now.ToString() + "] " + ex.Message + " --- " + ex.InnerException);
            }
        }
        void setSemifinish()
        {
            try
            {
                String operation = txtSemi.Text;
                String djGroup = txtDjGroup.Text;
                String se_serial_read = txtScanedSerial.Text;
                String semifinish = "";
                if (operation == "SMT" || operation == "REFLOW" || operation == "AOI INSPECTION" || operation == "PQC SMT"
                    || operation == "MIDDLE TEST" || operation == "CONFORMAL COATING" || operation == "ICT" || operation == "FCT (MIDDLE TEST)" || operation == "CONFORMAL PQC")
                {
                    String Side = txtSide.Text;
                    if (!String.IsNullOrEmpty(Side))
                        if (Side == "TOP" || Side == "BOTTOM")
                            m_oracle.getSemifinish(djGroup, Side == "TOP" ? "SMTT" : "SMTB", ref semifinish);
                        else
                            m_oracle.getSemifinish(djGroup, "SMTT", ref semifinish);
                    else
                        m_oracle.getSemifinish(djGroup, "SMTT", ref semifinish);
                }
                else
                {
                    if (operation == "PACKING" || operation.Contains("FCT") || operation == "OQC" || operation == "ROUTER CUT" || operation.Contains("MANUAL INSERTION"))
                        m_oracle.getSemifinish(djGroup, "OQC", ref semifinish);
                    //else
                    //    if (operation == "ROUTER CUT" || operation.Contains("MANUAL INSERTION"))
                    //    m_oracle.getSemifinish(djGroup, "MANU", ref semifinish);
                }
                if (String.IsNullOrEmpty(semifinish)) semifinish = "PENDING";
                txtSemi.Text = semifinish;
                m_db_st.updateSemifinish(se_serial_read, djGroup, semifinish);
                addLine("[" + DateTime.Now.ToString() + "] " + "Se actualizo el semifishgod de: " + se_serial_read);
            }
            catch (Exception ex)
            {
                addLine("[" + DateTime.Now.ToString() + "] " + ex.Message + " --- " + ex.InnerException);
            }
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                    Console.WriteLine("You canceled!");
                else if (e.Error != null)
                    Console.WriteLine("Worker exception: " + e.Error.ToString());
                else
                {
                    getLastFive();
                    Console.WriteLine("Complete: " + e.Result);      // from DoWork
                }
            }
            catch (Exception ex)
            {
                //logger.Error(ex, "[bw_RunWorkerCompleted] Error...");
                addLine("[" + DateTime.Now.ToString() + "] " + ex.Message + " --- " + ex.InnerException);
            }
        }
        private void getZonesCount()
        {
            var zones = m_db_st.getZonesQty();
            int y = 210;
            foreach (getZonesQty_Result zone in zones)
            {
                Control c = Controls.Find("progressBar" + zone.ZONE, true).FirstOrDefault();
                TextProgressBar b = null;
                if (c == null)
                {
                    b = new TextProgressBar();
                    b.Location = new System.Drawing.Point(300, y);
                    b.Name = "progressBar" + zone.ZONE;
                    b.Width = 350;
                    b.Height = 20;
                    b.Minimum = 0;
                    b.Maximum = Convert.ToInt32(zone.TOTAL);
                    b.Step = 1;
                    b.Value = Convert.ToInt32(zone.COUNT);
                    b.Text = "Zona: " + zone.ZONE + " -- " + Convert.ToString(zone.COUNT) + " validados de " + Convert.ToString(zone.TOTAL) + " impresos.";
                    Controls.Add(b);
                }
                else
                {
                    b = (TextProgressBar)c;
                    b.Maximum = Convert.ToInt32(zone.TOTAL);
                    b.Value = Convert.ToInt32(zone.COUNT);
                    b.Text = "Zona: " + zone.ZONE + " -- " + Convert.ToString(zone.COUNT) + " validados de " + Convert.ToString(zone.TOTAL) + " impresos.";
                }

                b.BringToFront();
                this.Invalidate();
                y += 25;

            }

        }
        void GetSemifinish(String model_name, ref String semifinish, String route)
        {
            try
            {
                String operation = txtSemi.Text;
                String djGroup = txtDjGroup.Text;
                String se_serial_read = txtScanedSerial.Text;
                String[] splitRoute = route.Split('-');
                String smt = "";

                foreach (String routeStep in splitRoute)
                {
                    if (routeStep.Contains("SMT"))
                    {
                        smt = routeStep;
                    }
                }
                //String semifinish = "";
                //getSemifinishByModel_Result model = m_db_st.getSemifinishByModel(model_name).First();
                if (smt.Equals("SMT") || smt.Equals("SMTT")) {
                    getSemiSMTTByModel_Result semiTop = m_db_wip_cfg.getSemiSMTTByModel(model_name).First();
                    if (semiTop.RESULT == 1)
                        semifinish = semiTop.SEMIFINISH;
                    else semifinish = "PENDING";
                }
                else
                    if (smt.Equals("SMTB"))
                    {
                        getSemiSMTByModel_Result semiBtm = m_db_wip_cfg.getSemiSMTByModel(model_name).First();
                        if (semiBtm.RESULT == 1)
                            semifinish = semiBtm.SEMIFINISH;
                        else semifinish = "PENDING";
                    }

                //if (model.MODEL_NAME.Equals("NOT_EXISTS")) semifinish = txtSemi.Text = "PENDING";
                //else semifinish = txtSemi.Text = model.SEMIFINISH;
                //m_db_st.updateSemifinish(se_serial_read, djGroup, semifinish);
                //addLine("[" + DateTime.Now.ToString() + "] " + "Se actualizo el semifishgod de: " + se_serial_read);
            }
            catch (Exception ex)
            {
                addLine("[" + DateTime.Now.ToString() + "] " + ex.Message + " --- " + ex.InnerException);
            }
        }

        private void txtSerial_TextChanged(object sender, EventArgs e)
        {

        }

        private void timerUpdateQty_Tick(object sender, EventArgs e)
        {
            if (!_bwUpdateQty.IsBusy)
                _bwUpdateQty.RunWorkerAsync();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //timerUpdateQty.Stop();
            Cursor = Cursors.Arrow;
        }

        private void selMag_CheckedChanged(object sender, EventArgs e)
        {
            type_cont = 2;
        }

        private void selBox_CheckedChanged(object sender, EventArgs e)
        {
            type_cont = 1;
        }

        private void dataLast_Click(object sender, EventArgs e)
        {
            txtSerial.Focus();
        }

        private void m_console_Click(object sender, EventArgs e)
        {
            txtSerial.Focus();
        }

        private void m_console_Enter(object sender, EventArgs e)
        {
            txtSerial.Focus();
        }

        private void kryptonRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton1.Checked)
            {
                btnDelete.Visible = false;
                btnPrintLabel.Visible = true;
            }
        }

        private void kryptonRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton2.Checked)
            {
                btnDelete.Visible = true;
                btnPrintLabel.Visible = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteLabel();
        }

        private void txtQRMag_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtQRLocation.Focus();
            }
        }
    }
}
