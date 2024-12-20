
namespace stocktake_V4
{
    partial class dlgFinance
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
            this.dataLast = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.finQty = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtMessage = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtLabel = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLast
            // 
            this.dataLast.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataLast.Location = new System.Drawing.Point(26, 165);
            this.dataLast.Name = "dataLast";
            this.dataLast.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataLast.Size = new System.Drawing.Size(1106, 175);
            this.dataLast.TabIndex = 14;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonButton1);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.finQty);
            this.kryptonPanel1.Controls.Add(this.txtMessage);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.txtLabel);
            this.kryptonPanel1.Location = new System.Drawing.Point(26, 51);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(775, 88);
            this.kryptonPanel1.TabIndex = 13;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(730, 3);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparklePurple;
            this.kryptonButton1.Size = new System.Drawing.Size(42, 23);
            this.kryptonButton1.TabIndex = 5;
            this.kryptonButton1.Values.Text = "Guardar";
            this.kryptonButton1.Visible = false;
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(589, 17);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(66, 20);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Cantidad:";
            // 
            // finQty
            // 
            this.finQty.Location = new System.Drawing.Point(589, 43);
            this.finQty.Name = "finQty";
            this.finQty.Size = new System.Drawing.Size(100, 23);
            this.finQty.TabIndex = 3;
            this.finQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.finQty_KeyPress);
            // 
            // txtMessage
            // 
            this.txtMessage.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.txtMessage.Location = new System.Drawing.Point(14, 51);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(6, 2);
            this.txtMessage.StateNormal.ShortText.Color1 = System.Drawing.Color.Green;
            this.txtMessage.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.TabIndex = 2;
            this.txtMessage.Values.Text = "";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(90, 16);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(188, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Escanea etiqueta de magazine:";
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(90, 43);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(471, 23);
            this.txtLabel.TabIndex = 0;
            this.txtLabel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLabel_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::stocktake_V4.Properties.Resources.logoTrans;
            this.pictureBox1.Location = new System.Drawing.Point(870, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // dlgFinance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::stocktake_V4.Properties.Resources.back3;
            this.BackMaxSize = 1200;
            this.ClientSize = new System.Drawing.Size(1155, 363);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataLast);
            this.Controls.Add(this.kryptonPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgFinance";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Load += new System.EventHandler(this.dlgFinance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataLast;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox finQty;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel txtMessage;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}