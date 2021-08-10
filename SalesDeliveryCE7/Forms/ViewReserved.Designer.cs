namespace SalesDeliveryCE7
{
    partial class ViewReserved
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbPickingListId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridPallets = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.colPallet = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colGrade = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colIsAvailable = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colIsReserved = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colItem = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colSales = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colDevice = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbSalesId = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbPickingListId);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 43);
            // 
            // tbPickingListId
            // 
            this.tbPickingListId.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbPickingListId.Enabled = false;
            this.tbPickingListId.Location = new System.Drawing.Point(0, 16);
            this.tbPickingListId.Name = "tbPickingListId";
            this.tbPickingListId.Size = new System.Drawing.Size(312, 23);
            this.tbPickingListId.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(312, 16);
            this.label4.Text = "Picking List #";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 3);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 292);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(315, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(3, 292);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(3, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(312, 16);
            this.label5.Text = "Pallets Reserved:";
            // 
            // dataGridPallets
            // 
            this.dataGridPallets.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGridPallets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPallets.Location = new System.Drawing.Point(3, 62);
            this.dataGridPallets.Name = "dataGridPallets";
            this.dataGridPallets.Size = new System.Drawing.Size(312, 200);
            this.dataGridPallets.TabIndex = 5;
            this.dataGridPallets.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colPallet);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colGrade);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colIsAvailable);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colIsReserved);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colItem);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colSales);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colDate);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colQty);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colUser);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colDevice);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colRemarks);
            this.dataGridTableStyle1.MappingName = "PalletInfo";
            // 
            // colPallet
            // 
            this.colPallet.Format = "";
            this.colPallet.FormatInfo = null;
            this.colPallet.HeaderText = "Pallet #";
            this.colPallet.MappingName = "PalletId";
            this.colPallet.Width = 60;
            // 
            // colGrade
            // 
            this.colGrade.Format = "";
            this.colGrade.FormatInfo = null;
            this.colGrade.HeaderText = "Grade";
            this.colGrade.MappingName = "Grade";
            this.colGrade.Width = 40;
            // 
            // colIsAvailable
            // 
            this.colIsAvailable.Format = "";
            this.colIsAvailable.FormatInfo = null;
            this.colIsAvailable.HeaderText = "Available?";
            this.colIsAvailable.MappingName = "IsAvailable";
            this.colIsAvailable.Width = 65;
            // 
            // colIsReserved
            // 
            this.colIsReserved.Format = "";
            this.colIsReserved.FormatInfo = null;
            this.colIsReserved.HeaderText = "Reserved?";
            this.colIsReserved.MappingName = "IsReserved";
            this.colIsReserved.Width = 65;
            // 
            // colItem
            // 
            this.colItem.Format = "";
            this.colItem.FormatInfo = null;
            this.colItem.HeaderText = "Item Name";
            this.colItem.MappingName = "ItemId";
            this.colItem.Width = 110;
            // 
            // colSales
            // 
            this.colSales.Format = "";
            this.colSales.FormatInfo = null;
            this.colSales.HeaderText = "Sales Id";
            this.colSales.MappingName = "SalesId";
            this.colSales.Width = 65;
            // 
            // colDate
            // 
            this.colDate.Format = "dd/MM/yyyy hh:mm tt";
            this.colDate.FormatInfo = null;
            this.colDate.HeaderText = "Scan Date";
            this.colDate.MappingName = "DateScanned";
            this.colDate.Width = 110;
            // 
            // colQty
            // 
            this.colQty.Format = "n2";
            this.colQty.FormatInfo = null;
            this.colQty.HeaderText = "Qty";
            this.colQty.MappingName = "Qty";
            // 
            // colUser
            // 
            this.colUser.Format = "";
            this.colUser.FormatInfo = null;
            this.colUser.HeaderText = "Updated By";
            this.colUser.MappingName = "UpdatedBy";
            this.colUser.Width = 70;
            // 
            // colDevice
            // 
            this.colDevice.Format = "";
            this.colDevice.FormatInfo = null;
            this.colDevice.HeaderText = "Device";
            this.colDevice.MappingName = "Device";
            // 
            // colRemarks
            // 
            this.colRemarks.Format = "";
            this.colRemarks.FormatInfo = null;
            this.colRemarks.HeaderText = "Remarks";
            this.colRemarks.MappingName = "Remarks";
            this.colRemarks.Width = 200;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.lbSalesId);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 262);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 33);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(240, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 33);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbSalesId
            // 
            this.lbSalesId.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbSalesId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbSalesId.ForeColor = System.Drawing.Color.Green;
            this.lbSalesId.Location = new System.Drawing.Point(0, 0);
            this.lbSalesId.Name = "lbSalesId";
            this.lbSalesId.Size = new System.Drawing.Size(101, 33);
            // 
            // ViewReserved
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.Controls.Add(this.dataGridPallets);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "ViewReserved";
            this.Text = "View Reserved Pallets";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ViewReserved_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPickingListId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGrid dataGridPallets;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbSalesId;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn colSales;
        private System.Windows.Forms.DataGridTextBoxColumn colItem;
        private System.Windows.Forms.DataGridTextBoxColumn colPallet;
        private System.Windows.Forms.DataGridTextBoxColumn colDate;
        private System.Windows.Forms.DataGridTextBoxColumn colUser;
        private System.Windows.Forms.DataGridTextBoxColumn colDevice;
        private System.Windows.Forms.DataGridTextBoxColumn colRemarks;
        private System.Windows.Forms.DataGridTextBoxColumn colIsReserved;
        private System.Windows.Forms.DataGridTextBoxColumn colGrade;
        private System.Windows.Forms.DataGridTextBoxColumn colQty;
        public System.Windows.Forms.DataGridTextBoxColumn colIsAvailable;
    }
}