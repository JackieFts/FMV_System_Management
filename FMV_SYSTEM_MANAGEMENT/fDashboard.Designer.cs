namespace FMV_SYSTEM_MANAGEMENT
{
    partial class fDashboard
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
            label1 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            groupControl2 = new DevExpress.XtraEditors.GroupControl();
            gcCustomer = new DevExpress.XtraGrid.GridControl();
            gvCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            CUSTOMER = new DevExpress.XtraGrid.Columns.GridColumn();
            CONTACT = new DevExpress.XtraGrid.Columns.GridColumn();
            CUSPHONE = new DevExpress.XtraGrid.Columns.GridColumn();
            CUSEMAIL = new DevExpress.XtraGrid.Columns.GridColumn();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            gcStaff = new DevExpress.XtraGrid.GridControl();
            gvStaff = new DevExpress.XtraGrid.Views.Grid.GridView();
            NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            DEPARTMENT = new DevExpress.XtraGrid.Columns.GridColumn();
            POSITION = new DevExpress.XtraGrid.Columns.GridColumn();
            PHONE = new DevExpress.XtraGrid.Columns.GridColumn();
            EMAIL = new DevExpress.XtraGrid.Columns.GridColumn();
            CCCD = new DevExpress.XtraGrid.Columns.GridColumn();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControl2).BeginInit();
            groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gcCustomer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvCustomer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gcStaff).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvStaff).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            label1.Font = new System.Drawing.Font("Tahoma", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(0, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(1225, 57);
            label1.TabIndex = 0;
            label1.Text = "FMV SYSTEM MANAGEMENT";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1225, 88);
            panel1.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupControl2, 1, 0);
            tableLayoutPanel1.Controls.Add(groupControl1, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 88);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1225, 639);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // groupControl2
            // 
            groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            groupControl2.AppearanceCaption.Options.UseFont = true;
            groupControl2.AppearanceCaption.Options.UseForeColor = true;
            groupControl2.Controls.Add(gcCustomer);
            groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl2.Location = new System.Drawing.Point(615, 3);
            groupControl2.Name = "groupControl2";
            groupControl2.Size = new System.Drawing.Size(607, 633);
            groupControl2.TabIndex = 1;
            groupControl2.Text = "CUSTOMER INFO";
            // 
            // gcCustomer
            // 
            gcCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            gcCustomer.Location = new System.Drawing.Point(2, 28);
            gcCustomer.MainView = gvCustomer;
            gcCustomer.Name = "gcCustomer";
            gcCustomer.Size = new System.Drawing.Size(603, 603);
            gcCustomer.TabIndex = 0;
            gcCustomer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvCustomer });
            // 
            // gvCustomer
            // 
            gvCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { CUSTOMER, CONTACT, CUSPHONE, CUSEMAIL });
            gvCustomer.GridControl = gcCustomer;
            gvCustomer.Name = "gvCustomer";
            gvCustomer.OptionsBehavior.Editable = false;
            gvCustomer.OptionsFind.FindDelay = 100;
            gvCustomer.OptionsView.ShowAutoFilterRow = true;
            gvCustomer.OptionsView.ShowGroupPanel = false;
            // 
            // CUSTOMER
            // 
            CUSTOMER.Caption = "NAME";
            CUSTOMER.FieldName = "Customername";
            CUSTOMER.MinWidth = 25;
            CUSTOMER.Name = "CUSTOMER";
            CUSTOMER.Visible = true;
            CUSTOMER.VisibleIndex = 0;
            CUSTOMER.Width = 94;
            // 
            // CONTACT
            // 
            CONTACT.Caption = "CONTACT PERSON";
            CONTACT.FieldName = "Contactperson";
            CONTACT.MinWidth = 25;
            CONTACT.Name = "CONTACT";
            CONTACT.Visible = true;
            CONTACT.VisibleIndex = 1;
            CONTACT.Width = 94;
            // 
            // CUSPHONE
            // 
            CUSPHONE.Caption = "PHONE";
            CUSPHONE.FieldName = "Phone";
            CUSPHONE.MinWidth = 25;
            CUSPHONE.Name = "CUSPHONE";
            CUSPHONE.Visible = true;
            CUSPHONE.VisibleIndex = 2;
            CUSPHONE.Width = 94;
            // 
            // CUSEMAIL
            // 
            CUSEMAIL.Caption = "EMAIL";
            CUSEMAIL.FieldName = "Email";
            CUSEMAIL.MinWidth = 25;
            CUSEMAIL.Name = "CUSEMAIL";
            CUSEMAIL.Visible = true;
            CUSEMAIL.VisibleIndex = 3;
            CUSEMAIL.Width = 94;
            // 
            // groupControl1
            // 
            groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            groupControl1.AppearanceCaption.Options.UseFont = true;
            groupControl1.AppearanceCaption.Options.UseForeColor = true;
            groupControl1.Controls.Add(gcStaff);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl1.Location = new System.Drawing.Point(3, 3);
            groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(606, 633);
            groupControl1.TabIndex = 0;
            groupControl1.Text = "STAFF INFO";
            // 
            // gcStaff
            // 
            gcStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            gcStaff.Location = new System.Drawing.Point(2, 28);
            gcStaff.MainView = gvStaff;
            gcStaff.Name = "gcStaff";
            gcStaff.Size = new System.Drawing.Size(602, 603);
            gcStaff.TabIndex = 0;
            gcStaff.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvStaff });
            // 
            // gvStaff
            // 
            gvStaff.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { NAME, DEPARTMENT, POSITION, CCCD, PHONE, EMAIL });
            gvStaff.GridControl = gcStaff;
            gvStaff.Name = "gvStaff";
            gvStaff.OptionsBehavior.Editable = false;
            gvStaff.OptionsFind.FindDelay = 100;
            gvStaff.OptionsView.ShowAutoFilterRow = true;
            gvStaff.OptionsView.ShowGroupPanel = false;
            // 
            // NAME
            // 
            NAME.Caption = "NAME";
            NAME.FieldName = "Staffname";
            NAME.MinWidth = 25;
            NAME.Name = "NAME";
            NAME.Visible = true;
            NAME.VisibleIndex = 0;
            NAME.Width = 94;
            // 
            // DEPARTMENT
            // 
            DEPARTMENT.Caption = "DEPARTMENT";
            DEPARTMENT.FieldName = "Department";
            DEPARTMENT.MinWidth = 25;
            DEPARTMENT.Name = "DEPARTMENT";
            DEPARTMENT.Visible = true;
            DEPARTMENT.VisibleIndex = 1;
            DEPARTMENT.Width = 94;
            // 
            // POSITION
            // 
            POSITION.Caption = "POSITION";
            POSITION.FieldName = "Position";
            POSITION.MinWidth = 25;
            POSITION.Name = "POSITION";
            POSITION.Visible = true;
            POSITION.VisibleIndex = 2;
            POSITION.Width = 94;
            // 
            // PHONE
            // 
            PHONE.Caption = "PHONE";
            PHONE.FieldName = "Phone";
            PHONE.MinWidth = 25;
            PHONE.Name = "PHONE";
            PHONE.Visible = true;
            PHONE.VisibleIndex = 4;
            PHONE.Width = 94;
            // 
            // EMAIL
            // 
            EMAIL.Caption = "EMAIL";
            EMAIL.FieldName = "Email";
            EMAIL.MinWidth = 25;
            EMAIL.Name = "EMAIL";
            EMAIL.Visible = true;
            EMAIL.VisibleIndex = 5;
            EMAIL.Width = 94;
            // 
            // CCCD
            // 
            CCCD.Caption = "CCCD";
            CCCD.FieldName = "CCCD";
            CCCD.MinWidth = 25;
            CCCD.Name = "CCCD";
            CCCD.Visible = true;
            CCCD.VisibleIndex = 3;
            CCCD.Width = 94;
            // 
            // fDashboard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1225, 727);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Name = "fDashboard";
            Text = "fDashboard";
            Load += fDashboard_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)groupControl2).EndInit();
            groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gcCustomer).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvCustomer).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gcStaff).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvStaff).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCustomer;
        private DevExpress.XtraGrid.GridControl gcStaff;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStaff;
        private DevExpress.XtraGrid.Columns.GridColumn NAME;
        private DevExpress.XtraGrid.Columns.GridColumn DEPARTMENT;
        private DevExpress.XtraGrid.Columns.GridColumn POSITION;
        private DevExpress.XtraGrid.Columns.GridColumn PHONE;
        private DevExpress.XtraGrid.Columns.GridColumn EMAIL;
        private DevExpress.XtraGrid.Columns.GridColumn CUSTOMER;
        private DevExpress.XtraGrid.Columns.GridColumn CONTACT;
        private DevExpress.XtraGrid.Columns.GridColumn CUSPHONE;
        private DevExpress.XtraGrid.Columns.GridColumn CUSEMAIL;
        private DevExpress.XtraGrid.Columns.GridColumn CCCD;
    }
}