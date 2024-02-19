namespace FMV_SYSTEM_MANAGEMENT
{
    partial class fCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCustomer));
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            tbName = new System.Windows.Forms.TextBox();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            tbEmail = new System.Windows.Forms.TextBox();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            tbPhone = new System.Windows.Forms.TextBox();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            tbContact = new System.Windows.Forms.TextBox();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            tbID = new System.Windows.Forms.TextBox();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnUpdate = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            btnClear = new System.Windows.Forms.ToolStripButton();
            btnSave = new System.Windows.Forms.ToolStripButton();
            btnCancel = new System.Windows.Forms.ToolStripButton();
            btnQuit = new System.Windows.Forms.ToolStripButton();
            gcCustomer = new DevExpress.XtraGrid.GridControl();
            gvCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            CUSTOMER = new DevExpress.XtraGrid.Columns.GridColumn();
            CONTACT = new DevExpress.XtraGrid.Columns.GridColumn();
            CUSPHONE = new DevExpress.XtraGrid.Columns.GridColumn();
            CUSEMAIL = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gcCustomer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvCustomer).BeginInit();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            groupControl1.AppearanceCaption.Options.UseFont = true;
            groupControl1.AppearanceCaption.Options.UseForeColor = true;
            groupControl1.Controls.Add(tbName);
            groupControl1.Controls.Add(labelControl2);
            groupControl1.Controls.Add(tbEmail);
            groupControl1.Controls.Add(labelControl5);
            groupControl1.Controls.Add(tbPhone);
            groupControl1.Controls.Add(labelControl4);
            groupControl1.Controls.Add(tbContact);
            groupControl1.Controls.Add(labelControl3);
            groupControl1.Controls.Add(tbID);
            groupControl1.Controls.Add(labelControl1);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            groupControl1.Location = new System.Drawing.Point(0, 47);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(1429, 159);
            groupControl1.TabIndex = 3;
            groupControl1.Text = "INFORMATION";
            // 
            // tbName
            // 
            tbName.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbName.Location = new System.Drawing.Point(283, 78);
            tbName.Name = "tbName";
            tbName.Size = new System.Drawing.Size(282, 28);
            tbName.TabIndex = 2;
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new System.Drawing.Point(112, 82);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(49, 21);
            labelControl2.TabIndex = 10;
            labelControl2.Text = "Name";
            // 
            // tbEmail
            // 
            tbEmail.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbEmail.Location = new System.Drawing.Point(829, 109);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new System.Drawing.Size(282, 28);
            tbEmail.TabIndex = 5;
            // 
            // labelControl5
            // 
            labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelControl5.Appearance.Options.UseFont = true;
            labelControl5.Location = new System.Drawing.Point(697, 113);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new System.Drawing.Size(46, 21);
            labelControl5.TabIndex = 8;
            labelControl5.Text = "Email";
            // 
            // tbPhone
            // 
            tbPhone.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbPhone.Location = new System.Drawing.Point(829, 45);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new System.Drawing.Size(282, 28);
            tbPhone.TabIndex = 4;
            // 
            // labelControl4
            // 
            labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Location = new System.Drawing.Point(697, 49);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(54, 21);
            labelControl4.TabIndex = 6;
            labelControl4.Text = "Phone";
            // 
            // tbContact
            // 
            tbContact.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbContact.Location = new System.Drawing.Point(283, 112);
            tbContact.Name = "tbContact";
            tbContact.Size = new System.Drawing.Size(282, 28);
            tbContact.TabIndex = 3;
            // 
            // labelControl3
            // 
            labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new System.Drawing.Point(112, 116);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(130, 21);
            labelControl3.TabIndex = 4;
            labelControl3.Text = "Contact Person";
            // 
            // tbID
            // 
            tbID.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbID.Location = new System.Drawing.Point(283, 44);
            tbID.Name = "tbID";
            tbID.Size = new System.Drawing.Size(282, 28);
            tbID.TabIndex = 1;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(112, 48);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(108, 21);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Customer ID";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnUpdate, btnDelete, btnClear, btnSave, btnCancel, btnQuit });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(1429, 47);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = (System.Drawing.Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(45, 44);
            btnAdd.Text = "ADD";
            btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Image = (System.Drawing.Image)resources.GetObject("btnUpdate.Image");
            btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(67, 44);
            btnUpdate.Text = "UPDATE";
            btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Image = (System.Drawing.Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(63, 44);
            btnDelete.Text = "DELETE";
            btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Image = (System.Drawing.Image)resources.GetObject("btnClear.Image");
            btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(80, 44);
            btnClear.Text = "CLEAR DB";
            btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.Image = (System.Drawing.Image)resources.GetObject("btnSave.Image");
            btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(47, 44);
            btnSave.Text = "SAVE";
            btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
            btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(67, 44);
            btnCancel.Text = "CANCEL";
            btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnQuit
            // 
            btnQuit.Image = (System.Drawing.Image)resources.GetObject("btnQuit.Image");
            btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new System.Drawing.Size(46, 44);
            btnQuit.Text = "QUIT";
            btnQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnQuit.Click += btnQuit_Click;
            // 
            // gcCustomer
            // 
            gcCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            gcCustomer.Location = new System.Drawing.Point(0, 206);
            gcCustomer.MainView = gvCustomer;
            gcCustomer.Name = "gcCustomer";
            gcCustomer.Size = new System.Drawing.Size(1429, 436);
            gcCustomer.TabIndex = 10;
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
            gvCustomer.Click += gvCustomer_Click;
            // 
            // CUSTOMER
            // 
            CUSTOMER.Caption = "CUSTOMER NAME";
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
            // fCustomer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1429, 642);
            Controls.Add(gcCustomer);
            Controls.Add(groupControl1);
            Controls.Add(toolStrip1);
            Name = "fCustomer";
            Text = "fCustomer";
            Load += fCustomer_Load;
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gcCustomer).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvCustomer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox tbEmail;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.TextBox tbPhone;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.TextBox tbContact;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.TextBox tbID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnUpdate;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private DevExpress.XtraGrid.GridControl gcCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn CUSTOMER;
        private DevExpress.XtraGrid.Columns.GridColumn CONTACT;
        private DevExpress.XtraGrid.Columns.GridColumn CUSPHONE;
        private DevExpress.XtraGrid.Columns.GridColumn CUSEMAIL;
        private System.Windows.Forms.TextBox tbName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.GroupControl groupControl1;
    }
}