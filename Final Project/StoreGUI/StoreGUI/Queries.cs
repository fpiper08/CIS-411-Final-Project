using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreGUI
{
    public partial class Queries : Form
    {
        // Define connection string
        string connectionString = "Data Source=EUNICE;Initial Catalog=Store;Integrated Security=True"; // Change for each database

        string sqlFolderPath = "DatabaseQueries\\";

        public Queries()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            string sqlQueryFile = "currentInventoryQuery.sql";

            fillTable(sqlQueryFile);
        }

        private void btnInvetorySupplier_Click(object sender, EventArgs e)
        {
            string sqlQueryFile = "currentInventoryWSupplierQuery.sql";

            fillTable(sqlQueryFile);
        }

        private void btnBasicOrderInfo_Click(object sender, EventArgs e)
        {
            string sqlQueryFile = "customerOrderBasicQuery.sql";

            fillTable(sqlQueryFile);
        }

        private void btnFullOrderInfo_Click(object sender, EventArgs e)
        {
            string sqlQueryFile = "maxOrderDetailsQuery.sql";

            fillTable(sqlQueryFile);
        }

        private void btnPurchaseGuide_Click(object sender, EventArgs e)
        {
            string sqlQueryFile = "purchasingGuideQuery.sql";

            fillTable(sqlQueryFile);
        }

        private void btnProfitReport_Click(object sender, EventArgs e)
        {
            string sqlQueryFile = "customerOrderBasicQuery.sql";

            fillTable(sqlQueryFile);  
        }

        private void btnExpandedProfitReport_Click(object sender, EventArgs e)
        {
            string sqlQueryFile = "profitabiltyWInventoryQuery.sql";

            fillTable(sqlQueryFile);
        }

        private void btnPickingList_Click(object sender, EventArgs e)
        {
            string sqlQueryFile = "checkOrderAvailableQuery.sql";

            fillTable(sqlQueryFile);
        }

        private void fillTable(string sqlQueryFile)
        {
            try
            {
                // Create SQLConnection Object
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlFilePath = sqlFolderPath + sqlQueryFile;

                    string sqlQuery = File.ReadAllText(sqlFilePath);

                    // Open Connection
                    connection.Open();

                    // Prepare SQL Query
                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    // Create a DataTable to hold the data
                    DataTable dataTable = new DataTable();

                    // Execute the query and fill the DataTable with the results
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Bind the DataTable to the DataGridView
                    dgvInventory.DataSource = dataTable;

                    // Close Connection
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
            }
        }

    }
}
