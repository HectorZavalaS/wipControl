namespace stocktake_V4
{
    partial class FormSheet
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
            this.search = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dj_data = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(249, 51);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(90, 25);
            this.search.TabIndex = 1;
            this.search.Values.Text = "buscar";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // dj_data
            // 
            this.dj_data.Location = new System.Drawing.Point(59, 53);
            this.dj_data.Name = "dj_data";
            this.dj_data.Size = new System.Drawing.Size(157, 23);
            this.dj_data.TabIndex = 2;
            // 
            // FormSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 171);
            this.Controls.Add(this.dj_data);
            this.Controls.Add(this.search);
            this.Name = "FormSheet";
            this.Text = "Impresion de hojas viajeras";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonButton search;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox dj_data;
    }
}