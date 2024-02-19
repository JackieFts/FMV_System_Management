using DevExpress.XtraBars.FluentDesignSystem;
using DevExpress.XtraEditors;
using FMV_SYSTEM_MANAGEMENTS.Controlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    public partial class fFirst_Login : DevExpress.XtraEditors.XtraForm
    {
        public fFirst_Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SYS_USER _user;

        private void fFirst_Login_Load(object sender, EventArgs e)
        {
            this.Hide();
            tbUser.Focus();
            chkRemember.Checked = Properties.Settings.Default.RememberPass;
            tbUser.Text = Properties.Settings.Default.User;
            tbPass.Text = Properties.Settings.Default.Pass;
            fFirst_Welcome frm = new fFirst_Welcome();
            frm.ShowDialog();
        }

        #region UI


        private void tbUser_Enter(object sender, EventArgs e)
        {
            tbUser.BackColor = Color.White;
            panel4.BackColor = Color.White;
            tbPass.BackColor = Color.FromArgb(224, 224, 224);
            panel6.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void tbPass_Enter(object sender, EventArgs e)
        {
            tbPass.BackColor = Color.White;
            panel6.BackColor = Color.White;
            tbUser.BackColor = Color.FromArgb(224, 224, 224);
            panel4.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void tbUser_Leave(object sender, EventArgs e)
        {
            tbUser.BackColor = Color.FromArgb(224, 224, 224);
            panel4.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void tbPass_Leave(object sender, EventArgs e)
        {
            tbPass.BackColor = Color.FromArgb(224, 224, 224);
            panel6.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            tbPass.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            tbPass.UseSystemPasswordChar = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/ltt6998/");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:tailt@fuji-smt.com.sg");
        }

        #endregion


        private async void btnLogin_Click(object sender, EventArgs e)
        {
            
            btnLogin.Enabled = false;
            btnForgot.Enabled = false;
            _user = new SYS_USER();
            if(tbUser.Text == "a" && tbPass.Text == "a" && await _user.checkAccount(tbUser.Text, tbPass.Text))
            {
                if (chkRemember.Checked)
                {
                    Properties.Settings.Default.RememberPass = chkRemember.Checked;
                    Properties.Settings.Default.User = tbUser.Text;
                    Properties.Settings.Default.Pass = tbPass.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.RememberPass = chkRemember.Checked;
                    Properties.Settings.Default.User = "";
                    Properties.Settings.Default.Pass = "";
                    Properties.Settings.Default.Save();
                }
                fMain frm = new fMain();
                Program._userLogin = tbUser.Text;
                await frm.loadLeftMenu();
                frm.Show();
                Program.log.LogMsg(Logger.LogLevel.INFO, "Loadding Main Form with User : [{0}] ................", tbUser.Text);
                this.Hide();
            }
            else
            {
                Properties.Settings.Default.RememberPass = chkRemember.Checked;
                Properties.Settings.Default.User = "";
                Properties.Settings.Default.Pass = "";
                Properties.Settings.Default.Save();
                Program.log.LogMsg(Logger.LogLevel.INFO, "Loadding Form Error with User : [{0}]", tbUser.Text);
                MessageBox.Show("Account is incorrect !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnLogin.Enabled = true;
            btnForgot.Enabled = true;
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Default use & pass for demo version is \"a\"", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void fFirst_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.log.LogMsg(Logger.LogLevel.INFO, "**************************Exit Application*****************************");
            Application.Exit();
        }

        private void btnDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "FMV System Management _ User Manual.pdf";
            saveFileDialog.Filter = "PDF File|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var pathSave = new FileInfo(saveFileDialog.FileName);
                var pathFileTemp = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Manual\\User manual.pdf");
                File.Copy(pathFileTemp.ToString(), pathSave.ToString(), true);
                MessageBox.Show("Done");
            }
        }
    }
}