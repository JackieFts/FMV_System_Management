namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    partial class fHis_PartIn
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHis_PartIn));
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gcPartIn = new DevExpress.XtraGrid.GridControl();
            this.gvPartIn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PARTNUMBER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LOCATION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DATEIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STAFFNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPartIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPartIn)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(448, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 21);
            this.label2.TabIndex = 50;
            this.label2.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(145, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 21);
            this.label4.TabIndex = 49;
            this.label4.Text = "From";
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd-MM-yyyy";
            this.dtFrom.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(149, 38);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(190, 28);
            this.dtFrom.TabIndex = 47;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            this.dtFrom.Leave += new System.EventHandler(this.dtFrom_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtTo);
            this.panel2.Controls.Add(this.dtFrom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1180, 77);
            this.panel2.TabIndex = 6;
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd-MM-yyyy";
            this.dtTo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(452, 38);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(190, 28);
            this.dtTo.TabIndex = 48;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            this.dtTo.Leave += new System.EventHandler(this.dtTo_Leave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(132, 30);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(131, 26);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1180, 64);
            this.label1.TabIndex = 1;
            this.label1.Text = "PART IN HISTORY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1180, 64);
            this.panel1.TabIndex = 4;
            // 
            // gcPartIn
            // 
            this.gcPartIn.AllowDrop = true;
            this.gcPartIn.ContextMenuStrip = this.contextMenuStrip1;
            this.gcPartIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPartIn.Location = new System.Drawing.Point(0, 141);
            this.gcPartIn.MainView = this.gvPartIn;
            this.gcPartIn.Name = "gcPartIn";
            this.gcPartIn.Size = new System.Drawing.Size(1180, 538);
            this.gcPartIn.TabIndex = 7;
            this.gcPartIn.UseDisabledStatePainter = false;
            this.gcPartIn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPartIn});
            // 
            // gvPartIn
            // 
            this.gvPartIn.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NAME,
            this.PARTNUMBER,
            this.LOCATION,
            this.QTY,
            this.DATEIN,
            this.STAFFNAME});
            this.gvPartIn.GridControl = this.gcPartIn;
            this.gvPartIn.Name = "gvPartIn";
            this.gvPartIn.OptionsFind.AlwaysVisible = true;
            this.gvPartIn.OptionsFind.FindDelay = 100;
            this.gvPartIn.OptionsView.ShowAutoFilterRow = true;
            this.gvPartIn.OptionsView.ShowGroupPanel = false;
            // 
            // NAME
            // 
            this.NAME.Caption = "NAME";
            this.NAME.FieldName = "NAME";
            this.NAME.MinWidth = 25;
            this.NAME.Name = "NAME";
            this.NAME.OptionsColumn.AllowEdit = false;
            this.NAME.Visible = true;
            this.NAME.VisibleIndex = 0;
            this.NAME.Width = 139;
            // 
            // PARTNUMBER
            // 
            this.PARTNUMBER.Caption = "PARTNUMBER";
            this.PARTNUMBER.FieldName = "PARTNUMBER";
            this.PARTNUMBER.MinWidth = 25;
            this.PARTNUMBER.Name = "PARTNUMBER";
            this.PARTNUMBER.OptionsColumn.AllowEdit = false;
            this.PARTNUMBER.Visible = true;
            this.PARTNUMBER.VisibleIndex = 1;
            this.PARTNUMBER.Width = 139;
            // 
            // LOCATION
            // 
            this.LOCATION.Caption = "LOCATION";
            this.LOCATION.FieldName = "LOCATION";
            this.LOCATION.MinWidth = 25;
            this.LOCATION.Name = "LOCATION";
            this.LOCATION.OptionsColumn.AllowEdit = false;
            this.LOCATION.Visible = true;
            this.LOCATION.VisibleIndex = 2;
            this.LOCATION.Width = 139;
            // 
            // QTY
            // 
            this.QTY.Caption = "QTY";
            this.QTY.FieldName = "QTY";
            this.QTY.MinWidth = 25;
            this.QTY.Name = "QTY";
            this.QTY.OptionsColumn.AllowEdit = false;
            this.QTY.Visible = true;
            this.QTY.VisibleIndex = 3;
            this.QTY.Width = 48;
            // 
            // DATEIN
            // 
            this.DATEIN.Caption = "DATE IN";
            this.DATEIN.FieldName = "DATEIN";
            this.DATEIN.MinWidth = 25;
            this.DATEIN.Name = "DATEIN";
            this.DATEIN.Visible = true;
            this.DATEIN.VisibleIndex = 4;
            this.DATEIN.Width = 94;
            // 
            // STAFFNAME
            // 
            this.STAFFNAME.Caption = "STAFF BORROW";
            this.STAFFNAME.FieldName = "STAFFNAME";
            this.STAFFNAME.MinWidth = 25;
            this.STAFFNAME.Name = "STAFFNAME";
            this.STAFFNAME.Visible = true;
            this.STAFFNAME.VisibleIndex = 5;
            this.STAFFNAME.Width = 168;
            // 
            // fHisPartIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 679);
            this.Controls.Add(this.gcPartIn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fHisPartIn";
            this.Text = "fHisPartIn";
            this.Load += new System.EventHandler(this.fHisPartIn_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPartIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPartIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gcPartIn;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPartIn;
        private DevExpress.XtraGrid.Columns.GridColumn NAME;
        private DevExpress.XtraGrid.Columns.GridColumn PARTNUMBER;
        private DevExpress.XtraGrid.Columns.GridColumn LOCATION;
        private DevExpress.XtraGrid.Columns.GridColumn QTY;
        private DevExpress.XtraGrid.Columns.GridColumn DATEIN;
        private DevExpress.XtraGrid.Columns.GridColumn STAFFNAME;
    }
}