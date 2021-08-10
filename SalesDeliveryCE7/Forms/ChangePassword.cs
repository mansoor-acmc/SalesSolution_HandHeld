using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SalesDeliveryCE7
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            gridPasswords.DataSource = new DBClass().AllUsers();

        }

        private void gridPasswords_DoubleClick(object sender, EventArgs e)
        {
            Point pt = gridPasswords.PointToClient(Control.MousePosition);
            DataGrid.HitTestInfo info = gridPasswords.HitTest(pt.X, pt.Y);
            if (info.Type == DataGrid.HitTestType.Cell || info.Type == DataGrid.HitTestType.RowHeader)
            {
                if (info.Row == gridPasswords.CurrentRowIndex)
                {
                    DataRow row = ((DataTable)gridPasswords.DataSource).Rows[gridPasswords.CurrentRowIndex];
                    if (row != null)
                    {
                        tbUserName.Text = row["UserName"].ToString();
                        tbPassword.Text = row["Password"].ToString();
                        tbUserName.Tag = row["UserId"].ToString();
                        cmbRole.SelectedItem = row["Role"].ToString();

                        tbUserName.Focus();
                    }
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            tbUserName.Text = tbPassword.Text = string.Empty;
            tbUserName.Tag = 0;
            cmbRole.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUserName.Text.Trim()) || string.IsNullOrEmpty(tbPassword.Text.Trim()))
            {
                MessageBox.Show("Please enter correct username and password.", "Login Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            UserInfo user = new UserInfo()
            {
                UserId = int.Parse(tbUserName.Tag.ToString()),
                UserName = tbUserName.Text,
                Password = tbPassword.Text,
                Role = cmbRole.SelectedItem.ToString()
            };

            bool result = new DBClass().ChangeUserInfo(user);
            if (result)
                MessageBox.Show("User info has been changed successfully.", "Login Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            else
                MessageBox.Show("Cannot change user info.", "Login Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            tbUserName.Text = tbPassword.Text = string.Empty;
            tbUserName.Tag = 0;
            cmbRole.SelectedIndex = 0;

            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow row = ((DataTable)gridPasswords.DataSource).Rows[gridPasswords.CurrentRowIndex];
            if (row != null)
            {
                bool result = new DBClass().DeleteUser((int)row["UserId"]);

                if (result)
                    MessageBox.Show("User has been deleted successfully.", "Login Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                else
                    MessageBox.Show("Cannot delete user.", "Login Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                tbUserName.Text = tbPassword.Text = string.Empty;
                tbUserName.Tag = 0;
                cmbRole.SelectedIndex = 0;

                LoadData();
            }
        }
    }
}