namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    partial class fFunc_ProgressBar
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 43);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(573, 25);
            this.progressBar1.TabIndex = 15;
            // 
            // labelStatus
            // 
            this.labelStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelStatus.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelStatus.Appearance.Options.UseFont = true;
            this.labelStatus.Appearance.Options.UseForeColor = true;
            this.labelStatus.Location = new System.Drawing.Point(13, 17);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 1);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(97, 18);
            this.labelStatus.TabIndex = 14;
            this.labelStatus.Text = "Processing...";
            // 
            // fProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 78);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fProgressBar";
            this.Text = "fProgressBar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar progressBar1;
        private DevExpress.XtraEditors.LabelControl labelStatus;
    }
}