using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using SalesDelivery.WebRefSales;

namespace SalesDelivery
{
    public partial class SalesOrder : Form
    {
        public Login LoginForm { get; set; }
        string pickingListId = "";
        //bool halfPallet = false;
        bool sameConfig = false;
        int loadingLine = 0;
        

        public SalesOrder()
        {
            InitializeComponent();
        }

        private void SalesOrder_Load(object sender, EventArgs e)
        {
            ResetControls();
            tbSalesOrder.Focus();
            btnLoading.Enabled = false;

            cmbTruckLines.DataSource = AppVariables.FGLoadingLines;
        }
        
        

        private void menuItemLogoff_Click(object sender, EventArgs e)
        {
            AppVariables.UpdatedBy = string.Empty;
            AppVariables.RoleName = RoleType.Employee;

            Login loginScreen = LoginForm;
            loginScreen.HomeForm = this;
            loginScreen.Show();

            this.Hide();
        }

        private void menuItemTestService_Click(object sender, EventArgs e)
        {
            EnDisControls(false);
            try
            {
                SalesService client = new SalesService();
                MessageBox.Show(client.GetPing(), "Testing Webservice [" + AppVariables.DeviceName + "]");
                client.Dispose();
            }
            catch (WebException exp)
            {
                if (exp.Status == WebExceptionStatus.ConnectFailure)
                {
                    MessageBox.Show("Unable to connect to Dynamics AX. Please contact Network administrator.", "Connect Failure [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Testing Webservice [" + AppVariables.DeviceName + "]");
            }
            finally
            {
                EnDisControls(true);
            }
        }

        private void EnDisControls(bool isEnable)
        {
            btnFind.Enabled = isEnable;
            btnReceive.Enabled = isEnable;
            btnShowOnHand.Enabled = isEnable;
            btnOpenSalesLine.Enabled = isEnable;
            tbSalesOrder.Enabled = isEnable;            
            menuItemFile.Enabled = isEnable;
        }

        public void ResetControls()
        {
            gridSaleLines.DataSource = null;
            gridSaleLines.Refresh();

            tbSalesOrder.Text = string.Empty;
            lbPickingID.Text = string.Empty;
            lbSalesId.Text = string.Empty;
            lbSalesName.Text = string.Empty;
            lbTicketNum.Text = string.Empty;
            cmbTruckLines.SelectedIndex = -1;
            loadingLine = -1;
            //halfPallet = false;
            lbDriverName.Text = string.Empty;
            lbTruckPlate.Text = string.Empty;
            lbPackingSlip.Text = string.Empty;
            //lbHalfPallet.Text = string.Empty;
            sameConfig = false;
            lbSameConfig.Text = string.Empty;
            lbTotLines.Text = string.Empty;
            lbStartLoad.Text = string.Empty;
            lbStopLoad.Text = string.Empty;
            btnLoading.Text = "Start Load";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnLoading.Text = "Start Load";
            EnDisControls(false);
            string msg = string.Empty;
            lbStartLoad.Text = string.Empty;
            lbStopLoad.Text = string.Empty;
            lbSameConfig.Text = string.Empty;

            try
            {
                if (!DBClass.CheckInternet())
                    throw new Exception(AppVariables.NetworkDown);

                tbSalesOrder.Text = tbSalesOrder.Text.Trim().Replace("\r\n", "");
                if (string.IsNullOrEmpty(tbSalesOrder.Text.Trim()))
                {
                    msg = "Please enter Picking list # to search.";
                    new DBClass().SubmitMessage(msg, "SalesOrder.btnFind_Click", "" );
                    MessageBox.Show(msg, "Picking List [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    
                    msg = string.Empty;
                    tbSalesOrder.Focus();
                    return;
                }
                SalesService client = new SalesService();
                SalesTable salesTable = client.FindPickingList(tbSalesOrder.Text.Trim(), AppVariables.UpdatedBy, AppVariables.DeviceName);
                client.Dispose();

                if (salesTable != null && salesTable.SalesId.Length>0)
                {
                    btnLoading.Enabled = true;

                    pickingListId = tbSalesOrder.Text.Trim();
                    lbPickingID.Text = pickingListId;
                    lbSalesId.Text = salesTable.SalesId;
                    lbSalesName.Text = salesTable.SalesName.Replace("&", "&&");
                    //halfPallet = salesTable.HalfPallet;
                    lbDriverName.Text = salesTable.DriverName;
                    lbTruckPlate.Text = salesTable.TruckPlate;
                    lbTicketNum.Text = salesTable.TruckTicketNum;
                    lbPackingSlip.Text = salesTable.PackingSlip;
                    loadingLine = salesTable.LoadingLine;
                    cmbTruckLines.SelectedValue = loadingLine;
                    //lbHalfPallet.Text = halfPallet ? "Yes" : "No";
                    sameConfig = salesTable.PickSameDimension;
                    lbSameConfig.Text = sameConfig ? "Yes" : "No";
                    if (salesTable.StartLoading.Year > 1900)
                    {
                        lbStartLoad.Text = salesTable.StartLoading.ToString("dd/MM/yyyy hh:mm:sstt");
                        lbStartLoad.Tag = salesTable.StartLoading.ToString("s");
                        btnLoading.Text = "Stop Load";
                    }
                    if (salesTable.StopLoading.Year > 1900)
                    {
                        lbStopLoad.Text = salesTable.StopLoading.ToString("dd/MM/yyyy hh:mm:sstt");
                        lbStopLoad.Tag = salesTable.StopLoading.ToString("s");
                        btnLoading.Enabled = false;
                    }

                    gridSaleLines.DataSource = salesTable.Lines;

                    lbTotLines.Text = "(" + salesTable.Lines.Count().ToString()+")";
                    this.dataGridTableStyle1.MappingName = gridSaleLines.DataSource.GetType().Name;

                    if (salesTable.Lines.Count() > 0)
                    {
                        gridSaleLines.Refresh();
                        gridSaleLines.Select(0);
                        tbSalesOrder.Text = string.Empty;
                    }
                }
                else
                {
                    //gridSaleLines.DataSource = null;
                    //gridSaleLines.Refresh();
                    

                    msg = "Picking List# " + tbSalesOrder.Text.Trim() + " was not found.";
                    new DBClass().SubmitMessage(msg, "SalesOrder.btnFind_Click", "");
                    MessageBox.Show(msg, "Picking List [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    msg = string.Empty;
                    
                    ResetControls();
                }
            }            
            catch (WebException exp)
            {
                if (exp.Status == WebExceptionStatus.ConnectFailure)
                {
                    msg = "Unable to connect to Dynamics AX. Please contact Network administrator.";
                    new DBClass().SubmitMessage(msg, "SalesOrder.btnFind_Click", "");
                    MessageBox.Show(msg, "Connect Failure [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    msg = string.Empty;
                }
            }
            catch (Exception exp)
            {
                if (exp.Message.ToLower().Contains("external component"))
                    msg = "Please try again to search.";
                else
                    msg = exp.Message;

                new DBClass().SubmitMessage(msg + " [" + exp.Message + "]", "SalesOrder.btnFind_Click", "");
                MessageBox.Show(msg, "Dynamics AX [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                msg = string.Empty;
            }            
            finally
            {
                EnDisControls(true);
            }
           
            tbSalesOrder.Focus();
        }

        private void tbSalesOrder_TextChanged(object sender, EventArgs e)
        {
            if (tbSalesOrder.Text.Length > 0)
            {
                tbSalesOrder.Text = tbSalesOrder.Text.ToUpper();
                tbSalesOrder.SelectionStart = tbSalesOrder.Text.Length;
                if (tbSalesOrder.Text == "\r\n")
                {
                    tbSalesOrder.Text = string.Empty;
                }
            }
        }

        private void tbSalesOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnFind_Click(sender, e);
                e.Handled = true;
            }
        }

        private void gridSaleLines_CurrentCellChanged(object sender, EventArgs e)
        {
            Point pt = gridSaleLines.PointToClient(Control.MousePosition);
            DataGrid.HitTestInfo info = gridSaleLines.HitTest(pt.X, pt.Y);
            if (info.Type == DataGrid.HitTestType.Cell || info.Type == DataGrid.HitTestType.RowHeader)
            {
                gridSaleLines.Select(info.Row);
            }
        }
        
        private void gridSaleLines_DoubleClick(object sender, EventArgs e)
        {
            string msg = string.Empty;

           Point pt = gridSaleLines.PointToClient(Control.MousePosition);
           DataGrid.HitTestInfo info=gridSaleLines.HitTest(pt.X, pt.Y);
           if (info.Type == DataGrid.HitTestType.Cell || info.Type == DataGrid.HitTestType.RowHeader)
           {
               if (string.IsNullOrEmpty(lbStartLoad.Text.Trim()))
               {
                   msg = "Please press 'Start Load' button to register TimeStamp of truck loading.";
                   new DBClass().SubmitMessage(msg, "SalesOrder.gridSaleLines_DoubleClick", "");
                   MessageBox.Show(msg, "Picking List [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                   msg = string.Empty;
               }
               else if (gridSaleLines.DataSource != null && info.Row == gridSaleLines.CurrentRowIndex)
               {
                   SalesLine row = ((SalesLine[])gridSaleLines.DataSource).ElementAt(gridSaleLines.CurrentRowIndex);
                   ScanPallet scanPallet = new ScanPallet();
                   scanPallet.SalesRow = new List<SalesLine>();
                   scanPallet.PickingId = pickingListId;
                   scanPallet.Text = pickingListId;
                   //scanPallet.HalfPallet = halfPallet;
                   scanPallet.SameConfig = sameConfig;
                   scanPallet.SalesRow.Add(row);
                   scanPallet.ShowDialog();
               }
               else
               {
                   msg = "Either grid is empty OR select a row in the grid to continue.";
                   new DBClass().SubmitMessage(msg, "SalesOrder.gridSaleLines_DoubleClick", "");
                   MessageBox.Show(msg, "Picking List [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                   msg = string.Empty;
               }
           }

           tbSalesOrder.Focus();
        }

        private void btnOpenSalesLine_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (string.IsNullOrEmpty(lbStartLoad.Text.Trim()))
            {
                msg = "Please press 'Start Load' button to register TimeStamp of truck loading.";
                new DBClass().SubmitMessage(msg, "SalesOrder.gridSaleLines_DoubleClick", "");
                MessageBox.Show(msg, "Picking List [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                msg = string.Empty;
            }
            else if (gridSaleLines.DataSource != null && gridSaleLines.CurrentRowIndex != -1)
            {
                SalesLine row = ((SalesLine[])gridSaleLines.DataSource).ElementAt(gridSaleLines.CurrentRowIndex);
                ScanPallet scanPallet = new ScanPallet();
                scanPallet.SalesRow = new List<SalesLine>();
                scanPallet.PickingId = pickingListId;
                scanPallet.Text =  pickingListId;
                //scanPallet.HalfPallet = halfPallet;
                scanPallet.SameConfig = sameConfig;
                scanPallet.SalesRow.Add(row);
                scanPallet.ShowDialog();
            }
            else
            {
                msg = "Either grid is empty OR select a row in the grid to continue.";
                new DBClass().SubmitMessage(msg, "SalesOrder.gridSaleLines_DoubleClick", "");
                MessageBox.Show(msg, "Picking List [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                msg = string.Empty;
            }

            tbSalesOrder.Focus();
        }

        private void AppClose()
        {
            if (MessageBox.Show("Do you want to close the application?", "Close [" + AppVariables.DeviceName + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void SalesOrder_Closing(object sender, CancelEventArgs e)
        {
            AppClose();
        }        

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            AppClose();
        }

        private void menuItemChangePassword_Click(object sender, EventArgs e)
        {
            new ChangePassword().ShowDialog();
        }

        private void SalesOrder_Activated(object sender, EventArgs e)
        {
            this.Text = AppVariables.UpdatedBy + "/" + AppVariables.DeviceName;

            if (AppVariables.RoleName == RoleType.Admin)
            {                
                if (!menuItemFile.MenuItems.Contains(menuItemSettings)) menuItemFile.MenuItems.Add(menuItemSettings);
                if (!menuItemFile.MenuItems.Contains(menuItemShrinkDB)) menuItemFile.MenuItems.Add(menuItemShrinkDB);
                if (!menuItemFile.MenuItems.Contains(menuItemDelOldData)) menuItemFile.MenuItems.Add(menuItemDelOldData);
                if (!menuItemOptions.MenuItems.Contains(menuItemChangePassword)) menuItemOptions.MenuItems.Add(menuItemChangePassword);
                if (!menuItemOptions.MenuItems.Contains(menuItemResetusers)) menuItemOptions.MenuItems.Add(menuItemResetusers);
            }
            else if (AppVariables.RoleName == RoleType.Supervisor)
            {
                if (!menuItemFile.MenuItems.Contains(menuItemSettings)) menuItemFile.MenuItems.Add(menuItemSettings);
                if (!menuItemFile.MenuItems.Contains(menuItemShrinkDB)) menuItemFile.MenuItems.Add(menuItemShrinkDB);
                if (!menuItemFile.MenuItems.Contains(menuItemDelOldData)) menuItemFile.MenuItems.Add(menuItemDelOldData);
                if (!menuItemOptions.MenuItems.Contains(menuItemChangePassword)) menuItemOptions.MenuItems.Add(menuItemChangePassword);
                if (menuItemOptions.MenuItems.Contains(menuItemResetusers)) menuItemOptions.MenuItems.Remove(menuItemResetusers);
               
            }
            else if (AppVariables.RoleName == RoleType.Employee)   
            {
                if (menuItemOptions.MenuItems.Contains(menuItemChangePassword)) menuItemOptions.MenuItems.Remove(menuItemChangePassword);
                if (menuItemFile.MenuItems.Contains(menuItemSettings)) menuItemFile.MenuItems.Remove(menuItemSettings);
                if (menuItemFile.MenuItems.Contains(menuItemShrinkDB)) menuItemFile.MenuItems.Remove(menuItemShrinkDB);
                if (menuItemFile.MenuItems.Contains(menuItemDelOldData)) menuItemFile.MenuItems.Remove(menuItemDelOldData);
                if (menuItemOptions.MenuItems.Contains(menuItemResetusers)) menuItemOptions.MenuItems.Remove(menuItemResetusers);
            }
        }

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            
            //System.Net.NetworkInformation.Ping png = new System.Net.NetworkInformation.Ping();
            new Settings().ShowDialog();
        }

        private void btnLoading_Click(object sender, EventArgs e)
        {
            if (btnLoading.Text.StartsWith("Start"))
            {
                if (string.IsNullOrEmpty(lbSalesId.Text.Trim()))
                {
                    string msg = "No Picking List opened. Cannot start";
                    new DBClass().SubmitMessage(msg, "btnLoading_Click", "");
                    MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }

                DateTime date = DateTime.Now;
                lbStartLoad.Text = date.ToString("dd/MM/yyyy hh:mm:sstt");
                lbStartLoad.Tag = date.ToString("s");
                btnLoading.Text = "Stop Load";

                if (DBClass.CheckInternet())
                {
                    SalesService client = new SalesService();
                    client.BeginSavePickingLoad(pickingListId, date, true, DateTime.MinValue, false,
                        new AsyncCallback(LoadCallback), client);
                }
            }
            else if (btnLoading.Text.StartsWith("Stop"))
            {
                DateTime date = DateTime.Now;
                lbStopLoad.Text = date.ToString("dd/MM/yyyy hh:mm:sstt");
                lbStopLoad.Tag = date.ToString("s");
                if (DBClass.CheckInternet())
                {
                    SalesService client = new SalesService();
                    if (string.IsNullOrEmpty(lbPackingSlip.Text))
                        lbPackingSlip.Text=client.SalesDeliveryNote(lbSalesId.Text);

                    client.BeginSavePickingLoad(pickingListId, DateTime.Parse(lbStartLoad.Tag.ToString()), true, date, true,
                        new AsyncCallback(LoadCallback), client);
                }
                btnLoading.Enabled = false;

                
            }
        }
        static void LoadCallback(IAsyncResult result)
        {
            try
            {
                SalesService client = (SalesService)result.AsyncState;

                if (result.IsCompleted)
                {
                    client.EndSavePickingLoad(result);                    
                }
                client.Dispose();
            }
            catch (Exception exp)
            {
                new DBClass().SubmitMessage(exp.Message, "LoadCallback", exp.StackTrace);

                //MessageBox.Show(exp.Message);
            }

        }

        private void menuItemShrinkDB_Click(object sender, EventArgs e)
        {
            if (new DBClass().ShrinkDatabase())
            {
                string msg = "Database has been shrinked successfully.";
                new DBClass().SubmitMessage(msg, "menuItemShrinkDB_Click", "");
                MessageBox.Show(msg, "Shrink DB", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            tbSalesOrder.Focus();
        }

        private void menuItemDelOldData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete the old data?", "Delete Old data", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (new DBClass().DeleteOldData())
                {
                    string msg = "Old data has been deleted successfully.";
                    new DBClass().SubmitMessage(msg, "menuItemDelOldData_Click", "");
                    MessageBox.Show(msg, "Delete Old data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
            tbSalesOrder.Focus();
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            new Forms.About().Show();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            btnLoading.Text = "Start Load";
            EnDisControls(false);
            string msg = string.Empty;
            lbStartLoad.Text = string.Empty;
            lbStopLoad.Text = string.Empty;
            lbSameConfig.Text = string.Empty;

            try
            {
                if (!DBClass.CheckInternet())
                    throw new Exception(AppVariables.NetworkDown);

                
                SalesService client = new SalesService();
                SalesTable salesTable = client.ReceivePickingList(AppVariables.UpdatedBy, AppVariables.DeviceName);
                client.Dispose();

                if (salesTable != null && salesTable.SalesId.Length > 0)
                {
                    btnLoading.Enabled = true;
                    gridSaleLines.DataSource = null;
                    gridSaleLines.Refresh();

                    pickingListId = salesTable.PickingId.Trim();
                    lbPickingID.Text = pickingListId;
                    lbSalesId.Text = salesTable.SalesId;
                    lbSalesName.Text = salesTable.SalesName.Replace("&", "&&");
                    //halfPallet = salesTable.HalfPallet;
                    lbDriverName.Text = salesTable.DriverName;
                    lbTruckPlate.Text = salesTable.TruckPlate;
                    lbTicketNum.Text = salesTable.TruckTicketNum;
                    lbPackingSlip.Text = salesTable.PackingSlip;
                    loadingLine = salesTable.LoadingLine;
                    cmbTruckLines.SelectedValue = loadingLine;
                    //lbHalfPallet.Text = halfPallet ? "Yes" : "No";
                    sameConfig = salesTable.PickSameDimension;
                    lbSameConfig.Text = sameConfig ? "Yes" : "No";
                    if (salesTable.StartLoading.Year > 1900)
                    {
                        lbStartLoad.Text = salesTable.StartLoading.ToString("dd/MM/yyyy hh:mm:sstt");
                        lbStartLoad.Tag = salesTable.StartLoading.ToString("s");
                        btnLoading.Text = "Stop Load";
                    }
                    if (salesTable.StopLoading.Year > 1900)
                    {
                        lbStopLoad.Text = salesTable.StopLoading.ToString("dd/MM/yyyy hh:mm:sstt");
                        lbStopLoad.Tag = salesTable.StopLoading.ToString("s");
                        btnLoading.Enabled = false;
                    }
                                       

                    lbTotLines.Text = "(" + salesTable.Lines.Count().ToString() + ")";
                    
                    gridSaleLines.DataSource = salesTable.Lines;
                    this.dataGridTableStyle1.MappingName = gridSaleLines.DataSource.GetType().Name;

                    if (salesTable.Lines.Count() > 0)
                    {
                        gridSaleLines.Refresh();
                        gridSaleLines.Select(0);
                        tbSalesOrder.Text = string.Empty;
                    }
                }
                else
                {
                    

                    msg = "No Picking List assigned to you.";
                    new DBClass().SubmitMessage(msg, "SalesOrder.btnReceive_Click", "");
                    MessageBox.Show(msg, "Picking List [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    msg = string.Empty;
                    
                    ResetControls();
                }
            }
            catch (WebException exp)
            {
                if (exp.Status == WebExceptionStatus.ConnectFailure)
                {
                    msg = "Unable to connect to Dynamics AX. Please contact Network administrator.";
                    new DBClass().SubmitMessage(msg, "SalesOrder.btnReceive_Click", "");
                    MessageBox.Show(msg, "Connect Failure [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    msg = string.Empty;
                }
            }
            catch (Exception exp)
            {
                if (exp.Message.ToLower().Contains("external component"))
                    msg = "Please try again to search.";
                else
                    msg = exp.Message;

                new DBClass().SubmitMessage(msg + " [" + exp.Message + "]", "SalesOrder.btnReceive_Click", "");
                MessageBox.Show(msg, "Dynamics AX [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                msg = string.Empty;
            }
            finally
            {
                EnDisControls(true);
            }

            tbSalesOrder.Focus();
        }

        private void btnShowOnHand_Click(object sender, EventArgs e)
        {
            if (gridSaleLines.DataSource != null && gridSaleLines.CurrentRowIndex != -1)
            {
                SalesLine row = ((SalesLine[])gridSaleLines.DataSource).ElementAt(gridSaleLines.CurrentRowIndex);
                if (row.Locations != null && row.Locations.Count() > 0)
                {
                    string msg = row.ItemId + Environment.NewLine+ "Grade: "+row.Grade + Environment.NewLine + "--------------------------------" + Environment.NewLine;
                    foreach (InventByGrLocContract loc in row.Locations)
                    {
                        msg += loc.locationIdField.PadRight(6) + " = " + loc.onHandField.ToString() +" SQM"+ Environment.NewLine;
                    }

                    MessageBox.Show(msg,"On-hand Inventory");
                }
            }
        }

        private void cmbTruckLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbPickingID.Text.Trim()))
            {
                if (!loadingLine.ToString().Equals(cmbTruckLines.SelectedValue.ToString()))
                {
                    SalesService client = new SalesService();
                    try
                    {                        
                        string result = client.ChangeLoadingLine(lbPickingID.Text, int.Parse(cmbTruckLines.SelectedValue.ToString()), true);

                        if (string.IsNullOrEmpty(result))
                            MessageBox.Show("Loading line has been changed successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        else
                        {
                            MessageBox.Show(result, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            cmbTruckLines.SelectedValue = loadingLine;
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message,"Warning",MessageBoxButtons.OK,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        private void menuItemResetusers_Click(object sender, EventArgs e)
        {
            SalesService client = new SalesService();
            DBClass db = new DBClass();
            List<UserInfo> users = new List<UserInfo>();

            try
            {
                
                DialogResult dialogRes = MessageBox.Show("Do you want to reset User Records on this device?", "Reset Users [" + AppVariables.DeviceName + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (dialogRes == DialogResult.Yes)
                {
                    List<UserData> data = client.GetUserData().ToList();
                    foreach (UserData oneRec in data)
                    {
                        users.Add(new UserInfo() { UserName = oneRec.UserName, Password = oneRec.Password, Role = oneRec.UserType });
                    }
                    client.Dispose();
                    db.InsertBulkUsers(users);

                    MessageBox.Show("Bulk users have been reset successfully.", "Reset Users [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                
            }
        }
        
    }
}