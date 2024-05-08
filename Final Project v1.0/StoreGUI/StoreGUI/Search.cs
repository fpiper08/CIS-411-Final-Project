using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreGUI
{
    public partial class frmSearch : Form
    {
        // List of columns for comboBox
        List<string> lstColumns = new List<string>();

        // Search Values
        public string strSearchColumn { get; private set; }
        public string strSearchValue { get; private set; }
        public frmSearch(string strCurrentTable)
        {
            InitializeComponent();

            // Determine Current table and set lstColumns accordingly
            switch (strCurrentTable)
            {
                case "Inventory":
                    string[] strInventoryColumns = { "ItemCode", "ItemName", "SalePrice", "Category", "Quantity" };

                    foreach (string strColumn in strInventoryColumns)
                    {
                        lstColumns.Add(strColumn);
                    }
                    break;

                case "Items":
                    string[] strItemsColumns = { "ItemCode", "UnitCost", "UPC", "SKU", "Supplier", "Brand" };

                    foreach (string strColumn in strItemsColumns)
                    {
                        lstColumns.Add(strColumn);
                    }
                    break;

                case "Orders":
                    string[] strOrdersColumns = { "OrderNo", "ItemCode", "ItemName", "Customer", "TotalAmount", "Status" };

                    foreach (string strColumn in strOrdersColumns)
                    {
                        lstColumns.Add(strColumn);
                    }
                    break;

                case "OrderDetail":
                    string[] strOrderDetailColumns = { "DetailId", "OrderNo", "ItemId", "Quantity", "UnitPrice", "Total" };

                    foreach (string strColumn in strOrderDetailColumns)
                    {
                        lstColumns.Add(strColumn);
                    }
                    break;

                case "Supplier":
                    string[] strSupplierColumns = { "SupplierName", "ID", "City", "StreetName", "StreetNumber", "ZipCode", "State" };

                    foreach (string strColumn in strSupplierColumns)
                    {
                        lstColumns.Add(strColumn);
                    }
                    break;
            }

            // Add List items to combo box items 
            foreach (string strColumn in lstColumns)
            {
                cmbColumn.Items.Add(strColumn);
            }

            cmbColumn.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // No values to search for
            strSearchColumn = cmbColumn.Text;
            strSearchValue = "";

            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Set values to search for
            strSearchColumn = cmbColumn.Text;
            strSearchValue = txtSearch.Text;

            // Close search form
            this.Close();
        }
    }
}
