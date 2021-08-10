using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using SalesDelivery.WebRefDeviceOps;
using System.Net;
using System.Net.Sockets;
using SalesDelivery.WebRefSales;

namespace SalesDelivery
{
    public partial class Login : Form
    {
        public SalesOrder HomeForm { get; set; }
        Timer timePing = new Timer();
        
        int timeInterval = 60000;   //after 60 seconds

        public Login()
        {
            InitializeComponent();

            try
            {
                //first shrink the db
                new DBClass().DeleteOldData();
                new DBClass().ShrinkDatabase();
            }
            catch { }

            timePing.Interval = timeInterval;
            timePing.Tick += new EventHandler(timePing_Tick);
        }
        
        private void Login_Load(object sender, EventArgs e)
        {
            AppVariables.DeviceName = System.Net.Dns.GetHostName();

            timePing.Enabled = true;
            tbUsername.Focus();
            //ntMsg = Microsoft.WindowsMobile.Status.SystemState.ConnectionsNetworkAdapters + "\r\n" +
              //  ", WiFiConnected: "+Microsoft.WindowsMobile.Status.SystemState.WiFiStateConnected.ToString();
            //MessageBox.Show(ntMsg);
            
            

            lbLinkAppVersion.Text = AppVariables.VersionNumber;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    AppVariables.DeviceIP = ip.ToString();
                    break;
                }
            }

            if (new SalesDelivery.WebRefSales.SalesService().Url.Contains("SyncServicesTest"))
                lbServiceSource.Text = "Stage";
            else
                lbServiceSource.Text = "Live";

            new DBClass().FillDropdowns();
        }
        
        private void Login_Activated(object sender, EventArgs e)
        {
            //tbPassword.Text = string.Empty;
            tbUsername.Focus();
        }

        void timePing_Tick(object sender, EventArgs e)
        {
            try
            {
                if (DBClass.CheckInternet()) //If network is ready.
                {
                    //var host = Dns.GetHostEntry(AppVariables.DeviceName);
                    //string ipStr = string.Empty;

                    //foreach (var ip in host.AddressList)
                    //{
                    //    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    //    {
                    //        ipStr = ip.ToString();
                    //        break;
                    //    }
                    //}

                    string userName = string.IsNullOrEmpty(AppVariables.UpdatedBy) ? string.Empty : AppVariables.UpdatedBy;
                    DeviceOps client = new DeviceOps();
                    client.BeginPing(new DeviceMessage()
                    {
                        Message = "Ping",
                        DeviceIP = AppVariables.DeviceIP,
                        ProjectName = AppVariables.ProjectName,
                        Username = userName,
                        DeviceName = AppVariables.DeviceName,
                        DateOccur = DateTime.Now,
                        DateOccurSpecified = true
                    }, new AsyncCallback(PingCallback), client);

                    new DBClass().SendMessagesAgain();
                }
            }
            catch { }
        }

        static void PingCallback(IAsyncResult result)
        {
            try
            {
                DeviceOps client = (DeviceOps)result.AsyncState;
                bool isPinged = false;
                if (result.IsCompleted)
                    client.EndPing(result, out isPinged, out isPinged);
            }
            catch (Exception exp)
            {
                //new DBClass().SubmitMessage(exp.Message, "PingCallback", exp.StackTrace);
                
                //MessageBox.Show(exp.Message);
            }
        }

        

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text.Trim()))
            {
                MessageBox.Show("Please enter 'Username' to continue.", "Login [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                tbUsername.Focus();
                SystemSounds.Question.Play();
            }
            else
            {
                UserInfo userInfo = new DBClass().CheckLogin(tbUsername.Text.Trim(), tbPassword.Text.Trim());
                if (userInfo != null)
                {
                    this.SuspendLayout();

                    AppVariables.UpdatedBy = userInfo.UserName;


                    if (userInfo.Role == "Employee")
                        AppVariables.RoleName = RoleType.Employee;
                    else if (userInfo.Role == "Supervisor")
                        AppVariables.RoleName = RoleType.Supervisor;
                    else if (userInfo.Role == "Admin")
                        AppVariables.RoleName = RoleType.Admin;

                    tbPassword.Text = string.Empty;
                    string hasWithoutInternet = new DBClass().GetSettings(Option.WithoutInternet);
                    AppVariables.WithoutInternet = bool.Parse(hasWithoutInternet);

                    SalesService client = new SalesService();
                    client.SaveLoginHistory(userInfo.UserName, AppVariables.DeviceName, AppVariables.DeviceIP, AppVariables.ProjectName);

                    SalesOrder homeScreen = null;
                    if (HomeForm != null)
                    {
                        homeScreen = HomeForm;
                        homeScreen.ResetControls();
                    }
                    else
                        homeScreen = new SalesOrder();

                    SystemSounds.Beep.Play();

                    homeScreen.LoginForm = this;
                    homeScreen.Show();

                    this.Hide();
                    this.ResumeLayout();
                }
                else
                {
                    MessageBox.Show("Login failed. Please enter correct username and/or password.", "Login failed [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    tbUsername.Focus();
                    SystemSounds.Question.Play();
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            timePing.Enabled = false;
            Application.Exit();
        }

        private void btLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btLogin_Click(sender, e);
            }
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btLogin_Click(sender, e);
            }
        }

        private void lbLinkAppVersion_Click(object sender, EventArgs e)
        {
            new Forms.About().Show();
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                tbPassword.Focus();
            }
        }

        

        
    }
}