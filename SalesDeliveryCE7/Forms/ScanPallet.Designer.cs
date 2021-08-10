namespace SalesDeliveryCE7
{
    partial class ScanPallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanPallet));
            this.gridSaleLine = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.colItemId = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colExclusiveHalfPallet = new System.Windows.Forms.DataGridTextBoxColumn();
            this.GradeCol = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colQtySQMReserved = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colQtySQMRemain = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SalesQtySQM = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SalesUnit = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SalesQtyPallet = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SalesQtyBox = new System.Windows.Forms.DataGridTextBoxColumn();
            this.ColorCol = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SizeCol = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SiteCol = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Warehouse = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colSerialNum = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbSalesId = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGetScanPallet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbUserDevice = new System.Windows.Forms.Label();
            this.listPallets = new System.Windows.Forms.ListView();
            this.colSerial = new System.Windows.Forms.ColumnHeader();
            this.colGrade = new System.Windows.Forms.ColumnHeader();
            this.colQtySqm = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.colColor = new System.Windows.Forms.ColumnHeader();
            this.colIsHalfPallet = new System.Windows.Forms.ColumnHeader();
            this.colRemarks = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.imageListSmall = new System.Windows.Forms.ImageList();
            this.panelFindPallet = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lbNumOfScannedPallets = new System.Windows.Forms.Label();
            this.btnCheckAvailable = new System.Windows.Forms.Button();
            this.btnReserveAll = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemGetLatest = new System.Windows.Forms.MenuItem();
            this.menuItemShowReserved = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItemClose = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbIsHalfPallet = new System.Windows.Forms.Label();
            this.btnDeleteLine = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panelFindPallet.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridSaleLine
            // 
            this.gridSaleLine.BackColor = System.Drawing.Color.Black;
            this.gridSaleLine.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridSaleLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridSaleLine.ForeColor = System.Drawing.Color.White;
            this.gridSaleLine.Location = new System.Drawing.Point(3, 17);
            this.gridSaleLine.Name = "gridSaleLine";
            this.gridSaleLine.RowHeadersVisible = false;
            this.gridSaleLine.Size = new System.Drawing.Size(312, 50);
            this.gridSaleLine.TabIndex = 8;
            this.gridSaleLine.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colItemId);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colExclusiveHalfPallet);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.GradeCol);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colQtySQMReserved);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colQtySQMRemain);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.SalesQtySQM);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.SalesUnit);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.SalesQtyPallet);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.SalesQtyBox);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.ColorCol);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.SizeCol);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.SiteCol);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.Warehouse);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colItemName);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colSerialNum);
            // 
            // colItemId
            // 
            this.colItemId.Format = "";
            this.colItemId.FormatInfo = null;
            this.colItemId.HeaderText = "Item";
            this.colItemId.MappingName = "ItemId";
            this.colItemId.Width = 114;
            // 
            // colExclusiveHalfPallet
            // 
            this.colExclusiveHalfPallet.Format = "";
            this.colExclusiveHalfPallet.FormatInfo = null;
            this.colExclusiveHalfPallet.HeaderText = "Half Pallet";
            this.colExclusiveHalfPallet.MappingName = "ExclusiveHalfPallet";
            this.colExclusiveHalfPallet.Width = 55;
            // 
            // GradeCol
            // 
            this.GradeCol.Format = "";
            this.GradeCol.FormatInfo = null;
            this.GradeCol.HeaderText = "Grade";
            this.GradeCol.MappingName = "Grade";
            this.GradeCol.Width = 45;
            // 
            // colQtySQMReserved
            // 
            this.colQtySQMReserved.Format = "n2";
            this.colQtySQMReserved.FormatInfo = null;
            this.colQtySQMReserved.HeaderText = "Reserv";
            this.colQtySQMReserved.MappingName = "SalesQtySQMReserved";
            // 
            // colQtySQMRemain
            // 
            this.colQtySQMRemain.Format = "n2";
            this.colQtySQMRemain.FormatInfo = null;
            this.colQtySQMRemain.HeaderText = "Remain";
            this.colQtySQMRemain.MappingName = "SalesQtySQMRemaining";
            // 
            // SalesQtySQM
            // 
            this.SalesQtySQM.Format = "n2";
            this.SalesQtySQM.FormatInfo = null;
            this.SalesQtySQM.HeaderText = "SQM";
            this.SalesQtySQM.MappingName = "SalesQtySQM";
            // 
            // SalesUnit
            // 
            this.SalesUnit.Format = "";
            this.SalesUnit.FormatInfo = null;
            this.SalesUnit.HeaderText = "Unit";
            this.SalesUnit.MappingName = "SalesUnit";
            // 
            // SalesQtyPallet
            // 
            this.SalesQtyPallet.Format = "";
            this.SalesQtyPallet.FormatInfo = null;
            this.SalesQtyPallet.HeaderText = "Pallets";
            this.SalesQtyPallet.MappingName = "SalesQtyPallet";
            // 
            // SalesQtyBox
            // 
            this.SalesQtyBox.Format = "";
            this.SalesQtyBox.FormatInfo = null;
            this.SalesQtyBox.HeaderText = "Boxes";
            this.SalesQtyBox.MappingName = "SalesQtyBox";
            // 
            // ColorCol
            // 
            this.ColorCol.Format = "";
            this.ColorCol.FormatInfo = null;
            this.ColorCol.HeaderText = "Color";
            this.ColorCol.MappingName = "Color";
            // 
            // SizeCol
            // 
            this.SizeCol.Format = "";
            this.SizeCol.FormatInfo = null;
            this.SizeCol.HeaderText = "Size";
            this.SizeCol.MappingName = "Size";
            // 
            // SiteCol
            // 
            this.SiteCol.Format = "";
            this.SiteCol.FormatInfo = null;
            this.SiteCol.HeaderText = "Site";
            this.SiteCol.MappingName = "Site";
            // 
            // Warehouse
            // 
            this.Warehouse.Format = "";
            this.Warehouse.FormatInfo = null;
            this.Warehouse.HeaderText = "Warehouse";
            this.Warehouse.MappingName = "Warehouse";
            this.Warehouse.Width = 70;
            // 
            // colItemName
            // 
            this.colItemName.Format = "";
            this.colItemName.FormatInfo = null;
            this.colItemName.HeaderText = "Item Name";
            this.colItemName.MappingName = "Name";
            this.colItemName.Width = 200;
            // 
            // colSerialNum
            // 
            this.colSerialNum.Format = "";
            this.colSerialNum.FormatInfo = null;
            this.colSerialNum.HeaderText = "Pallet";
            this.colSerialNum.MappingName = "SerialNumber";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.lbSalesId);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(312, 16);
            // 
            // lbSalesId
            // 
            this.lbSalesId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSalesId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbSalesId.ForeColor = System.Drawing.Color.Lime;
            this.lbSalesId.Location = new System.Drawing.Point(80, 0);
            this.lbSalesId.Name = "lbSalesId";
            this.lbSalesId.Size = new System.Drawing.Size(232, 16);
            this.lbSalesId.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.Text = "Sales Line:";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.Text = "Scan:";
            // 
            // tbGetScanPallet
            // 
            this.tbGetScanPallet.BackColor = System.Drawing.Color.Black;
            this.tbGetScanPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbGetScanPallet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbGetScanPallet.ForeColor = System.Drawing.Color.White;
            this.tbGetScanPallet.Location = new System.Drawing.Point(0, 0);
            this.tbGetScanPallet.Name = "tbGetScanPallet";
            this.tbGetScanPallet.Size = new System.Drawing.Size(224, 23);
            this.tbGetScanPallet.TabIndex = 11;
            this.tbGetScanPallet.TextChanged += new System.EventHandler(this.tbGetScanPallet_TextChanged);
            this.tbGetScanPallet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGetScanPallet_KeyPress);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 294);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(315, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(3, 294);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(318, 1);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(312, 2);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(312, 1);
            // 
            // lbUserDevice
            // 
            this.lbUserDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUserDevice.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbUserDevice.ForeColor = System.Drawing.Color.White;
            this.lbUserDevice.Location = new System.Drawing.Point(40, 0);
            this.lbUserDevice.Name = "lbUserDevice";
            this.lbUserDevice.Size = new System.Drawing.Size(272, 16);
            this.lbUserDevice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // listPallets
            // 
            this.listPallets.BackColor = System.Drawing.Color.Black;
            this.listPallets.Columns.Add(this.colSerial);
            this.listPallets.Columns.Add(this.colGrade);
            this.listPallets.Columns.Add(this.colQtySqm);
            this.listPallets.Columns.Add(this.colSize);
            this.listPallets.Columns.Add(this.colColor);
            this.listPallets.Columns.Add(this.colIsHalfPallet);
            this.listPallets.Columns.Add(this.colRemarks);
            this.listPallets.Columns.Add(this.colDate);
            this.listPallets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPallets.ForeColor = System.Drawing.Color.Lime;
            this.listPallets.FullRowSelect = true;
            this.listPallets.Location = new System.Drawing.Point(3, 131);
            this.listPallets.Name = "listPallets";
            this.listPallets.Size = new System.Drawing.Size(312, 134);
            this.listPallets.SmallImageList = this.imageListSmall;
            this.listPallets.TabIndex = 20;
            this.listPallets.View = System.Windows.Forms.View.Details;
            this.listPallets.ItemActivate += new System.EventHandler(this.listPallets_ItemActivate);
            // 
            // colSerial
            // 
            this.colSerial.Text = "Serial#";
            this.colSerial.Width = 68;
            // 
            // colGrade
            // 
            this.colGrade.Text = "Gr";
            this.colGrade.Width = 32;
            // 
            // colQtySqm
            // 
            this.colQtySqm.Text = "Qty";
            this.colQtySqm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colQtySqm.Width = 50;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.Width = 82;
            // 
            // colColor
            // 
            this.colColor.Text = "Color";
            this.colColor.Width = 54;
            // 
            // colIsHalfPallet
            // 
            this.colIsHalfPallet.Text = "Half Pallet";
            this.colIsHalfPallet.Width = 84;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 250;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 5;
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageSize = new System.Drawing.Size(18, 18);
            this.imageListSmall.Images.Clear();
            this.imageListSmall.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageListSmall.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.imageListSmall.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            this.imageListSmall.Images.Add(((System.Drawing.Image)(resources.GetObject("resource3"))));
            // 
            // panelFindPallet
            // 
            this.panelFindPallet.BackColor = System.Drawing.Color.Black;
            this.panelFindPallet.Controls.Add(this.tbGetScanPallet);
            this.panelFindPallet.Controls.Add(this.label9);
            this.panelFindPallet.Controls.Add(this.btnFind);
            this.panelFindPallet.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFindPallet.Location = new System.Drawing.Point(3, 85);
            this.panelFindPallet.Name = "panelFindPallet";
            this.panelFindPallet.Size = new System.Drawing.Size(312, 23);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(224, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(4, 23);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.DimGray;
            this.btnFind.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFind.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Location = new System.Drawing.Point(228, 0);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(84, 23);
            this.btnFind.TabIndex = 12;
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Black;
            this.panelBottom.Controls.Add(this.lbNumOfScannedPallets);
            this.panelBottom.Controls.Add(this.btnCheckAvailable);
            this.panelBottom.Controls.Add(this.btnReserveAll);
            this.panelBottom.Controls.Add(this.label11);
            this.panelBottom.Controls.Add(this.label10);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(3, 265);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(312, 30);
            // 
            // lbNumOfScannedPallets
            // 
            this.lbNumOfScannedPallets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNumOfScannedPallets.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbNumOfScannedPallets.ForeColor = System.Drawing.Color.Orange;
            this.lbNumOfScannedPallets.Location = new System.Drawing.Point(66, 1);
            this.lbNumOfScannedPallets.Name = "lbNumOfScannedPallets";
            this.lbNumOfScannedPallets.Size = new System.Drawing.Size(162, 28);
            this.lbNumOfScannedPallets.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCheckAvailable
            // 
            this.btnCheckAvailable.BackColor = System.Drawing.Color.DarkGreen;
            this.btnCheckAvailable.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCheckAvailable.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheckAvailable.ForeColor = System.Drawing.Color.White;
            this.btnCheckAvailable.Location = new System.Drawing.Point(0, 1);
            this.btnCheckAvailable.Name = "btnCheckAvailable";
            this.btnCheckAvailable.Size = new System.Drawing.Size(66, 28);
            this.btnCheckAvailable.TabIndex = 4;
            this.btnCheckAvailable.Text = "Check";
            this.btnCheckAvailable.Visible = false;
            this.btnCheckAvailable.Click += new System.EventHandler(this.btnCheckAvailable_Click);
            // 
            // btnReserveAll
            // 
            this.btnReserveAll.BackColor = System.Drawing.Color.Orange;
            this.btnReserveAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReserveAll.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnReserveAll.ForeColor = System.Drawing.Color.Black;
            this.btnReserveAll.Location = new System.Drawing.Point(228, 1);
            this.btnReserveAll.Name = "btnReserveAll";
            this.btnReserveAll.Size = new System.Drawing.Size(84, 28);
            this.btnReserveAll.TabIndex = 1;
            this.btnReserveAll.Text = "Reserve";
            this.btnReserveAll.Click += new System.EventHandler(this.btnReserveAll_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Location = new System.Drawing.Point(0, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(312, 1);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(312, 1);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItemFile);
            // 
            // menuItemFile
            // 
            this.menuItemFile.MenuItems.Add(this.menuItemGetLatest);
            this.menuItemFile.MenuItems.Add(this.menuItemShowReserved);
            this.menuItemFile.MenuItems.Add(this.menuItem3);
            this.menuItemFile.MenuItems.Add(this.menuItemClose);
            this.menuItemFile.MenuItems.Add(this.menuItem1);
            this.menuItemFile.Text = "File";
            // 
            // menuItemGetLatest
            // 
            this.menuItemGetLatest.Text = "Get Latest Reserved";
            this.menuItemGetLatest.Click += new System.EventHandler(this.menuItemGetLatest_Click);
            // 
            // menuItemShowReserved
            // 
            this.menuItemShowReserved.Text = "Show Reserved";
            this.menuItemShowReserved.Click += new System.EventHandler(this.menuItemShowReserved_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "-";
            // 
            // menuItemClose
            // 
            this.menuItemClose.Text = "Close Form";
            this.menuItemClose.Click += new System.EventHandler(this.menuItemClose_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Exit";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lbIsHalfPallet);
            this.panel1.Controls.Add(this.btnDeleteLine);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 20);
            // 
            // lbIsHalfPallet
            // 
            this.lbIsHalfPallet.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbIsHalfPallet.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lbIsHalfPallet.ForeColor = System.Drawing.Color.Orange;
            this.lbIsHalfPallet.Location = new System.Drawing.Point(0, 0);
            this.lbIsHalfPallet.Name = "lbIsHalfPallet";
            this.lbIsHalfPallet.Size = new System.Drawing.Size(151, 20);
            // 
            // btnDeleteLine
            // 
            this.btnDeleteLine.BackColor = System.Drawing.Color.Red;
            this.btnDeleteLine.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteLine.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteLine.ForeColor = System.Drawing.Color.White;
            this.btnDeleteLine.Location = new System.Drawing.Point(228, 0);
            this.btnDeleteLine.Name = "btnDeleteLine";
            this.btnDeleteLine.Size = new System.Drawing.Size(84, 20);
            this.btnDeleteLine.TabIndex = 23;
            this.btnDeleteLine.Text = "Remove";
            this.btnDeleteLine.Click += new System.EventHandler(this.btnDeleteLine_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Location = new System.Drawing.Point(3, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(312, 1);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Location = new System.Drawing.Point(3, 109);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(312, 1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.lbUserDevice);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 16);
            // 
            // ScanPallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.Controls.Add(this.listPallets);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panelFindPallet);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gridSaleLine);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.ForeColor = System.Drawing.Color.White;
            this.Menu = this.mainMenu1;
            this.Name = "ScanPallet";
            this.Text = "Reserve Pallets";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScanPallet_Load);
            this.Activated += new System.EventHandler(this.ScanPallet_Activated);
            this.panel3.ResumeLayout(false);
            this.panelFindPallet.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid gridSaleLine;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn colItemId;
        private System.Windows.Forms.DataGridTextBoxColumn SalesQtyBox;
        private System.Windows.Forms.DataGridTextBoxColumn SalesQtyPallet;
        private System.Windows.Forms.DataGridTextBoxColumn SalesUnit;
        private System.Windows.Forms.DataGridTextBoxColumn SalesQtySQM;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbGetScanPallet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridTextBoxColumn GradeCol;
        private System.Windows.Forms.DataGridTextBoxColumn ColorCol;
        private System.Windows.Forms.DataGridTextBoxColumn SizeCol;
        private System.Windows.Forms.DataGridTextBoxColumn SiteCol;
        private System.Windows.Forms.DataGridTextBoxColumn Warehouse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbUserDevice;
        private System.Windows.Forms.ListView listPallets;
        private System.Windows.Forms.ColumnHeader colSerial;
        private System.Windows.Forms.ColumnHeader colGrade;
        private System.Windows.Forms.ColumnHeader colQtySqm;
        private System.Windows.Forms.Panel panelFindPallet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnReserveAll;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ImageList imageListSmall;
        public System.Windows.Forms.DataGridTextBoxColumn colQtySQMRemain;
        public System.Windows.Forms.DataGridTextBoxColumn colQtySQMReserved;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemClose;
        private System.Windows.Forms.DataGridTextBoxColumn colItemName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteLine;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MenuItem menuItemShowReserved;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItemGetLatest;
        private System.Windows.Forms.Label lbSalesId;
        private System.Windows.Forms.Label lbNumOfScannedPallets;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colColor;
        private System.Windows.Forms.ColumnHeader colIsHalfPallet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbIsHalfPallet;
        private System.Windows.Forms.Button btnCheckAvailable;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.DataGridTextBoxColumn colExclusiveHalfPallet;
        private System.Windows.Forms.DataGridTextBoxColumn colSerialNum;

    }
}