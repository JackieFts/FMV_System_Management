namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    partial class fFunc_Export
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
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.btnExport = new FMV_SYSTEM_MANAGEMENTS.Common.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup1.Location = new System.Drawing.Point(0, 0);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.radioGroup1.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.Appearance.Options.UseForeColor = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Only Tools && Jigs", true, null, "ToolJig"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Only Parts", true, null, "Part"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Both Tools && Jigs and Parts", true, null, "Both")});
            this.radioGroup1.Size = new System.Drawing.Size(356, 136);
            this.radioGroup1.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExport.BorderColor = System.Drawing.Color.MediumOrchid;
            this.btnExport.BorderRadius = 10;
            this.btnExport.BorderSize = 2;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnExport.ForeColor = System.Drawing.Color.Blue;
            this.btnExport.Location = new System.Drawing.Point(12, 143);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(332, 51);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "EXPORT";
            this.btnExport.TextColor = System.Drawing.Color.Blue;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // fFunc_Export
            // 
            this.AcceptButton = this.btnExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 206);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.radioGroup1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fFunc_Export";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EXPORT TO EXCEL";
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private Common.CustomButton btnExport;
    }
}