using stocktake_V4.Class;
using stocktake_V4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace stocktake_V4
{
    public partial class Login : Form
    {
        Thread splashthread;
        int m_type_scan;
        CAlert m_alerts;
        COracle m_oracle;
        siixsem_stocktake_dbEntities m_db = new siixsem_stocktake_dbEntities();
        private bool m_quarantine;
        public Login()
        {
            InitializeComponent();
            m_type_scan = 2;
            m_alerts = new CAlert();
            try
            {
                m_oracle = new COracle("192.168.0.23", "SEMPROD");
            }
            catch (Exception EX) { }

        }
        public static string GetSHA1(String texto)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            Byte[] textOriginal = ASCIIEncoding.Default.GetBytes(texto);
            Byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();

            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            var zones = m_db.getZones();
            cmbZones.DataSource = zones;
            cmbZones.DisplayMember = "AREA";
            cmbZones.ValueMember = "ID";
            txtUser.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            loginSimos();
        }

        //private void login()
        //{
        //    int idUser = 0;
        //    int level = 0;
        //    String userName = "";
        //    if (String.IsNullOrEmpty(txtUser.Text))
        //    {
        //        m_alerts.playWarning();
        //        MessageBox.Show("Debes ingresar un usuario.", "Login...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtUser.Focus();
        //        return;
        //    }

        //    if (String.IsNullOrEmpty(txtPass.Text))
        //    {
        //        m_alerts.playWarning();
        //        MessageBox.Show("Debes ingresar tu password.", "Login...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtPass.Focus();
        //        return;
        //    }
        //    progressBar1.Visible = true;
        //    //splashthread = new Thread(new ThreadStart(SplashScreen.ShowSplashScreen));
        //    //splashthread.IsBackground = true;
        //    //splashthread.Start();
        //    if (SignInDB(txtUser.Text.ToUpper(), txtPass.Text.ToUpper(), ref idUser, ref userName, ref level))
        //    {

        //        Form1 Main = new Form1(idUser, userName, level,m_type_scan);
        //        this.Hide();
        //        try
        //        {
        //            //splashthread.Abort();
        //            //SplashScreen.CloseSplashScreen();
        //            m_alerts.playSuccess();
        //            Main.ShowDialog();
        //            Cursor = Cursors.Arrow;
        //        }
        //        catch(Exception ex)
        //        {
        //            m_alerts.playWarning();
        //            MessageBox.Show(ex.Message);
        //        }
        //        this.Show();
        //        txtUser.Text = "";
        //        txtPass.Text = "";
        //        txtUser.Focus();
        //    }
        //    else
        //    {
        //        m_alerts.playWarning();
        //        MessageBox.Show("Usuario o password incorrectos.", "Login...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtUser.Text = "";
        //        txtPass.Text = "";
        //        txtUser.Focus();
        //    }
        //    //splashthread.Abort();
        //    //SplashScreen.CloseSplashScreen();
        //    progressBar1.Visible = false;
        //}
        private void loginSimos()
        {
            CSimosUser user = new CSimosUser();
            int idUser = 0;
            int level = 0;
            String userName = "";
            if (String.IsNullOrEmpty(txtUser.Text))
            {
                m_alerts.playWarning();
                MessageBox.Show("Debes ingresar un usuario.", "Login...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtPass.Text))
            {
                m_alerts.playWarning();
                MessageBox.Show("Debes ingresar tu password.", "Login...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return;
            }
            progressBar1.Visible = true;
            //splashthread = new Thread(new ThreadStart(SplashScreen.ShowSplashScreen));
            //splashthread.IsBackground = true;
            //splashthread.Start();
            if (SignInSimosDB(txtUser.Text, txtPass.Text, ref user))
            {
                DataRowView row = cmbZones.Items[cmbZones.SelectedIndex] as DataRowView;
                
                int idArea = Convert.ToInt32(cmbZones.SelectedValue);

                Form1 Main = new Form1(user, m_type_scan, idArea,m_quarantine);
                this.Hide();
                try
                {
                    //splashthread.Abort();
                    //SplashScreen.CloseSplashScreen();
                    m_alerts.playSuccess();
                    Main.ShowDialog();
                    Cursor = Cursors.Arrow;
                }
                catch (Exception ex)
                {
                    m_alerts.playWarning();
                    MessageBox.Show(ex.Message);
                }
                this.Show();
                txtUser.Text = "";
                txtPass.Text = "";
                txtUser.Focus();
            }
            else
            {
                m_alerts.playWarning();
                MessageBox.Show("Usuario o password incorrectos.", "Login...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Text = "";
                txtPass.Text = "";
                txtUser.Focus();
            }
            //splashthread.Abort();
            //SplashScreen.CloseSplashScreen();
            progressBar1.Visible = false;
        }
        private bool SignInDB(String user, string pass, ref int idUser, ref String userName, ref int level)
        {
            siixsem_main_dbEntities db = new siixsem_main_dbEntities();
            string strPass = GetSHA1(pass);
            Cursor = Cursors.WaitCursor;
            validate_user_Result res = db.validate_user(user, strPass).First();
            //Cursor = Cursors.Arrow;

            idUser = res.se_id_user;
            userName = res.se_name;
            level = res.se_level;
            

            return res.RESULT == 1 ? true : false;
        }

        private bool SignInSimosDB(String user, string pass, ref CSimosUser loginUser)
        {
            siixsem_main_dbEntities db = new siixsem_main_dbEntities();
            //string strPass = GetSHA1(pass);
            //loginUser = new CSimosUser();
            Cursor = Cursors.WaitCursor;
            bool res = m_oracle.queryUser(user, pass, ref loginUser);
            //Cursor = Cursors.Arrow;

            return res;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                loginSimos();
            }
        }

        private void btnAccept_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                loginSimos();
            }
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            txtUser.Focus();
        }

        private void selBox_CheckedChanged(object sender, EventArgs e)
        {
            m_type_scan = 1;
        }

        private void selMag_CheckedChanged(object sender, EventArgs e)
        {
            m_type_scan = 2;
        }

        private void kryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkQuarantine_CheckedChanged(object sender, EventArgs e)
        {
            if (chkQuarantine.Checked) m_quarantine = true;
            else m_quarantine = false;
        }

        private void panelQuarantine_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            FormSheet Main = new FormSheet();
            this.Hide();
            try
            {
                //splashthread.Abort();
                //SplashScreen.CloseSplashScreen();
                m_alerts.playSuccess();
                Main.ShowDialog();
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                m_alerts.playWarning();
                MessageBox.Show(ex.Message);
            }
            this.Show();

        }
    }
}
