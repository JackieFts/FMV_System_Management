namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    partial class fFirst_Dashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcStaff = new DevExpress.XtraGrid.GridControl();
            this.gvStaff = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DEPARTMENT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.POSITION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CCCD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PHONE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMAIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gcCustomer = new DevExpress.XtraGrid.GridControl();
            this.gvCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CUSNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CONTACT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUSPHONE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUSEMAIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1225, 93);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1225, 93);
            this.label1.TabIndex = 0;
            this.label1.Text = "SYSTEM MANAGEMENT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 93);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1225, 634);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.gcStaff);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(606, 628);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "STAFF INFO";
            // 
            // gcStaff
            // 
            this.gcStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcStaff.Location = new System.Drawing.Point(2, 28);
            this.gcStaff.MainView = this.gvStaff;
            this.gcStaff.Name = "gcStaff";
            this.gcStaff.Size = new System.Drawing.Size(602, 598);
            this.gcStaff.TabIndex = 0;
            this.gcStaff.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStaff});
            // 
            // gvStaff
            // 
            this.gvStaff.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NAME,
            this.DEPARTMENT,
            this.POSITION,
            this.CCCD,
            this.PHONE,
            this.EMAIL});
            this.gvStaff.GridControl = this.gcStaff;
            this.gvStaff.Name = "gvStaff";
            this.gvStaff.OptionsBehavior.Editable = false;
            this.gvStaff.OptionsFind.AlwaysVisible = true;
            this.gvStaff.OptionsFind.FindDelay = 100;
            this.gvStaff.OptionsView.ShowAutoFilterRow = true;
            this.gvStaff.OptionsView.ShowGroupPanel = false;
            this.gvStaff.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvStaff_CustomDrawRowIndicator);
            this.gvStaff.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvStaff_CustomDrawCell);
            // 
            // NAME
            // 
            this.NAME.Caption = "NAME";
            this.NAME.FieldName = "STAFFNAME";
            this.NAME.MinWidth = 25;
            this.NAME.Name = "NAME";
            this.NAME.Visible = true;
            this.NAME.VisibleIndex = 0;
            this.NAME.Width = 94;
            // 
            // DEPARTMENT
            // 
            this.DEPARTMENT.Caption = "DEPARTMENT";
            this.DEPARTMENT.FieldName = "DEPARTMENT";
            this.DEPARTMENT.MinWidth = 25;
            this.DEPARTMENT.Name = "DEPARTMENT";
            this.DEPARTMENT.Visible = true;
            this.DEPARTMENT.VisibleIndex = 1;
            this.DEPARTMENT.Width = 94;
            // 
            // POSITION
            // 
            this.POSITION.Caption = "POSITION";
            this.POSITION.FieldName = "POSITION";
            this.POSITION.MinWidth = 25;
            this.POSITION.Name = "POSITION";
            this.POSITION.Visible = true;
            this.POSITION.VisibleIndex = 2;
            this.POSITION.Width = 94;
            // 
            // CCCD
            // 
            this.CCCD.Caption = "CCCD";
            this.CCCD.FieldName = "CCCD";
            this.CCCD.MinWidth = 25;
            this.CCCD.Name = "CCCD";
            this.CCCD.Visible = true;
            this.CCCD.VisibleIndex = 3;
            this.CCCD.Width = 94;
            // 
            // PHONE
            // 
            this.PHONE.Caption = "PHONE";
            this.PHONE.FieldName = "PHONE";
            this.PHONE.MinWidth = 25;
            this.PHONE.Name = "PHONE";
            this.PHONE.Visible = true;
            this.PHONE.VisibleIndex = 4;
            this.PHONE.Width = 94;
            // 
            // EMAIL
            // 
            this.EMAIL.Caption = "EMAIL";
            this.EMAIL.FieldName = "EMAIL";
            this.EMAIL.MinWidth = 25;
            this.EMAIL.Name = "EMAIL";
            this.EMAIL.Visible = true;
            this.EMAIL.VisibleIndex = 5;
            this.EMAIL.Width = 94;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.gcCustomer);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(615, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(607, 628);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "CUSTOMER INFO";
            // 
            // gcCustomer
            // 
            this.gcCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCustomer.Location = new System.Drawing.Point(2, 28);
            this.gcCustomer.MainView = this.gvCustomer;
            this.gcCustomer.Name = "gcCustomer";
            this.gcCustomer.Size = new System.Drawing.Size(603, 598);
            this.gcCustomer.TabIndex = 1;
            this.gcCustomer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCustomer});
            // 
            // gvCustomer
            // 
            this.gvCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CUSNAME,
            this.CONTACT,
            this.CUSPHONE,
            this.CUSEMAIL});
            this.gvCustomer.GridControl = this.gcCustomer;
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.OptionsBehavior.Editable = false;
            this.gvCustomer.OptionsFind.AlwaysVisible = true;
            this.gvCustomer.OptionsFind.FindDelay = 100;
            this.gvCustomer.OptionsView.ShowAutoFilterRow = true;
            this.gvCustomer.OptionsView.ShowGroupPanel = false;
            this.gvCustomer.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvCustomer_CustomDrawRowIndicator);
            this.gvCustomer.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvCustomer_CustomDrawCell);
            // 
            // CUSNAME
            // 
            this.CUSNAME.Caption = "NAME";
            this.CUSNAME.FieldName = "CUSTOMERNAME";
            this.CUSNAME.MinWidth = 25;
            this.CUSNAME.Name = "CUSNAME";
            this.CUSNAME.Visible = true;
            this.CUSNAME.VisibleIndex = 0;
            this.CUSNAME.Width = 94;
            // 
            // CONTACT
            // 
            this.CONTACT.Caption = "CONTACT PERSON";
            this.CONTACT.FieldName = "CONTACTPERSON";
            this.CONTACT.MinWidth = 25;
            this.CONTACT.Name = "CONTACT";
            this.CONTACT.Visible = true;
            this.CONTACT.VisibleIndex = 1;
            this.CONTACT.Width = 94;
            // 
            // CUSPHONE
            // 
            this.CUSPHONE.Caption = "PHONE";
            this.CUSPHONE.FieldName = "PHONE";
            this.CUSPHONE.MinWidth = 25;
            this.CUSPHONE.Name = "CUSPHONE";
            this.CUSPHONE.Visible = true;
            this.CUSPHONE.VisibleIndex = 2;
            this.CUSPHONE.Width = 94;
            // 
            // CUSEMAIL
            // 
            this.CUSEMAIL.Caption = "EMAIL";
            this.CUSEMAIL.FieldName = "EMAIL";
            this.CUSEMAIL.MinWidth = 25;
            this.CUSEMAIL.Name = "CUSEMAIL";
            this.CUSEMAIL.Visible = true;
            this.CUSEMAIL.VisibleIndex = 3;
            this.CUSEMAIL.Width = 94;
            // 
            // fDashboard
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 727);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "fDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fDashboard";
            this.Load += new System.EventHandler(this.fDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gcStaff;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStaff;
        private DevExpress.XtraGrid.GridControl gcCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn NAME;
        private DevExpress.XtraGrid.Columns.GridColumn DEPARTMENT;
        private DevExpress.XtraGrid.Columns.GridColumn POSITION;
        private DevExpress.XtraGrid.Columns.GridColumn CCCD;
        private DevExpress.XtraGrid.Columns.GridColumn PHONE;
        private DevExpress.XtraGrid.Columns.GridColumn EMAIL;
        private DevExpress.XtraGrid.Columns.GridColumn CUSNAME;
        private DevExpress.XtraGrid.Columns.GridColumn CONTACT;
        private DevExpress.XtraGrid.Columns.GridColumn CUSPHONE;
        private DevExpress.XtraGrid.Columns.GridColumn CUSEMAIL;
    }
}