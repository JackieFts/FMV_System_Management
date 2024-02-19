namespace FMV_SYSTEM_MANAGEMENT
{
    partial class fStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fStaff));
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnUpdate = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            btnClear = new System.Windows.Forms.ToolStripButton();
            btnSave = new System.Windows.Forms.ToolStripButton();
            btnCancel = new System.Windows.Forms.ToolStripButton();
            btnQuit = new System.Windows.Forms.ToolStripButton();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            tbCCCD = new System.Windows.Forms.TextBox();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            tbDepartment = new System.Windows.Forms.ComboBox();
            tbEmail = new System.Windows.Forms.TextBox();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            tbPhone = new System.Windows.Forms.TextBox();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            tbPosition = new System.Windows.Forms.TextBox();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            tbName = new System.Windows.Forms.TextBox();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            gcStaff = new DevExpress.XtraGrid.GridControl();
            gvStaff = new DevExpress.XtraGrid.Views.Grid.GridView();
            NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            DEPARTMENT = new DevExpress.XtraGrid.Columns.GridColumn();
            POSITION = new DevExpress.XtraGrid.Columns.GridColumn();
            CCCD = new DevExpress.XtraGrid.Columns.GridColumn();
            PHONE = new DevExpress.XtraGrid.Columns.GridColumn();
            EMAIL = new DevExpress.XtraGrid.Columns.GridColumn();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gcStaff).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvStaff).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnUpdate, btnDelete, btnClear, btnSave, btnCancel, btnQuit });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(1417, 47);
            toolStrip1.TabIndex = 0;
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
            // groupControl1
            // 
            groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            groupControl1.AppearanceCaption.Options.UseFont = true;
            groupControl1.AppearanceCaption.Options.UseForeColor = true;
            groupControl1.Controls.Add(tbCCCD);
            groupControl1.Controls.Add(labelControl6);
            groupControl1.Controls.Add(tbDepartment);
            groupControl1.Controls.Add(tbEmail);
            groupControl1.Controls.Add(labelControl5);
            groupControl1.Controls.Add(tbPhone);
            groupControl1.Controls.Add(labelControl4);
            groupControl1.Controls.Add(tbPosition);
            groupControl1.Controls.Add(labelControl3);
            groupControl1.Controls.Add(labelControl2);
            groupControl1.Controls.Add(tbName);
            groupControl1.Controls.Add(labelControl1);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            groupControl1.Location = new System.Drawing.Point(0, 47);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(1417, 159);
            groupControl1.TabIndex = 1;
            groupControl1.Text = "INFORMATION";
            // 
            // tbCCCD
            // 
            tbCCCD.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbCCCD.Location = new System.Drawing.Point(829, 45);
            tbCCCD.Name = "tbCCCD";
            tbCCCD.Size = new System.Drawing.Size(282, 28);
            tbCCCD.TabIndex = 4;
            // 
            // labelControl6
            // 
            labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelControl6.Appearance.Options.UseFont = true;
            labelControl6.Location = new System.Drawing.Point(697, 49);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new System.Drawing.Size(46, 21);
            labelControl6.TabIndex = 11;
            labelControl6.Text = "CCCD";
            // 
            // tbDepartment
            // 
            tbDepartment.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbDepartment.FormattingEnabled = true;
            tbDepartment.Items.AddRange(new object[] { "", "Service", "Accounting", "Sale & Coordinator", "Maketing" });
            tbDepartment.Location = new System.Drawing.Point(283, 77);
            tbDepartment.Name = "tbDepartment";
            tbDepartment.Size = new System.Drawing.Size(282, 29);
            tbDepartment.TabIndex = 2;
            // 
            // tbEmail
            // 
            tbEmail.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbEmail.Location = new System.Drawing.Point(829, 109);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new System.Drawing.Size(282, 28);
            tbEmail.TabIndex = 6;
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
            tbPhone.Location = new System.Drawing.Point(829, 78);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new System.Drawing.Size(282, 28);
            tbPhone.TabIndex = 5;
            // 
            // labelControl4
            // 
            labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Location = new System.Drawing.Point(697, 82);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(54, 21);
            labelControl4.TabIndex = 6;
            labelControl4.Text = "Phone";
            // 
            // tbPosition
            // 
            tbPosition.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbPosition.Location = new System.Drawing.Point(283, 112);
            tbPosition.Name = "tbPosition";
            tbPosition.Size = new System.Drawing.Size(282, 28);
            tbPosition.TabIndex = 3;
            // 
            // labelControl3
            // 
            labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new System.Drawing.Point(151, 116);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(79, 21);
            labelControl3.TabIndex = 4;
            labelControl3.Text = "Possition";
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new System.Drawing.Point(151, 81);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(102, 21);
            labelControl2.TabIndex = 2;
            labelControl2.Text = "Department";
            // 
            // tbName
            // 
            tbName.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbName.Location = new System.Drawing.Point(283, 44);
            tbName.Name = "tbName";
            tbName.Size = new System.Drawing.Size(282, 28);
            tbName.TabIndex = 1;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(151, 48);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(49, 21);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Name";
            // 
            // gcStaff
            // 
            gcStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            gcStaff.Location = new System.Drawing.Point(0, 206);
            gcStaff.MainView = gvStaff;
            gcStaff.Name = "gcStaff";
            gcStaff.Size = new System.Drawing.Size(1417, 431);
            gcStaff.TabIndex = 2;
            gcStaff.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvStaff });
            // 
            // gvStaff
            // 
            gvStaff.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { NAME, DEPARTMENT, POSITION, CCCD, PHONE, EMAIL });
            gvStaff.GridControl = gcStaff;
            gvStaff.Name = "gvStaff";
            gvStaff.OptionsFind.AlwaysVisible = true;
            gvStaff.OptionsFind.FindDelay = 100;
            gvStaff.OptionsView.ShowAutoFilterRow = true;
            gvStaff.OptionsView.ShowGroupPanel = false;
            gvStaff.ParseFindPanelText += gvStaff_ParseFindPanelText;
            gvStaff.Click += gvStaff_Click;
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
            // fStaff
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1417, 637);
            Controls.Add(gcStaff);
            Controls.Add(groupControl1);
            Controls.Add(toolStrip1);
            Name = "fStaff";
            Text = "fStaff";
            Load += fStaff_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gcStaff).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvStaff).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnUpdate;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbEmail;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.TextBox tbPhone;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.TextBox tbPosition;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ComboBox tbDepartment;
        private DevExpress.XtraGrid.GridControl gcStaff;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStaff;
        private DevExpress.XtraGrid.Columns.GridColumn NAME;
        private DevExpress.XtraGrid.Columns.GridColumn DEPARTMENT;
        private DevExpress.XtraGrid.Columns.GridColumn POSITION;
        private DevExpress.XtraGrid.Columns.GridColumn PHONE;
        private DevExpress.XtraGrid.Columns.GridColumn EMAIL;
        private System.Windows.Forms.ToolStripButton btnClear;
        private DevExpress.XtraGrid.Columns.GridColumn CCCD;
        private System.Windows.Forms.TextBox tbCCCD;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.GroupControl groupControl1;
    }
}