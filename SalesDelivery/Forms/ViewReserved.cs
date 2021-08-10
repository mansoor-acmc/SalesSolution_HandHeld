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
    public partial class ViewReserved : Form
    {
        public ViewReserved()
        {
            InitializeComponent();
        }

        public string PickingId { get; set; }
        public string ItemId { get; set; }
        public string Grade { get; set; }
        public long LineRecId { get; set; }

        void LoadData()
        {
            tbPickingListId.Text = PickingId;
            DataTable dt = new DBClass().LoadPickedPallets(PickingId, ItemId, Grade, LineRecId);
            dataGridPallets.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                lbSalesId.Text = dt.Rows[0]["SalesId"].ToString();
            }
        }

        private void ViewReserved_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}