
namespace stocktake_V4
{
    partial class dlgMessage
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
            this.lblMessage = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lblMessage.Location = new System.Drawing.Point(20, 30);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(405, 23);
            this.lblMessage.StateNormal.LongText.Color1 = System.Drawing.Color.Red;
            this.lblMessage.StateNormal.LongText.Color2 = System.Drawing.Color.Red;
            this.lblMessage.StateNormal.ShortText.Color1 = System.Drawing.Color.Red;
            this.lblMessage.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Values.Text = "Mesage";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(20, 83);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(405, 21);
            this.kryptonLabel1.StateNormal.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel1.StateNormal.LongText.Color2 = System.Drawing.Color.Red;
            this.kryptonLabel1.StateNormal.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "PRESIONA \"SHIFT + ENTER\" PARA CONTINUAR";
            // 
            // dlgMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 124);
            this.ControlBox = false;
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.lblMessage);
            this.DisplayHeader = false;
            this.Name = "dlgMessage";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Load += new System.EventHandler(this.dlgMessage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dlgMessage_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblMessage;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}