using MetroFramework.Forms;
using stocktake_V4.Class;
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
    public partial class notInWip : MetroForm
    {
        private CReleaseInfo m_serialInfo;
        CCogiscanCGSDW m_dbDB2;
        private String m_serial;
        private BackgroundWorker _bw;
        CCogiscan m_cogiscan;
        bool resultRelease = true;
        CAlert m_alerts;

        public bool ResultRelease { get => resultRelease; set => resultRelease = value; }

        public notInWip(String serial)
        {
            InitializeComponent();
            m_serial = serial;
            m_serialInfo = new CReleaseInfo();
            m_dbDB2 = new CCogiscanCGSDW();
            m_cogiscan = new CCogiscan();
            m_alerts = new CAlert();
        }

        private void notInWip_Load(object sender, EventArgs e)
        {
            cmd.Multiline = true;
            initThreads();
            addLine("Se dara release a la pieza: " + m_serial + "\n");
            _bw.RunWorkerAsync();

        }
        delegate void playWarningDelegate();
        private void playWarning()
        {
            if (m_alerts.InvokeRequired)
            {
                playWarningDelegate delegado = new playWarningDelegate(playWarning);
                m_alerts.Invoke(delegado);
            }
            else
            {
                try
                {
                    m_alerts.playWarning();
                }
                catch (Exception ex) { }
            }
        }
        delegate void playSuccessDelegate();
        private void playSuccess()
        {
            if (m_alerts.InvokeRequired)
            {
                playSuccessDelegate delegado = new playSuccessDelegate(playSuccess);
                m_alerts.Invoke(delegado);
            }
            else
            {
                try
                {
                    m_alerts.playSuccess();
                }
                catch (Exception ex) { }
            }
        }
        delegate void addLineDelegate(string texto);
        private void addLine(string texto)
        {
            if (cmd.InvokeRequired)
            {
                addLineDelegate delegado = new addLineDelegate(addLine);
                object[] parametros = new object[] { texto };
                cmd.Invoke(delegado, parametros);
            }
            else
            {
                try
                {
                    if (cmd.TextLength > 100000)
                    {
                        cmd.Clear();
                    }
                    if (!String.IsNullOrEmpty(texto) && !String.IsNullOrWhiteSpace(texto))
                    {
                        //cmd.SelectionColor = m_color;
                        cmd.AppendText(texto + "\n");
                    }

                }
                catch (Exception ex) { }
            }
        }
        private void initThreads()
        {
            try
            {
                _bw = new BackgroundWorker
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };
                _bw.DoWork += bw_process_NOTINWIP;
                _bw.WorkerSupportsCancellation = true;
                //_bw.ProgressChanged += bw_ProgressChanged;
                _bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            }
            catch (Exception ex)
            {
                //logger.Error(ex, "[initThreads] Error...");
            }

        }
        void bw_process_NOTINWIP(object sender, DoWorkEventArgs e) {
            dlgMessage dlgMessage = new dlgMessage("");
            bool res = false;
            addLine("Obteniendo información de la pieza " + m_serial + "\n");

            m_serialInfo = m_dbDB2.getSerialInfo(m_serial, ref res);

            if (!res)
            {
                //playWarning();
                dlgMessage.Message = "Escaneaste el serial del panel! \nEscanea la etiqueta de una PCB para poder liberar la pieza.";
                dlgMessage.ShowDialog();
                ResultRelease = false;
                _bw.CancelAsync();
                e.Cancel = true;
                return;
                //this.Close();
            }

            addLine("SERIAL: " + m_serialInfo.PRODUCT_ID);
            addLine("PANEL_ID: " + m_serialInfo.PANEL_ID);
            addLine("BATCH_ID: " + m_serialInfo.BATCH_ID);
            addLine("PART_NUMBER: " + m_serialInfo.PRODUCT_PN);
            addLine("ROUTE: " + m_serialInfo.ROUTE_NAME);
            addLine("REVIEW: " + m_serialInfo.PRODUCT_PN_REV);
            addLine("DJ QTY: " + m_serialInfo.QTY.ToString());

            String resCogiscan = m_cogiscan.Release(m_serialInfo);

            addLine("Intentando dar Release...");
            addLine("Resultado: " + resCogiscan);

            if (resCogiscan.Contains("Exception"))
            {
                //playWarning();
                dlgMessage.Message = "No se pudo dar Release en Cogiscan a la pieza!.";
                dlgMessage.ShowDialog();
                ResultRelease = false;
                _bw.CancelAsync();
                e.Cancel = true;
                return;

                //this.Close();
            }
            else
            {
                //playSuccess();
                ResultRelease = true;
            }
            //_bw.CancelAsync();
            //this.Close();

        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    addLine("-----------------");
                    this.Close();
                }
                else if (e.Error != null)
                {
                    addLine("Worker exception: " + e.Error.ToString());
                }
                else
                {
                    addLine("Complete: " + e.Result);      // from DoWork
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                //logger.Error(ex, "[bw_RunWorkerCompleted] Error...");
            }
        }

        private void closeDialog()
        {
            this.Close();
        }
        private void notInWip_Shown(object sender, EventArgs e)
        {

            
        }
    }
}
