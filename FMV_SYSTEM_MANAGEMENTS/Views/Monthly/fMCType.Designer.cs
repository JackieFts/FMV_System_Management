namespace FMV_SYSTEM_MANAGEMENTS.Views.Monthly
{
    partial class fMCType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMCType));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOut = new FMV_SYSTEM_MANAGEMENTS.Common.CustomButton();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BRAND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MCTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOut);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 624);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 72);
            this.panel1.TabIndex = 8;
            // 
            // btnOut
            // 
            this.btnOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnOut.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnOut.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnOut.BorderRadius = 20;
            this.btnOut.BorderSize = 2;
            this.btnOut.FlatAppearance.BorderSize = 0;
            this.btnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOut.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnOut.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnOut.Image = ((System.Drawing.Image)(resources.GetObject("btnOut.Image")));
            this.btnOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOut.Location = new System.Drawing.Point(68, 13);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(250, 47);
            this.btnOut.TabIndex = 44;
            this.btnOut.Text = "SAVE";
            this.btnOut.TextColor = System.Drawing.SystemColors.Highlight;
            this.btnOut.UseVisualStyleBackColor = false;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // gcList
            // 
            this.gcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcList.Location = new System.Drawing.Point(0, 0);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(387, 624);
            this.gcList.TabIndex = 9;
            this.gcList.UseEmbeddedNavigator = true;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // gvList
            // 
            this.gvList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BRAND,
            this.MCTYPE});
            this.gvList.GridControl = this.gcList;
            this.gvList.Name = "gvList";
            this.gvList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvList.OptionsFind.AlwaysVisible = true;
            this.gvList.OptionsFind.FindDelay = 100;
            this.gvList.OptionsSelection.MultiSelect = true;
            this.gvList.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvList.OptionsView.ShowGroupPanel = false;
            // 
            // BRAND
            // 
            this.BRAND.Caption = "BRAND";
            this.BRAND.FieldName = "BRAND";
            this.BRAND.MinWidth = 25;
            this.BRAND.Name = "BRAND";
            this.BRAND.Visible = true;
            this.BRAND.VisibleIndex = 0;
            this.BRAND.Width = 94;
            // 
            // MCTYPE
            // 
            this.MCTYPE.Caption = "MCTYPE";
            this.MCTYPE.FieldName = "MCTYPE";
            this.MCTYPE.MinWidth = 25;
            this.MCTYPE.Name = "MCTYPE";
            this.MCTYPE.Visible = true;
            this.MCTYPE.VisibleIndex = 1;
            this.MCTYPE.Width = 94;
            // 
            // fMCType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 696);
            this.Controls.Add(this.gcList);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "fMCType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MCTYPE SETTING";
            this.Load += new System.EventHandler(this.fMCType_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Common.CustomButton btnOut;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraGrid.Columns.GridColumn BRAND;
        private DevExpress.XtraGrid.Columns.GridColumn MCTYPE;
        private DevExpress.XtraGrid.GridControl gcList;
    }
}