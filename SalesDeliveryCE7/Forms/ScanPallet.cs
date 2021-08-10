using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SalesDeliveryCE7.WebRefSales;
using System.Net;
using System.Media;

namespace SalesDeliveryCE7
{
    public partial class ScanPallet : Form
    {
        public List<SalesLine> SalesRow { get; set; }
        public string PickingId { get; set; }
        public bool HalfPallet { get; set; }
        public bool SameConfig { get; set; }

        string alreadyReservedAnotherSO = "Pallet reserved in another sales order";
        string alreadyReserved = "Pallet already reserved";
        string replacementRequest = "Pallet replacement request";

        

        #region Local Methods  

        private void FindAvailablePallets()
        {
            listPallets.Items.Clear();

            DataTable dt = new DBClass().LoadPickedPallets(PickingId, SalesRow[0].ItemId, SalesRow[0].Grade, SalesRow[0].LineRecId);
            
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem lstItem = new ListViewItem();
                lstItem.ImageIndex = 0;
                var one = new ListViewItem.ListViewSubItem();
                one.Text = dr["PalletID"].ToString();
                lstItem.SubItems.Insert(0, one);
                listPallets.Items.Insert(0,lstItem);

                

                var configId = new ListViewItem.ListViewSubItem();
                if (dr["Grade"] != DBNull.Value)                
                    configId.Text = dr["Grade"].ToString();
                lstItem.SubItems.Insert(1, configId);
                

                decimal qtyDec = 0;
                var qty = new ListViewItem.ListViewSubItem();
                if (dr["Qty"] != DBNull.Value)
                {
                    qty.Text = dr["Qty"].ToString();
                    
                    qtyDec = decimal.Parse(dr["Qty"].ToString());
                }
                lstItem.SubItems.Insert(2, qty);
                

                var size = new ListViewItem.ListViewSubItem();
                if (dr["Size"] != DBNull.Value)                
                    size.Text = dr["Size"].ToString();
                lstItem.SubItems.Insert(3, size);
                

                var color = new ListViewItem.ListViewSubItem();
                if (dr["Color"] != DBNull.Value)                
                    color.Text = dr["Color"].ToString();
                lstItem.SubItems.Insert(4, color);
                

                var halfPallet = new ListViewItem.ListViewSubItem();
                bool isHalfPallet = false;
                if (dr["HalfPallet"] != DBNull.Value)
                    isHalfPallet = bool.Parse(dr["HalfPallet"].ToString());
                halfPallet.Text = isHalfPallet ? "Yes" : "No";
                lstItem.SubItems.Insert(5, halfPallet);

                var remarks = new ListViewItem.ListViewSubItem();
                if (!string.IsNullOrEmpty(dr["Remarks"].ToString()))
                {                    
                    remarks.Text = dr["Remarks"].ToString();
                    

                    if (remarks.Text.Equals(alreadyReservedAnotherSO) || remarks.Text.Equals(replacementRequest))
                    {
                        lstItem.ImageIndex = 1;
                        lstItem.ForeColor = System.Drawing.Color.Orange;
                    }
                    else if (remarks.Text.Equals(alreadyReserved))
                    {
                        lstItem.ImageIndex = 2;
                    }
                    else
                    {
                        lstItem.ImageIndex = 0;
                        if (dr["RecType"].ToString() == "1")
                            lstItem.ImageIndex = 3;
                    }
                }
                else
                {
                    if (bool.Parse(dr["IsReserved"].ToString()))
                        lstItem.ImageIndex = 2;
                    else
                        lstItem.ImageIndex = 1;

                    if (qtyDec.Equals(0))
                    {
                        lstItem.ImageIndex = 1;
                    }
                }
                lstItem.SubItems.Insert(6, remarks);

                if (dr["RecType"].ToString() == "1")
                {
                    lstItem.ImageIndex = 3;
                    //continue;
                }

                var dateCreated = new ListViewItem.ListViewSubItem();
                dateCreated.Text = DateTime.Parse(dr["DateScanned"].ToString()).ToString("yyyy/MM/ddTHH:mm:ss");
                lstItem.SubItems.Insert(7, dateCreated);
            }
            CountPallets();
        }

        private void EnDisControls(bool isEnable)
        {
            btnFind.Enabled = isEnable;
            btnDeleteLine.Enabled = isEnable;
            tbGetScanPallet.Enabled = isEnable;
            btnReserveAll.Enabled = isEnable;
            menuItemFile.Enabled = isEnable;
            btnCheckAvailable.Enabled = isEnable;
        }
        
        private void CountPallets()
        {            
            string specifier = "#,#.##;(#,#.##)";
            lbNumOfScannedPallets.Text =  listPallets.Items.Count.ToString() + "/" + SalesRow[0].SalesQtyPallet.Value.ToString(specifier);
            tbGetScanPallet.Focus();
        }

        #endregion

        

        public ScanPallet()
        {
            InitializeComponent();  
        }

        private void ScanPallet_Activated(object sender, EventArgs e)
        {
            lbUserDevice.Text = AppVariables.UpdatedBy + " [" + AppVariables.DeviceName + "]";
            btnReserveAll.Enabled = true;

            if (AppVariables.WithoutInternet)
            {
                btnCheckAvailable.Visible = true;
                foreach (ListViewItem lstItem in listPallets.Items)
                {
                    if (lstItem.ImageIndex == 3)
                    {
                        btnReserveAll.Enabled = false;
                        break;
                    }                    
                }
            }
            else
            {
                btnCheckAvailable.Visible = false;
            }
        }
        
        private void ScanPallet_Load(object sender, EventArgs e)
        {
            //btnFind.Enabled = true;
            //tbGetScanPallet.Enabled = true;

            

            if (SalesRow != null)
            {                
                gridSaleLine.DataSource = SalesRow;

                if (SalesRow.Count > 0)
                {
                    
                    lbSalesId.Text = SalesRow[0].SalesId;

                    decimal remain=SalesRow[0].SalesQtySQMRemaining.HasValue ? SalesRow[0].SalesQtySQMRemaining.Value : 0;
                    if (remain.Equals(0))
                    {
                        //btnFind.Enabled = false;
                        //tbGetScanPallet.Enabled = false;
                    }
                    if (SalesRow[0].ExclusiveHalfPallet)
                    {
                        lbIsHalfPallet.Text = "Half Pallet";                        
                    }
                    if (SameConfig)
                    {
                        if (lbIsHalfPallet.Text.Length > 0) lbIsHalfPallet.Text += " / ";
                        lbIsHalfPallet.Text += "Same Shade-Caliber";
                    }
                    
                    
                    FindAvailablePallets();
                }

                dataGridTableStyle1.MappingName = gridSaleLine.DataSource.GetType().Name;
                
            }
            

            tbGetScanPallet.Focus();
        }

        

        private void btnFind_Click(object sender, EventArgs e)
        {
            DateTime dtScanned = DateTime.Now;
            string msg = string.Empty;
            EnDisControls(false);
            try
            {
                if (string.IsNullOrEmpty(tbGetScanPallet.Text.Trim()))
                {
                    msg = "Enter pallet# to check";
                    new DBClass().SubmitMessage(msg, "btnFind_Click", "PickingId:" + PickingId);
                    MessageBox.Show(msg, "Find Pallet [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    tbGetScanPallet.Focus();
                    msg = string.Empty;
                    return;
                }
                else if (SalesRow[0].ExclusiveHalfPallet)
                {
                    if (!tbGetScanPallet.Text.Trim().Equals(SalesRow[0].SerialNumber))
                    {
                        msg = "Half Pallet is not matched. You must find Half Pallet: " + SalesRow[0].SerialNumber;
                        new DBClass().SubmitMessage(msg, "btnFind_Click", "PickingId:" + PickingId);
                        MessageBox.Show(msg, "Find Pallet [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                        tbGetScanPallet.Focus();
                        msg = string.Empty;
                        return;
                    }
                }

                decimal qtyTotal = 0;
                bool enableReserveAll=false;
                foreach (ListViewItem item in listPallets.Items)
                {
                    if (item.ImageIndex != 3)
                        enableReserveAll = true;

                    string palletNum = item.SubItems[0].Text.Trim();
                    if (palletNum.Equals(tbGetScanPallet.Text.Trim()))
                    {
                        msg = "Pallet '" + tbGetScanPallet.Text.Trim() + "' is already included in the list. Please enter another Pallet.";
                        new DBClass().SubmitMessage(msg, "btnFind_Click", "PickingId:" + PickingId + ", Pallet:" + tbGetScanPallet.Text.Trim());
                        MessageBox.Show(msg, "Find Pallet [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        tbGetScanPallet.Focus();
                        msg = string.Empty;
                        return;
                    }
                    if (item.SubItems != null && item.SubItems.Count > 2 && !string.IsNullOrEmpty(item.SubItems[2].Text))
                        qtyTotal += decimal.Parse(item.SubItems[2].Text.Trim());
                }
                SalesLine row = SalesRow[gridSaleLine.CurrentRowIndex];
                if (qtyTotal >= row.SalesQtySQM)
                {
                    if (!HalfPallet)//if HalfPallet=False then Qty must not exceed.
                    {
                        msg = "All quantity is already reserved/searched in the list. Cannot reserve more. Check the list down.";
                        new DBClass().SubmitMessage(msg, "btnFind_Click", "PickingId:" + PickingId+", Qty:"+qtyTotal.ToString());
                        MessageBox.Show(msg, "Find Pallet [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        tbGetScanPallet.Focus();
                        msg = string.Empty;
                        return;
                    }
                }
                    
                SalesRow[0].SerialNumber = tbGetScanPallet.Text.Trim();

                //If Scan with Internet option is FALSE
                //then just add pallet# in the ListBox
                if (AppVariables.WithoutInternet)
                {
                    

                    ListViewItem lstItem = new ListViewItem();
                    lstItem.ImageIndex = 3;
                    var one = new ListViewItem.ListViewSubItem();
                    one.Text = tbGetScanPallet.Text.Trim();
                    lstItem.SubItems.Insert(0, one);

                    lstItem.SubItems.Insert(1, new ListViewItem.ListViewSubItem());
                    lstItem.SubItems.Insert(2, new ListViewItem.ListViewSubItem());
                    lstItem.SubItems.Insert(3, new ListViewItem.ListViewSubItem());
                    lstItem.SubItems.Insert(4, new ListViewItem.ListViewSubItem());
                    lstItem.SubItems.Insert(5, new ListViewItem.ListViewSubItem());
                    lstItem.SubItems.Insert(6, new ListViewItem.ListViewSubItem());

                    var dateCreated = new ListViewItem.ListViewSubItem();
                    dateCreated.Text = dtScanned.ToString("yyyy/MM/ddTHH:mm:ss");
                    lstItem.SubItems.Insert(7, dateCreated);

                    listPallets.Items.Insert(0, lstItem);
                    
                    SalesLine pallet = new SalesLine()
                    {
                        PickingId = PickingId,
                        SalesId = SalesRow[0].SalesId,
                        ItemId=SalesRow[0].ItemId,
                        SerialNumber = tbGetScanPallet.Text.Trim(),
                        Remarks = string.Empty,
                        Grade = SalesRow[0].Grade,
                        Color = string.Empty,
                        Size = string.Empty,
                        LineRecId = SalesRow[0].LineRecId
                    };
                    new DBClass().UpdatePallet(pallet, PickingId, dtScanned, false, false, 1);
                    
                }
                else
                //If Scan with Internet option is TRUE then search in Dynamics AX
                //Means Checkbox=UN-CHECKED
                {
                    if (!DBClass.CheckInternet())
                        throw new Exception(AppVariables.NetworkDown);

                    SalesService client = new SalesService();
                    SalesLine pallet = client.CheckPalletAvailable(SalesRow[0].SalesId, SalesRow[0].ItemId, SalesRow[0].Grade,
                        PickingId, tbGetScanPallet.Text.Trim(), AppVariables.UpdatedBy, AppVariables.DeviceName,
                        DateTime.Now, true, SalesRow[0].LineRecId, true);
                    client.Dispose();

                    pallet.LineRecId = SalesRow[0].LineRecId;

                    //If internet is available then following lines will be processed.
                    ListViewItem lstItem = new ListViewItem();
                    lstItem.ImageIndex = 0;
                    var one = new ListViewItem.ListViewSubItem();
                    one.Text = tbGetScanPallet.Text.Trim();
                    lstItem.SubItems.Insert(0, one);
                    listPallets.Items.Insert(0, lstItem);

                    if (pallet != null)
                    {
                        lstItem.ImageIndex = 1;

                        //SalesLine row = SalesRow[gridSaleLine.CurrentRowIndex];
                        decimal qtySqm = pallet.SalesQtySQM.HasValue ? pallet.SalesQtySQM.Value : 0;
                        if (qtySqm > 0)
                        {
                            row.SalesQtySQM = qtySqm;
                            row.SalesQtySQMRemaining = pallet.SalesQtySQMRemaining.HasValue ? pallet.SalesQtySQMRemaining.Value : 0;
                            row.SalesQtySQMReserved = pallet.SalesQtySQMReserved.HasValue ? pallet.SalesQtySQMReserved.Value : 0;
                        }
                        var configId = new ListViewItem.ListViewSubItem();
                        configId.Text = pallet.Grade;
                        lstItem.SubItems.Insert(1, configId);

                        var qty = new ListViewItem.ListViewSubItem();
                        qty.Text = pallet.SalesQty.HasValue ? pallet.SalesQty.Value.ToString() : "0";
                        lstItem.SubItems.Insert(2, qty);

                        var size = new ListViewItem.ListViewSubItem();
                        size.Text = pallet.Size;
                        lstItem.SubItems.Insert(3, size);

                        var color = new ListViewItem.ListViewSubItem();
                        color.Text = pallet.Color;
                        lstItem.SubItems.Insert(4, color);

                        var halfPallet = new ListViewItem.ListViewSubItem();
                        halfPallet.Text = pallet.IsHalfPallet ? "Yes" : "No";
                        lstItem.SubItems.Insert(5, halfPallet);

                        pallet.SalesId = SalesRow[0].SalesId;
                        pallet.ItemId = SalesRow[0].ItemId;

                        if (string.IsNullOrEmpty(pallet.Remarks))                            
                        {
                            pallet.Remarks = string.Empty;
                            new DBClass().UpdatePallet(pallet, PickingId, dtScanned, false, true, 0);
                        }
                        else if (pallet.Remarks.Equals(alreadyReserved))//if already reserved, either manually
                        {
                            new DBClass().UpdatePallet(pallet, PickingId, dtScanned, true, false, 0);
                            lstItem.ImageIndex = 2;
                        }
                        else
                        {
                            var remarks = new ListViewItem.ListViewSubItem();
                            remarks.Text = pallet.Remarks;
                            lstItem.SubItems.Insert(6, remarks);
                            //lstItem.BackColor = System.Drawing.Color.Red;
                            //lstItem.ForeColor = System.Drawing.Color.Yellow;                        

                            if (pallet.Remarks.Equals(alreadyReservedAnotherSO))
                            {
                                lstItem.ImageIndex = 1;
                                lstItem.ForeColor = System.Drawing.Color.Orange;
                                new DBClass().UpdatePallet(pallet, PickingId, dtScanned, false, true, 0);
                            }
                            else
                            {
                                lstItem.ImageIndex = 0;
                                new DBClass().UpdatePallet(pallet, PickingId, dtScanned, false, false, 0);
                            }
                        }
                       
                    }
                    else
                    {
                        new DBClass().UpdatePallet(pallet, PickingId, dtScanned, false, false, 0);
                        lstItem.ImageIndex = 0;
                        msg = "Pallet '" + tbGetScanPallet.Text.Trim() + "' was not found. Please enter correct Pallet#";
                        new DBClass().SubmitMessage(msg, "btnFind_Click", "PickingId:" + PickingId+", Pallet:"+tbGetScanPallet.Text.Trim());
                        MessageBox.Show(msg, "Find Pallet [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        msg = string.Empty;
                    }
                }
                
                
                tbGetScanPallet.Text = string.Empty;
            }
            catch (WebException exp)
            {
                if (exp.Status == WebExceptionStatus.ConnectFailure)
                {
                    msg = "Unable to connect to Dynamics AX. Please contact Network administrator.";
                    new DBClass().SubmitMessage(msg, "btnFind_Click", "PickingId:" + PickingId);
                    MessageBox.Show(msg, "Connect Failure [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    msg = string.Empty;
                }
            }
            catch (Exception exp)
            {
                if (exp.Message.ToLower().Contains("external component"))
                    msg = "Please try again to search the pallet.";
                else
                    msg = exp.Message;

                new DBClass().SubmitMessage(msg + " ["+exp.Message+"]", "btnFind_Click", "PickingId:" + PickingId);
                MessageBox.Show(msg, "Dynamics AX [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                msg = string.Empty;  
            }
            finally
            {
                CountPallets();
                EnDisControls(true);
            }

            tbGetScanPallet.Focus();
        }

        private void btnCheckAvailable_Click(object sender, EventArgs e)
        {
            DateTime dtScanned = DateTime.Now;
            List<PalletItemContract> serials = new List<PalletItemContract>();
            EnDisControls(false);
            string msg = string.Empty;
            bool isCritical = false;

            try
            {
                if (!DBClass.CheckInternet())
                    throw new Exception(AppVariables.NetworkDown);


                foreach (ListViewItem item in listPallets.Items)
                {
                    if (item.ImageIndex == 3)
                    {
                        PalletItemContract palletItem = new PalletItemContract();
                        string palletNum = item.SubItems[0].Text.Trim();
                        palletItem.serialField = palletNum;
                        try
                        {
                            palletItem.updatedDateField = DateTime.Parse(item.SubItems[7].Text.Trim());
                        }
                        catch { palletItem.updatedDateField = DateTime.Now; }

                        palletItem.updatedDateFieldSpecified1 = true;
                        palletItem.updatedByField = AppVariables.UpdatedBy;
                        serials.Add(palletItem);
                    }
                }
                if (serials.Count.Equals(0))
                {
                    msg = "There is no new pallet in the list to check its availability.";
                    new DBClass().SubmitMessage(msg, "btnCheckAvailable_Click", "");
                    MessageBox.Show(msg, "Find Pallet [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    msg = string.Empty;
                    return;
                }


                SalesLine row = SalesRow[gridSaleLine.CurrentRowIndex];
                SalesService client = new SalesService();
                var pallets = client.CheckPalletAvailableMulti(row.SalesId, row.ItemId, row.Grade,
                    PickingId, serials.ToArray(), AppVariables.UpdatedBy, AppVariables.DeviceName, row.LineRecId, true);
                client.Dispose();

                foreach (SalesLine pallet in pallets)
                {
                    pallet.LineRecId = row.LineRecId;
                    ListViewItem lstItem = null;
                    foreach (ListViewItem item in listPallets.Items)
                    {
                        if (item.SubItems[0].Text.Trim() == pallet.SerialNumber)
                        {
                            lstItem = item;
                            break;
                        }
                    }
                    if (lstItem != null)
                    {
                        lstItem.SubItems.Clear();
                        var serialNum = new ListViewItem.ListViewSubItem();
                        serialNum.Text = pallet.SerialNumber;
                        lstItem.SubItems.Insert(0, serialNum);
                        lstItem.ImageIndex = 1;

                        decimal qtySqm = pallet.SalesQtySQM.HasValue ? pallet.SalesQtySQM.Value : 0;
                        if (qtySqm > 0)
                        {
                            row.SalesQtySQM = qtySqm;
                            row.SalesQtySQMRemaining = pallet.SalesQtySQMRemaining.HasValue ? pallet.SalesQtySQMRemaining.Value : 0;
                            row.SalesQtySQMReserved = pallet.SalesQtySQMReserved.HasValue ? pallet.SalesQtySQMReserved.Value : 0;
                        }
                        var configId = new ListViewItem.ListViewSubItem();
                        configId.Text = pallet.Grade;
                        lstItem.SubItems.Insert(1, configId);

                        var qty = new ListViewItem.ListViewSubItem();
                        qty.Text = pallet.SalesQty.HasValue ? pallet.SalesQty.Value.ToString() : "0";
                        lstItem.SubItems.Insert(2, qty);
                        if (pallet.SalesQty.HasValue)
                        {
                            if (pallet.SalesQty.Value.Equals(0))
                                lstItem.ImageIndex = 1;
                        }

                        var size = new ListViewItem.ListViewSubItem();
                        size.Text = pallet.Size;
                        lstItem.SubItems.Insert(3, size);

                        var color = new ListViewItem.ListViewSubItem();
                        color.Text = pallet.Color;
                        lstItem.SubItems.Insert(4, color);

                        var halfPallet = new ListViewItem.ListViewSubItem();
                        halfPallet.Text = pallet.IsHalfPallet ? "Yes" : "No";
                        lstItem.SubItems.Insert(5, halfPallet);

                        pallet.SalesId = SalesRow[0].SalesId;
                        pallet.ItemId = SalesRow[0].ItemId;
                        if (!string.IsNullOrEmpty(pallet.Remarks))
                        {
                            isCritical = true;
                            var remarks = new ListViewItem.ListViewSubItem();
                            remarks.Text = pallet.Remarks;
                            lstItem.SubItems.Insert(6, remarks);

                            if (pallet.Remarks.Equals(alreadyReservedAnotherSO))//if already reserved in another SO
                            {
                                lstItem.ImageIndex = 1;
                                lstItem.ForeColor = System.Drawing.Color.Orange;
                                new DBClass().UpdatePallet(pallet, PickingId, dtScanned, false, true, 0);
                            }
                            else if (pallet.Remarks.Equals(alreadyReserved))//if already reserved in same SO, either manually
                            {
                                new DBClass().UpdatePallet(pallet, PickingId, dtScanned, true, false, 0);
                                lstItem.ImageIndex = 2;
                            }
                            else
                            {
                                lstItem.ImageIndex = 0;
                                new DBClass().UpdatePallet(pallet, PickingId, dtScanned, false, false, 0);
                            }
                        }
                        else
                        {
                            pallet.Remarks = string.Empty;
                            if (string.IsNullOrEmpty(pallet.Grade) &&
                                string.IsNullOrEmpty(pallet.Color) &&
                                string.IsNullOrEmpty(pallet.Size))
                                new DBClass().UpdatePallet(pallet, PickingId, dtScanned, false, true, 1);
                            else
                                new DBClass().UpdatePallet(pallet, PickingId, dtScanned, false, true, 0);
                        }
                    }
                }

                if (isCritical)
                    SystemSounds.Question.Play();
                else
                    SystemSounds.Beep.Play();
            }
            catch (WebException exp)
            {
                SystemSounds.Question.Play();
                if (exp.Status == WebExceptionStatus.ConnectFailure)
                {
                    msg = "Unable to connect to Dynamics AX. Please contact Network administrator.";
                    new DBClass().SubmitMessage(msg, "btnCheckAvailable_Click", "PickingId:" + PickingId);
                    MessageBox.Show(msg, "Connect Failure [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    msg = string.Empty;
                }
                
            }
            catch (Exception exp)
            {
                SystemSounds.Question.Play();
                if (exp.Message.ToLower().Contains("external component"))
                    msg = "Please try again to check the pallets availability.";
                else
                    msg = exp.Message;

                new DBClass().SubmitMessage(msg + " [" + exp.Message + "]", "btnCheckAvailable_Click", "PickingId:" + PickingId);
                MessageBox.Show(msg, "Dynamics AX [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                msg = string.Empty;
            }
            finally
            {
                
                EnDisControls(true);
            }
        }
               
        
        private void btnReserveAll_Click(object sender, EventArgs e)
        {
            DateTime dtScanned = DateTime.Now;
            DBClass db = new DBClass();
            List<string> serials = new List<string>();
            List<string> serialsHalfPallets = new List<string>();
            string msg = string.Empty;

            EnDisControls(false);

            try
            {
                if (!DBClass.CheckInternet())
                    throw new Exception(AppVariables.NetworkDown);

                foreach (ListViewItem item in listPallets.Items)
                {
                    string palletNum = item.SubItems[0].Text;
                    string isHalfPallet = item.SubItems[5].Text;
                    string remarks = item.SubItems[6].Text;

                    DataTable dt = db.LoadPallet(palletNum, PickingId);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        if (bool.Parse(dr["IsAvailable"].ToString()) && !bool.Parse(dr["IsReserved"].ToString()))
                        {
                            if (isHalfPallet.ToLower().Trim() == "yes")
                                serialsHalfPallets.Add(palletNum);
                            else
                                serials.Add(palletNum);
                        }
                        else if (bool.Parse(dr["IsReserved"].ToString()))
                        {
                            if (remarks.Equals(alreadyReserved))
                            {
                                if (isHalfPallet.ToLower().Trim() == "yes")
                                    serialsHalfPallets.Add(palletNum);
                                else
                                    serials.Add(palletNum);
                            }
                            else
                                continue;
                        }
                        else if (!bool.Parse(dr["IsAvailable"].ToString()))
                        {
                            item.Selected = true;
                            msg = "Before reservation please check Pallet: " + palletNum + ". ";
                            new DBClass().SubmitMessage(msg, "btnReserveAll_Click", "PickingId:" + PickingId + ", Pallet:" + palletNum);
                            MessageBox.Show(msg, "Reserve Pallet [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                            msg = string.Empty;
                            item.Focused = true;
                            return;
                        }
                        else
                        {
                            if (isHalfPallet.ToLower().Trim() == "yes")
                                serialsHalfPallets.Add(palletNum);
                            else
                                serials.Add(palletNum);
                        }
                    }
                }
                if (serials.Count == 0 && serialsHalfPallets.Count == 0)
                {
                    msg = "No pallet has been selected to reserve OR all pallets have already been reserved. ";
                    new DBClass().SubmitMessage(msg, "btnReserveAll_Click", "PickingId:" + PickingId);
                    MessageBox.Show(msg, "Reserve Pallets [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    msg = string.Empty; 
                    return;
                }

                SalesService client = new SalesService();
                //first reserve full pallets.                
                SalesLine[] palletsFull = client.ValidatePallets(SalesRow[0].SalesId, SalesRow[0].ItemId, SalesRow[0].Grade, PickingId, serials.ToArray(), AppVariables.UpdatedBy, AppVariables.DeviceName, SalesRow[0].LineRecId, true);
                SalesLine[] palletsHalf = client.ValidatePallets(SalesRow[0].SalesId, SalesRow[0].ItemId, SalesRow[0].Grade, PickingId, serialsHalfPallets.ToArray(), AppVariables.UpdatedBy, AppVariables.DeviceName, SalesRow[0].LineRecId, true);
                List<SalesLine> pallets = new List<SalesLine>();
                pallets.AddRange(palletsFull);
                pallets.AddRange(palletsHalf);
                client.Dispose();


                if (pallets != null && pallets.Count() > 0)
                {
                    //int i = 0;
                    foreach (SalesLine pallet in pallets)
                    {
                        pallet.LineRecId = SalesRow[0].LineRecId;
                        ListViewItem lstItem = null;
                        foreach (ListViewItem item in listPallets.Items)
                        {
                            if (item.SubItems[0].Text == pallet.SerialNumber)
                            {
                                lstItem = item;
                                break;
                            }
                        }

                        var configId = new ListViewItem.ListViewSubItem();
                        configId.Text = pallet.Grade;
                        lstItem.SubItems.Insert(1, configId);

                        var qty = new ListViewItem.ListViewSubItem();
                        qty.Text = pallet.SalesQty.HasValue ? pallet.SalesQty.Value.ToString() : "0";
                        lstItem.SubItems.Insert(2, qty);

                        /*var size = new ListViewItem.ListViewSubItem();
                        size.Text = pallet.Size;
                        lstItem.SubItems.Insert(3, size);

                        var color = new ListViewItem.ListViewSubItem();
                        color.Text = pallet.Color;
                        lstItem.SubItems.Insert(4, color);

                        var halfPallet = new ListViewItem.ListViewSubItem();
                        halfPallet.Text = pallet.IsHalfPallet ? "Yes" : "No";
                        lstItem.SubItems.Insert(5, halfPallet);*/

                        pallet.SalesId = SalesRow[0].SalesId;
                        pallet.ItemId = SalesRow[0].ItemId;
                        if (string.IsNullOrEmpty(pallet.Remarks) ||
                            pallet.Remarks.Equals(alreadyReserved))//if already reserved, either manually
                        {
                            SalesRow[0].SalesQtySQM = pallet.SalesQtySQM.HasValue ? pallet.SalesQtySQM.Value : 0;
                            SalesRow[0].SalesQtySQMRemaining = pallet.SalesQtySQMRemaining.HasValue ? pallet.SalesQtySQMRemaining.Value : 0;
                            SalesRow[0].SalesQtySQMReserved = pallet.SalesQtySQMReserved.HasValue ? pallet.SalesQtySQMReserved.Value : 0;

                            pallet.Remarks = string.Empty;
                            db.UpdatePallet(pallet, PickingId, dtScanned, true, true, 0);
                            lstItem.ImageIndex = 2;
                        }
                        else //if it has some issue
                        {
                            var remarks = new ListViewItem.ListViewSubItem();
                            remarks.Text = pallet.Remarks;
                            lstItem.SubItems.Insert(6, remarks);
                            //lstItem.BackColor = System.Drawing.Color.Red;
                            //lstItem.ForeColor = System.Drawing.Color.Yellow;
                            lstItem.ImageIndex = 0;

                            db.UpdatePallet(pallet, PickingId, dtScanned, false, true, 0);
                        }
                        

                    }

                    gridSaleLine.DataSource = SalesRow;

                    msg = "Pallet(s) have been reserved successfully.";
                    new DBClass().SubmitMessage(msg, "btnReserveAll_Click", "PickingId:" + PickingId + ", Pallets:" + string.Join(";", serials.ToArray()) + ";" + string.Join(";", serialsHalfPallets.ToArray()));
                    MessageBox.Show(msg, "Reserve Pallet [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    msg = string.Empty;
                }
            }
            catch (WebException exp)
            {
                if (exp.Status == WebExceptionStatus.ConnectFailure)
                {
                    msg = "Unable to connect to Dynamics AX. Please contact Network administrator.";
                    new DBClass().SubmitMessage(msg, "btnReserveAll_Click", "PickingId:" + PickingId);
                    MessageBox.Show(msg, "Connect Failure [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    msg = string.Empty;
                }
            }
            catch (Exception exp)
            {
                if (exp.Message.ToLower().Contains("external component"))
                    msg = "Please try again to search the pallet.";
                else
                    msg = exp.Message;

                new DBClass().SubmitMessage(msg + " [" + exp.Message + "]", "btnReserveAll_Click", "PickingId:" + PickingId);
                MessageBox.Show(msg, "Dynamics AX [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                msg = string.Empty;
            }
            finally
            {
                EnDisControls(true);
            }
            tbGetScanPallet.Focus();
        }
        
        private void tbGetScanPallet_TextChanged(object sender, EventArgs e)
        {
            if (tbGetScanPallet.Text.Length > 0)
            {
                tbGetScanPallet.Text = tbGetScanPallet.Text.ToUpper();
                tbGetScanPallet.SelectionStart = tbGetScanPallet.Text.Length;
                if (tbGetScanPallet.Text == "\r\n")
                {
                    tbGetScanPallet.Text = string.Empty;
                }
            }
        }

        private void tbGetScanPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnFind_Click(sender, e);
                e.Handled = false;
            }
        }

        private void listPallets_ItemActivate(object sender, EventArgs e)
        {
            if (listPallets.SelectedIndices != null && listPallets.SelectedIndices.Count > 0)
            {
                ListViewItem lstItem = listPallets.Items[listPallets.SelectedIndices[0]];
                string itemRemarks = lstItem.SubItems[0].Text;
                if (lstItem.SubItems.Count > 1)
                    itemRemarks = "Serial# " + lstItem.SubItems[1].Text;
                if (lstItem.SubItems.Count > 2)
                    itemRemarks = "Grade: " + lstItem.SubItems[2].Text;
                if (lstItem.SubItems.Count > 6)
                    itemRemarks = "Remarks: " + lstItem.SubItems[6].Text;

                MessageBox.Show(itemRemarks, "Pallet Info [" + AppVariables.DeviceName + "]");
            }
        }

       
        private void menuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteLine_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (listPallets.SelectedIndices.Count > 0)
            {
                EnDisControls(false);
                try
                {
                    ListViewItem itemToRemove = listPallets.Items[listPallets.SelectedIndices[0]];
                    if (itemToRemove != null)
                    {
                        DBClass db = new DBClass();
                        string palletId = itemToRemove.SubItems[0].Text;
                        DataTable dt = db.LoadPallet(palletId, PickingId);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt.Rows[0];
                            if (bool.Parse(dr["IsReserved"].ToString()))
                            {
                                if (MessageBox.Show("Pallet: '" + palletId + "' has already been reserved. Do you want to remove the reservation?", "Reserve Pallet [" + AppVariables.DeviceName + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    SalesService client = new SalesService();
                                    client.UnreservePallet(palletId, PickingId, AppVariables.UpdatedBy, AppVariables.DeviceName);
                                    client.Dispose();
                                }
                                else
                                {
                                    tbGetScanPallet.Focus();
                                    return;
                                }
                            }
                            
                            db.DeletePallet(palletId, PickingId);
                            listPallets.Items.Remove(itemToRemove);
                            if (listPallets.Items.Count > 0)
                            {
                                listPallets.Items[0].Selected = true;
                            }
                            msg = "Pallet(s) have been removed successfully.";
                            new DBClass().SubmitMessage(msg, "btnDeleteLine_Click", "PickingId:" + PickingId + ", Pallet:" + palletId + ";" );
                            //MessageBox.Show(msg, "btnDeleteLine_Click Pallet", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            msg = string.Empty;
                        }
                    }
                }
                catch (WebException exp)
                {
                    if (exp.Status == WebExceptionStatus.ConnectFailure)
                    {
                        msg = "Unable to connect to Dynamics AX. Please contact Network administrator.";
                        new DBClass().SubmitMessage(msg, "btnDeleteLine_Click", "PickingId:" + PickingId);
                        MessageBox.Show(msg, "Connect Failure [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        msg = string.Empty;
                    }
                }
                catch (Exception exp)
                {
                    if (exp.Message.ToLower().Contains("external component"))
                        msg = "Please try again to delete the pallet.";
                    else
                        msg = exp.Message;

                    new DBClass().SubmitMessage(msg + " [" + exp.Message + "]", "btnDeleteLine_Click", "PickingId:" + PickingId);
                    MessageBox.Show(msg, "Dynamics AX [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    msg = string.Empty;
                }                
                finally
                {
                    CountPallets();
                    EnDisControls(true);
                }
            }
            else
            {
                msg = "Please select pallet to remove.";
                new DBClass().SubmitMessage(msg, "btnDeleteLine_Click", "PickingId:" + PickingId);
                MessageBox.Show(msg, "Remove Pallet [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                msg = string.Empty;
            }
            tbGetScanPallet.Focus();
        }

        private void menuItemShowReserved_Click(object sender, EventArgs e)
        {
            ViewReserved frmView = new ViewReserved();
            frmView.PickingId = PickingId;
            frmView.ItemId = SalesRow[0].ItemId;
            frmView.Grade = SalesRow[0].Grade;
            frmView.LineRecId = SalesRow[0].LineRecId;
            frmView.ShowDialog();
            tbGetScanPallet.Focus();
        }

        private void menuItemGetLatest_Click(object sender, EventArgs e)
        {
            
            List<SalesLine> rows=new List<SalesLine>();
            string itemId = string.Empty, msg=string.Empty;
            EnDisControls(false);

            try
            {
                if (!DBClass.CheckInternet())
                    throw new Exception(AppVariables.NetworkDown);

                SalesService client = new SalesService();
                
                itemId = SalesRow[0].ItemId;
                var result = client.GetLatestPallets(PickingId, itemId);
                if (result.Count() > 0)
                    rows = result.ToList();
                client.Dispose();

                string pallets = "";
                DBClass db = new DBClass();

                foreach (SalesLine row in rows)
                {
                    if (pallets.Length > 0) pallets += ",";
                    pallets += "'" + row.SerialNumber + "'";
                    if (row.Remarks.Contains(replacementRequest))
                        db.UpdatePallet(row, PickingId, DateTime.Now, false, false, 0);
                    else
                    {
                        if (row.SalesQty.HasValue && row.SalesQty.Value > 0)
                            db.UpdatePallet(row, PickingId, DateTime.Now, true, false, 0);
                        else
                            db.UpdatePallet(row, PickingId, DateTime.Now, false, true, 0);
                    }
                }

                string rendundantPallets = "";
                string rendundantPalletsForMsg = "";
                DataTable dtRedundant = db.CheckRedundantPallets(PickingId, itemId, pallets);
                if (dtRedundant != null && dtRedundant.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtRedundant.Rows)
                    {
                        if (rendundantPallets.Length > 0) rendundantPallets += ",";
                        rendundantPallets += "'" + dr["PalletId"].ToString() + "'";

                        if (rendundantPalletsForMsg.Length > 0) rendundantPalletsForMsg += ", ";
                        rendundantPalletsForMsg += dr["PalletId"].ToString();
                    }

                    if (rendundantPallets.Length > 0)
                    {
                        if (MessageBox.Show("Reservation data has been refreshed. \r\nWhile getting the latest reservations following pallets are not reserved in Dynamics AX. \r\n" + rendundantPalletsForMsg + "\r\nDo you want to remove them from this device?", "Get Latest data [" + AppVariables.DeviceName + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            db.DeletePalletsRedundant(PickingId, rendundantPallets, true);
                        else
                            db.DeletePalletsRedundant(PickingId, rendundantPallets, false);
                    }

                }
                else
                {
                    msg = "Reservation data has been refreshed successfully.";
                    new DBClass().SubmitMessage(msg, "menuItemGetLatest_Click", "PickingId:" + PickingId);
                    MessageBox.Show(msg, "Get Latest data [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    msg = string.Empty;
                }
            }
            catch (WebException exp)
            {
                if (exp.Status == WebExceptionStatus.ConnectFailure)
                {
                    msg = "Unable to connect to Dynamics AX. Please contact Network administrator.";
                    new DBClass().SubmitMessage(msg, "menuItemGetLatest_Click", "PickingId:" + PickingId);
                    MessageBox.Show(msg, "Connect Failure [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    msg = string.Empty;
                }
            }
            catch (Exception exp)
            {
                if (exp.Message.ToLower().Contains("external component"))
                    msg = "Please try again to search the pallet.";
                else
                    msg = exp.Message;

                new DBClass().SubmitMessage(msg + " [" + exp.Message + "]", "menuItemGetLatest_Click", "PickingId:" + PickingId);
                MessageBox.Show(msg, "Dynamics AX [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                msg = string.Empty;
            }            
            finally
            {
                FindAvailablePallets();
                EnDisControls(true);
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the application?", "Close [" + AppVariables.DeviceName + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        

        

        

        

        
    }
}