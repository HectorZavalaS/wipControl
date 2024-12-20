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
    public partial class SplashScreenFrm : MetroForm
    {
        delegate void StringParameterDelegate(string Text);
        delegate void StringParameterWithStatusDelegate(string Text, TypeOfMessage tom);
        delegate void SplashShowCloseDelegate();

        /// <summary>
        /// To ensure splash screen is closed using the API and not by keyboard or any other things
        /// </summary>
        bool CloseSplashScreenFlag = false;

        /// <summary>
        /// Base constructor
        /// </summary>
        public SplashScreenFrm()
        {
            InitializeComponent();
            //this.metroLabel1.Parent = this.pictureBox1;
            this.metroLabel1.BackColor = Color.Transparent;
           // label1.ForeColor = Color.Green;

            //this.progressBar1.Parent = this.pictureBox1;
            //this.progressBar1.BackColor = Color.Transparent;

            metroProgressBar1.Show();
        }

        /// <summary>
        /// Displays the splashscreen
        /// </summary>
        public void ShowSplashScreen()
        {
            try
            {
                this.TopMost = true;
                if (InvokeRequired)
                {
                    // We're not in the UI thread, so we need to call BeginInvoke
                    BeginInvoke(new SplashShowCloseDelegate(ShowSplashScreen));
                    return;
                }

                this.Show();
                Application.Run(this);
            }
            catch (Exception ex) { }

        }

        /// <summary>
        /// Closes the SplashScreen
        /// </summary>
        public void CloseSplashScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(CloseSplashScreen));
                return;
            }
            CloseSplashScreenFlag = true;
            this.Close();
            this.TopMost = false;
        }

        /// <summary>
        /// Update text in default green color of success message
        /// </summary>
        /// <param name="Text">Message</param>
        public void UdpateStatusText(string Text)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UdpateStatusText), new object[] { Text });
                return;
            }
            // Must be on the UI thread if we've got this far
            //metroLabel1.ForeColor = Color.Green;
            metroLabel1.Text = Text;
        }


        /// <summary>
        /// Update text with message color defined as green/yellow/red/ for success/warning/failure
        /// </summary>
        /// <param name="Text">Message</param>
        /// <param name="tom">Type of Message</param>
        public void UdpateStatusTextWithStatus(string Text, TypeOfMessage tom)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterWithStatusDelegate(UdpateStatusTextWithStatus), new object[] { Text, tom });
                return;
            }
            // Must be on the UI thread if we've got this far
            switch (tom)
            {
                case TypeOfMessage.Error:
                    metroLabel1.ForeColor = Color.Red;
                    break;
                case TypeOfMessage.Warning:
                    metroLabel1.ForeColor = Color.Yellow;
                    break;
                case TypeOfMessage.Success:
                    metroLabel1.ForeColor = Color.Green;
                    break;
            }
            metroLabel1.Text = Text;

        }

        /// <summary>
        /// Prevents the closing of form other than by calling the CloseSplashScreen function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplashForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseSplashScreenFlag == false)
                e.Cancel = true;
        }

        private void SplashScreenFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
