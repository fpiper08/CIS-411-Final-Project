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
    public partial class DisplayEditTables : Form
    {
        // Define connection string
        string connectionString = "Data Source=DESKTOP-VAHIJ79\\SQLEXPRESS;Initial Catalog=Store;Integrated Security=True"; // Change for each database

        string sqlFolderPath = "DatabaseQueries\\";

        string currentTable;

        public DisplayEditTables()
        {
            InitializeComponent();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            fillTable("loadInventory.sql");

            currentTable = "Inventory";
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            fillTable("loadItems.sql");

            currentTable = "Items";
        }


        private void btnOrderDetails_Click(object sender, EventArgs e)
        {
            fillTable("loadOrderDetail.sql");

            currentTable = "OrderDetail";
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            fillTable("loadOrders.sql");

            currentTable = "Orders";
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {            
            fillTable("loadSupplier.sql");

            currentTable = "Supplier";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!AnyDirtyCells())
            {
                // Nothing to save, alert user.
                MessageBox.Show("The table has not been edited. There is nothing to save.", "No Edits Made", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                // Determine Loaded Table 
                switch (currentTable)
                {
                    case "Inventory":
                        saveTable("saveInventory.sql");
                        break;

                    case "Items":
                        string sqlQueryFile2 = "loadItems.sql";

                        saveTable(sqlQueryFile2);
                        break;

                    case "OrderDetail":
                        string sqlQueryFile3 = "loadOrderDetail.sql";

                        saveTable(sqlQueryFile3);
                        break;

                    case "Orders":
                        string sqlQueryFile4 = "loadOrders.sql";

                        saveTable(sqlQueryFile4);
                        break;

                    case "Supplier":
                        string sqlQueryFile5 = "loadSupplier.sql";

                        saveTable(sqlQueryFile5);
                        break;

                    default:
                        Console.WriteLine("No table loaded" + Environment.NewLine + "how did you get here?");
                        break;
                }

                // Save Table
                MessageBox.Show("Table has been saved", "Table Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private bool AnyDirtyCells()
        {
            // Loads DGV rows in new row object
            foreach (DataGridViewRow row in dgvEditTables.Rows)
            {
                // Loads the cells of that row object into a new cell object
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        continue;
                    }


                    // checks each cell for changes - checking original value against current
                    if (!cell.Value.Equals(cell.Tag))
                    {
                        // cells have been edited
                        return true;
                    }
                }
            }

            // No edits made
            return false;
        }

        private bool RowDirtyCells(DataGridViewRow row)
        {
            // Loads the cells of that row object into a new cell object
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value == null)
                {
                    continue;
                }


                // checks each cell for changes - checking original value against current
                if (!cell.Value.Equals(cell.Tag))
                {
                    // cells have been edited
                    return true;
                }
            }

            // No Edits made
            return false;
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
                    dgvEditTables.DataSource = dataTable;

                    // Close Connection
                    connection.Close();

                    // Store Original Values to Check for Edits
                    foreach (DataGridViewRow row in dgvEditTables.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            // Store original value in cell Tag
                            cell.Tag = cell.Value;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
            }
        }

        private void saveTable(string sqlQueryFile)
        {
            try
            {
                // Create SQLConnection Object
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlFilePath = sqlFolderPath + sqlQueryFile;

                    string sqlInsert = File.ReadAllText(sqlFilePath);

                    // Open Connection
                    connection.Open();

                    // Iterate through the rows of the DataGridView
                    foreach (DataGridViewRow row in dgvEditTables.Rows)
                    {
                        // Check if the row is not a new row and if changes have been made to it's cells
                        if (!row.IsNewRow  && RowDirtyCells(row))
                        {
                            // Save Changes to existing tuples
                            switch (currentTable)
                            {
                                case "Inventory":
                                    // Select ItemCode - Primary Key
                                    //MessageBox.Show("w" + row.Cells[0].Value.ToString() + "w");
                                    if(row.Cells[0].Tag != null)
                                    {
                                        MessageBox.Show("w" + row.Cells[0].Value.ToString() + "w");
                                    }
                                    break;

                                case "Items":
                                    // Select UPC - Primary Key
                                    MessageBox.Show(row.Cells[2].Value.ToString());
                                    break;
                            }

                            // Add new tuples
                            // Prepare SQL command
                            using (SqlCommand command = new SqlCommand(sqlInsert, connection))
                            {
                                // Currently only adds new tuples DOES NOT EDIT EXISTING TUPLES
                                switch (sqlQueryFile)
                                {
                                    case "saveInventory.sql":
                                        // Set parameter values based on the DataGridView's cell values
                                        command.Parameters.AddWithValue("@Param1", row.Cells["ItemCode"].Value);
                                        command.Parameters.AddWithValue("@Param2", row.Cells["ItemName"].Value);
                                        command.Parameters.AddWithValue("@Param3", row.Cells["SalePrice"].Value);
                                        command.Parameters.AddWithValue("@Param4", row.Cells["Category"].Value);
                                        command.Parameters.AddWithValue("@Param5", row.Cells["Quantity"].Value);
                                        break;

                                    case "saveItems.sql":
                                        break;
                                }
                              

                                // Execute the SQL command
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    // Close Connection
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get the selected row
            DataGridViewRow selectedRow = dgvEditTables.SelectedCells[0].OwningRow;

            switch (currentTable)
            {               
                case "Inventory":
                    // Select ItemCode - Primary Key
                    MessageBox.Show("w" + selectedRow.Cells[0].Value.ToString() + "w");
                    break;

                case "Items":
                    // Select UPC - Primary Key
                    MessageBox.Show(selectedRow.Cells[2].Value.ToString());
                    break;
            }
        }
    }
}
