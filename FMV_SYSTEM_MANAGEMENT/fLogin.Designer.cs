namespace FMV_SYSTEM_MANAGEMENT
{
    partial class fLogin
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
            gcList = new DevExpress.XtraGrid.GridControl();
            gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)gcList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvList).BeginInit();
            SuspendLayout();
            // 
            // gcList
            // 
            gcList.Dock = System.Windows.Forms.DockStyle.Fill;
            gcList.Location = new System.Drawing.Point(0, 0);
            gcList.MainView = gvList;
            gcList.Name = "gcList";
            gcList.Size = new System.Drawing.Size(1135, 718);
            gcList.TabIndex = 0;
            gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvList });
            // 
            // gvList
            // 
            gvList.GridControl = gcList;
            gvList.Name = "gvList";
            gvList.OptionsFind.FindDelay = 100;
            gvList.OptionsView.ShowAutoFilterRow = true;
            gvList.OptionsView.ShowGroupPanel = false;
            // 
            // fMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1135, 718);
            Controls.Add(gcList);
            Name = "fMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SYSTEM MANAGEMENT";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            FormClosing += fMain_FormClosing;
            Load += fMain_Load;
            ((System.ComponentModel.ISupportInitialize)gcList).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
    }
}