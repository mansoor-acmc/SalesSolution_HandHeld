using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SalesDelivery
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }        

        private void Settings_Load(object sender, EventArgs e)
        {
            //string hasWithoutInternet = new DBClass().GetSettings(Option.WithoutInternet);
            chkWithoutInternet.Checked = AppVariables.WithoutInternet;
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (new DBClass().SaveSettings(Option.WithoutInternet, chkWithoutInternet.Checked.ToString()))
            {
                AppVariables.WithoutInternet = chkWithoutInternet.Checked;
                MessageBox.Show("Your settings have been saved successfully.", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                this.Close();
            }
        }
    }
}