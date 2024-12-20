namespace stocktake_V4
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btnAccept = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnExit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbZones = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPass = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtUser = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.kryptonPanel4 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.selMag = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.selBox = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panelQuarantine = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.chkQuarantine = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.sheet = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbZones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel4)).BeginInit();
            this.kryptonPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelQuarantine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelQuarantine.Panel)).BeginInit();
            this.panelQuarantine.Panel.SuspendLayout();
            this.panelQuarantine.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(293, 215);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(90, 25);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Values.Text = "Aceptar";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnAccept_KeyPress);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(184, 215);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 25);
            this.btnExit.TabIndex = 1;
            this.btnExit.Values.Text = "Salir";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(19, 50);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonGroupBox1.Panel.Controls.Add(this.cmbZones);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtPass);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtUser);
            this.kryptonGroupBox1.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonGroupBox1_Panel_Paint);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(231, 153);
            this.kryptonGroupBox1.TabIndex = 2;
            this.kryptonGroupBox1.Values.Heading = "";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(29, 99);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(41, 20);
            this.kryptonLabel4.TabIndex = 5;
            this.kryptonLabel4.Values.Text = "Zona:";
            // 
            // cmbZones
            // 
            this.cmbZones.DropDownWidth = 133;
            this.cmbZones.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Ribbon;
            this.cmbZones.Location = new System.Drawing.Point(76, 99);
            this.cmbZones.Name = "cmbZones";
            this.cmbZones.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.cmbZones.Size = new System.Drawing.Size(133, 21);
            this.cmbZones.TabIndex = 4;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(5, 59);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(65, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Password:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(32, 23);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "User:";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(76, 59);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(133, 23);
            this.txtPass.TabIndex = 1;
            this.txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_KeyPress);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(76, 20);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(133, 23);
            this.txtUser.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(293, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(19, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(122, 22);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // kryptonPanel4
            // 
            this.kryptonPanel4.Controls.Add(this.selMag);
            this.kryptonPanel4.Controls.Add(this.selBox);
            this.kryptonPanel4.Location = new System.Drawing.Point(279, 74);
            this.kryptonPanel4.Name = "kryptonPanel4";
            this.kryptonPanel4.Size = new System.Drawing.Size(104, 83);
            this.kryptonPanel4.TabIndex = 14;
            // 
            // selMag
            // 
            this.selMag.Checked = true;
            this.selMag.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.selMag.Location = new System.Drawing.Point(15, 44);
            this.selMag.Name = "selMag";
            this.selMag.Size = new System.Drawing.Size(79, 20);
            this.selMag.TabIndex = 1;
            this.selMag.Values.Text = "Magazine";
            this.selMag.CheckedChanged += new System.EventHandler(this.selMag_CheckedChanged);
            // 
            // selBox
            // 
            this.selBox.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.selBox.Location = new System.Drawing.Point(15, 17);
            this.selBox.Name = "selBox";
            this.selBox.Size = new System.Drawing.Size(48, 20);
            this.selBox.TabIndex = 0;
            this.selBox.Values.Text = "BOX";
            this.selBox.CheckedChanged += new System.EventHandler(this.selBox_CheckedChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(276, 50);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(107, 20);
            this.kryptonLabel3.TabIndex = 15;
            this.kryptonLabel3.Values.Text = "Tipo de escaneo:";
            // 
            // panelQuarantine
            // 
            this.panelQuarantine.Location = new System.Drawing.Point(275, 163);
            this.panelQuarantine.Name = "panelQuarantine";
            // 
            // panelQuarantine.Panel
            // 
            this.panelQuarantine.Panel.Controls.Add(this.chkQuarantine);
            this.panelQuarantine.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panelQuarantine_Panel_Paint);
            this.panelQuarantine.Size = new System.Drawing.Size(108, 40);
            this.panelQuarantine.TabIndex = 16;
            this.panelQuarantine.Values.Heading = "";
            // 
            // chkQuarantine
            // 
            this.chkQuarantine.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkQuarantine.Location = new System.Drawing.Point(8, 7);
            this.chkQuarantine.Name = "chkQuarantine";
            this.chkQuarantine.Size = new System.Drawing.Size(90, 20);
            this.chkQuarantine.TabIndex = 0;
            this.chkQuarantine.Values.Text = "Cuarentena";
            this.chkQuarantine.CheckedChanged += new System.EventHandler(this.chkQuarantine_CheckedChanged);
            // 
            // sheet
            // 
            this.sheet.Location = new System.Drawing.Point(19, 217);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(90, 25);
            this.sheet.TabIndex = 17;
            this.sheet.Values.Text = "Hojota";
            this.sheet.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::stocktake_V4.Properties.Resources.backHeader;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(403, 254);
            this.Controls.Add(this.sheet);
            this.Controls.Add(this.panelQuarantine);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonPanel4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAccept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Shown += new System.EventHandler(this.Login_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbZones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel4)).EndInit();
            this.kryptonPanel4.ResumeLayout(false);
            this.kryptonPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelQuarantine.Panel)).EndInit();
            this.panelQuarantine.Panel.ResumeLayout(false);
            this.panelQuarantine.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelQuarantine)).EndInit();
            this.panelQuarantine.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAccept;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExit;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPass;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel4;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton selMag;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton selBox;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbZones;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox panelQuarantine;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkQuarantine;
        private ComponentFactory.Krypton.Toolkit.KryptonButton sheet;
    }
}