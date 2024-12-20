
namespace stocktake_V4
{
    partial class notInWip
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
            this.cmd = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cmd
            // 
            this.cmd.BackColor = System.Drawing.Color.Black;
            this.cmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd.ForeColor = System.Drawing.Color.White;
            this.cmd.Location = new System.Drawing.Point(20, 60);
            this.cmd.Name = "cmd";
            this.cmd.Size = new System.Drawing.Size(760, 370);
            this.cmd.TabIndex = 0;
            this.cmd.Text = "";
            // 
            // notInWip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.cmd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "notInWip";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Load += new System.EventHandler(this.notInWip_Load);
            this.Shown += new System.EventHandler(this.notInWip_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox cmd;
    }
}