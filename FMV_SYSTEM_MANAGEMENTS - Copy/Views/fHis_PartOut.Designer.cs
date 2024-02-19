namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    partial class fHis_PartOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHis_PartOut));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbCus = new System.Windows.Forms.Label();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.REMARK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUSTOMERNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPartOut = new DevExpress.XtraGrid.GridControl();
            this.gvPartOut = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.STATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PARTNUMBER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LOCATION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SAVEQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DATEOUT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUSTOMERNAMES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STAFFNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REMARKS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPartOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPartOut)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1109, 64);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1109, 64);
            this.label1.TabIndex = 1;
            this.label1.Text = "PART OUT HISTORY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.cbCus);
            this.panel2.Controls.Add(this.cbCustomer);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtTo);
            this.panel2.Controls.Add(this.dtFrom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1109, 77);
            this.panel2.TabIndex = 3;
            // 
            // cbCus
            // 
            this.cbCus.AutoSize = true;
            this.cbCus.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.cbCus.Location = new System.Drawing.Point(733, 13);
            this.cbCus.Name = "cbCus";
            this.cbCus.Size = new System.Drawing.Size(160, 21);
            this.cbCus.TabIndex = 52;
            this.cbCus.Text = "Customer Borrow";
            // 
            // cbCustomer
            // 
            this.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomer.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Items.AddRange(new object[] {
            "",
            "Service",
            "Accounting",
            "Sale & Coordinator",
            "Maketing"});
            this.cbCustomer.Location = new System.Drawing.Point(737, 37);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(282, 29);
            this.cbCustomer.TabIndex = 51;
            this.cbCustomer.SelectedValueChanged += new System.EventHandler(this.cbCustomer_SelectedValueChanged);
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
            // REMARK
            // 
            this.REMARK.Caption = "REMARK";
            this.REMARK.FieldName = "REMARK";
            this.REMARK.MinWidth = 25;
            this.REMARK.Name = "REMARK";
            this.REMARK.Width = 193;
            // 
            // CUSTOMERNAME
            // 
            this.CUSTOMERNAME.Caption = "CUSTOMER BORROW";
            this.CUSTOMERNAME.FieldName = "CUSTOMERNAME";
            this.CUSTOMERNAME.MinWidth = 25;
            this.CUSTOMERNAME.Name = "CUSTOMERNAME";
            this.CUSTOMERNAME.Width = 168;
            // 
            // gcPartOut
            // 
            this.gcPartOut.AllowDrop = true;
            this.gcPartOut.ContextMenuStrip = this.contextMenuStrip1;
            this.gcPartOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPartOut.Location = new System.Drawing.Point(0, 141);
            this.gcPartOut.MainView = this.gvPartOut;
            this.gcPartOut.Name = "gcPartOut";
            this.gcPartOut.Size = new System.Drawing.Size(1109, 474);
            this.gcPartOut.TabIndex = 6;
            this.gcPartOut.UseDisabledStatePainter = false;
            this.gcPartOut.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPartOut});
            // 
            // gvPartOut
            // 
            this.gvPartOut.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.STATUS,
            this.NAME,
            this.PARTNUMBER,
            this.LOCATION,
            this.SAVEQTY,
            this.DATEOUT,
            this.CUSTOMERNAMES,
            this.STAFFNAME,
            this.REMARKS});
            this.gvPartOut.GridControl = this.gcPartOut;
            this.gvPartOut.Name = "gvPartOut";
            this.gvPartOut.OptionsFind.AlwaysVisible = true;
            this.gvPartOut.OptionsFind.FindDelay = 100;
            this.gvPartOut.OptionsView.ShowAutoFilterRow = true;
            this.gvPartOut.OptionsView.ShowGroupPanel = false;
            // 
            // STATUS
            // 
            this.STATUS.Caption = "ALREADY PART IN";
            this.STATUS.FieldName = "STATUS";
            this.STATUS.MinWidth = 25;
            this.STATUS.Name = "STATUS";
            this.STATUS.Visible = true;
            this.STATUS.VisibleIndex = 0;
            this.STATUS.Width = 85;
            // 
            // NAME
            // 
            this.NAME.Caption = "NAME";
            this.NAME.FieldName = "NAME";
            this.NAME.MinWidth = 25;
            this.NAME.Name = "NAME";
            this.NAME.OptionsColumn.AllowEdit = false;
            this.NAME.Visible = true;
            this.NAME.VisibleIndex = 1;
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
            this.PARTNUMBER.VisibleIndex = 2;
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
            this.LOCATION.VisibleIndex = 3;
            this.LOCATION.Width = 139;
            // 
            // SAVEQTY
            // 
            this.SAVEQTY.Caption = "QTY";
            this.SAVEQTY.FieldName = "SAVEQTY";
            this.SAVEQTY.MinWidth = 25;
            this.SAVEQTY.Name = "SAVEQTY";
            this.SAVEQTY.OptionsColumn.AllowEdit = false;
            this.SAVEQTY.Visible = true;
            this.SAVEQTY.VisibleIndex = 4;
            this.SAVEQTY.Width = 48;
            // 
            // DATEOUT
            // 
            this.DATEOUT.Caption = "DATE OUT";
            this.DATEOUT.FieldName = "DATEOUT";
            this.DATEOUT.MinWidth = 25;
            this.DATEOUT.Name = "DATEOUT";
            this.DATEOUT.Visible = true;
            this.DATEOUT.VisibleIndex = 5;
            this.DATEOUT.Width = 94;
            // 
            // CUSTOMERNAMES
            // 
            this.CUSTOMERNAMES.Caption = "CUSTOMER BORROW";
            this.CUSTOMERNAMES.FieldName = "CUSTOMERNAME";
            this.CUSTOMERNAMES.MinWidth = 25;
            this.CUSTOMERNAMES.Name = "CUSTOMERNAMES";
            this.CUSTOMERNAMES.Visible = true;
            this.CUSTOMERNAMES.VisibleIndex = 6;
            this.CUSTOMERNAMES.Width = 168;
            // 
            // STAFFNAME
            // 
            this.STAFFNAME.Caption = "STAFF BORROW";
            this.STAFFNAME.FieldName = "STAFFNAME";
            this.STAFFNAME.MinWidth = 25;
            this.STAFFNAME.Name = "STAFFNAME";
            this.STAFFNAME.Visible = true;
            this.STAFFNAME.VisibleIndex = 7;
            this.STAFFNAME.Width = 168;
            // 
            // REMARKS
            // 
            this.REMARKS.Caption = "REMARK";
            this.REMARKS.FieldName = "REMARK";
            this.REMARKS.MinWidth = 25;
            this.REMARKS.Name = "REMARKS";
            this.REMARKS.Visible = true;
            this.REMARKS.VisibleIndex = 8;
            this.REMARKS.Width = 193;
            // 
            // fHisPartOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 615);
            this.Controls.Add(this.gcPartOut);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fHisPartOut";
            this.Text = "fHisPartOut";
            this.Load += new System.EventHandler(this.fHisPartOut_Load);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPartOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPartOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Label cbCus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
        public System.Windows.Forms.DateTimePicker dtFrom;
        private DevExpress.XtraGrid.Columns.GridColumn REMARK;
        private DevExpress.XtraGrid.Columns.GridColumn CUSTOMERNAME;
        private DevExpress.XtraGrid.GridControl gcPartOut;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPartOut;
        private DevExpress.XtraGrid.Columns.GridColumn STATUS;
        private DevExpress.XtraGrid.Columns.GridColumn NAME;
        private DevExpress.XtraGrid.Columns.GridColumn PARTNUMBER;
        private DevExpress.XtraGrid.Columns.GridColumn LOCATION;
        private DevExpress.XtraGrid.Columns.GridColumn SAVEQTY;
        private DevExpress.XtraGrid.Columns.GridColumn DATEOUT;
        private DevExpress.XtraGrid.Columns.GridColumn CUSTOMERNAMES;
        private DevExpress.XtraGrid.Columns.GridColumn STAFFNAME;
        private DevExpress.XtraGrid.Columns.GridColumn REMARKS;
    }
}