namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    partial class fFunc_ToolJigInOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fFunc_ToolJigInOut));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PARTNUMBER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LOCATION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtEstimate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRemark = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.cbCus = new System.Windows.Forms.Label();
            this.cbStaff = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPartIn = new System.Windows.Forms.ToolStripButton();
            this.btnPartOut = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tbQRCode = new System.Windows.Forms.TextBox();
            this.DESCRIPTION = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.gcList);
            this.groupControl1.Controls.Add(this.panel2);
            this.groupControl1.Controls.Add(this.panel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(818, 789);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Tool";
            // 
            // gcList
            // 
            this.gcList.AllowDrop = true;
            this.gcList.ContextMenuStrip = this.contextMenuStrip1;
            this.gcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcList.Location = new System.Drawing.Point(2, 164);
            this.gcList.MainView = this.gvList;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(814, 413);
            this.gcList.TabIndex = 2;
            this.gcList.UseDisabledStatePainter = false;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 30);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 26);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gvList
            // 
            this.gvList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NAME,
            this.DESCRIPTION,
            this.PARTNUMBER,
            this.QTY,
            this.LOCATION});
            this.gvList.GridControl = this.gcList;
            this.gvList.Name = "gvList";
            this.gvList.OptionsFind.AlwaysVisible = true;
            this.gvList.OptionsFind.FindDelay = 100;
            this.gvList.OptionsView.ShowAutoFilterRow = true;
            this.gvList.OptionsView.ShowGroupPanel = false;
            this.gvList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvList_CustomDrawRowIndicator);
            this.gvList.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvList_CustomDrawCell);
            this.gvList.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvList_CellValueChanged);
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
            this.NAME.Width = 94;
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
            this.PARTNUMBER.Width = 94;
            // 
            // QTY
            // 
            this.QTY.Caption = "QTY";
            this.QTY.FieldName = "QTY";
            this.QTY.MinWidth = 25;
            this.QTY.Name = "QTY";
            this.QTY.Visible = true;
            this.QTY.VisibleIndex = 3;
            this.QTY.Width = 94;
            // 
            // LOCATION
            // 
            this.LOCATION.Caption = "LOCATION";
            this.LOCATION.FieldName = "LOCATION";
            this.LOCATION.MinWidth = 25;
            this.LOCATION.Name = "LOCATION";
            this.LOCATION.OptionsColumn.AllowEdit = false;
            this.LOCATION.Visible = true;
            this.LOCATION.VisibleIndex = 4;
            this.LOCATION.Width = 94;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtEstimate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbRemark);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.cbCustomer);
            this.panel2.Controls.Add(this.cbCus);
            this.panel2.Controls.Add(this.cbStaff);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(2, 577);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 210);
            this.panel2.TabIndex = 3;
            this.panel2.Visible = false;
            // 
            // dtEstimate
            // 
            this.dtEstimate.CustomFormat = "dd-MM-yyyy";
            this.dtEstimate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtEstimate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEstimate.Location = new System.Drawing.Point(307, 74);
            this.dtEstimate.Name = "dtEstimate";
            this.dtEstimate.Size = new System.Drawing.Size(318, 28);
            this.dtEstimate.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(96, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 21);
            this.label2.TabIndex = 45;
            this.label2.Text = "Estimate Date In";
            // 
            // tbRemark
            // 
            this.tbRemark.Location = new System.Drawing.Point(306, 107);
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(318, 93);
            this.tbRemark.TabIndex = 42;
            this.tbRemark.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(96, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 21);
            this.label13.TabIndex = 41;
            this.label13.Text = "Remark";
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
            this.cbCustomer.Location = new System.Drawing.Point(306, 39);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(318, 29);
            this.cbCustomer.TabIndex = 40;
            // 
            // cbCus
            // 
            this.cbCus.AutoSize = true;
            this.cbCus.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.cbCus.Location = new System.Drawing.Point(96, 44);
            this.cbCus.Name = "cbCus";
            this.cbCus.Size = new System.Drawing.Size(160, 21);
            this.cbCus.TabIndex = 39;
            this.cbCus.Text = "Customer Borrow";
            // 
            // cbStaff
            // 
            this.cbStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStaff.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStaff.FormattingEnabled = true;
            this.cbStaff.Items.AddRange(new object[] {
            "",
            "Service",
            "Accounting",
            "Sale & Coordinator",
            "Maketing"});
            this.cbStaff.Location = new System.Drawing.Point(306, 6);
            this.cbStaff.Name = "cbStaff";
            this.cbStaff.Size = new System.Drawing.Size(318, 29);
            this.cbStaff.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(96, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 21);
            this.label1.TabIndex = 37;
            this.label1.Text = "Engineer Borrow";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbQRCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 136);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPartIn,
            this.btnPartOut,
            this.btnCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(814, 47);
            this.toolStrip1.TabIndex = 39;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPartIn
            // 
            this.btnPartIn.Image = ((System.Drawing.Image)(resources.GetObject("btnPartIn.Image")));
            this.btnPartIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPartIn.Name = "btnPartIn";
            this.btnPartIn.Size = new System.Drawing.Size(65, 44);
            this.btnPartIn.Text = "PART IN";
            this.btnPartIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPartIn.Click += new System.EventHandler(this.btnPartIn_Click);
            // 
            // btnPartOut
            // 
            this.btnPartOut.Image = ((System.Drawing.Image)(resources.GetObject("btnPartOut.Image")));
            this.btnPartOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPartOut.Name = "btnPartOut";
            this.btnPartOut.Size = new System.Drawing.Size(79, 44);
            this.btnPartOut.Text = "PART OUT";
            this.btnPartOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPartOut.Click += new System.EventHandler(this.btnPartOut_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 44);
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(258, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 21);
            this.label4.TabIndex = 38;
            this.label4.Text = "Scan QRCode";
            // 
            // tbQRCode
            // 
            this.tbQRCode.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbQRCode.Location = new System.Drawing.Point(262, 94);
            this.tbQRCode.Name = "tbQRCode";
            this.tbQRCode.Size = new System.Drawing.Size(282, 28);
            this.tbQRCode.TabIndex = 1;
            this.tbQRCode.TextChanged += new System.EventHandler(this.tbQRCode_TextChanged);
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.Caption = "DESCRIPTION";
            this.DESCRIPTION.FieldName = "DESCRIPTION";
            this.DESCRIPTION.MinWidth = 25;
            this.DESCRIPTION.Name = "DESCRIPTION";
            this.DESCRIPTION.Visible = true;
            this.DESCRIPTION.VisibleIndex = 1;
            this.DESCRIPTION.Width = 94;
            // 
            // fFunc_ToolJigInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 789);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fFunc_ToolJigInOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TOOLS & JIG";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraGrid.Columns.GridColumn NAME;
        private DevExpress.XtraGrid.Columns.GridColumn PARTNUMBER;
        private DevExpress.XtraGrid.Columns.GridColumn LOCATION;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCancel;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        public System.Windows.Forms.ToolStripButton btnPartIn;
        public System.Windows.Forms.ToolStripButton btnPartOut;
        public System.Windows.Forms.TextBox tbQRCode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DateTimePicker dtEstimate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox tbRemark;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Label cbCus;
        private System.Windows.Forms.ComboBox cbStaff;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.ToolStripMenuItem btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn QTY;
        private DevExpress.XtraGrid.Columns.GridColumn DESCRIPTION;
    }
}