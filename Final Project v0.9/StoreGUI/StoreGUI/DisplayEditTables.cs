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
                        saveTable("saveItems.sql");
                        break;

                    case "OrderDetail":
                        saveTable("saveOrderDetails.sql");
                        break;

                    case "Orders":
                        saveTable("saveOrders.sql");
                        break;

                    case "Supplier":
                        saveTable("saveSupplier.sql");
                        break;

                    default:
                        Console.WriteLine("No table loaded" + Environment.NewLine + "how did you get here?");
                        break;
                }

                // Save Table
                MessageBox.Show("Table has been saved", "Table Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            switch (currentTable)
            {
                case "Inventory":
                    fillTable("loadInventory.sql");
                    break;

                case "Items":
                    fillTable("loadItems.sql");
                    break;

                case "OrderDetail":
                    fillTable("loadOrderDetail.sql");
                    break;

                case "Orders":
                    fillTable("loadOrders.sql");
                    break;

                case "Supplier":
                    fillTable("loadSupplier.sql");
                    break;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            // Open Search Window and send currentTable to set list
            frmSearch frmSearch = new frmSearch(currentTable);

            frmSearch.ShowDialog();

            string[] searchValues = { frmSearch.strSearchColumn, frmSearch.strSearchValue };

            // A value was searched for
            if (searchValues.Length > 1)
            {
                SearchDataGridView(searchValues[0], searchValues[1]);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = null;

            // Check if any rows are selected
            if (dgvEditTables.SelectedRows.Count > 0)
            {
                // If one or more entire rows are selected, get the first selected row
                selectedRow = dgvEditTables.SelectedRows[0];
            }
            // Check if any cells are selected
            else if (dgvEditTables.SelectedCells.Count > 0)
            {
                // If only cells are selected, get the row of the first selected cell
                selectedRow = dgvEditTables.Rows[dgvEditTables.SelectedCells[0].RowIndex];
            }

            try
            {
                // Create SQLConnection Object
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // connect to database
                    connection.Open();

                    // Prepare File path
                    string sqlDeletePath = sqlFolderPath;

                    // Prepare Command
                    string sqlDelete;

                    switch (currentTable)
                    {
                        case "Inventory":
                            // delete tuple
                            sqlDeletePath += "deleteFromInventory.sql";

                            sqlDelete = File.ReadAllText(sqlDeletePath);

                            // Prepare SQL command
                            using (SqlCommand command = new SqlCommand(sqlDelete, connection))
                            {
                                // Set parameter values based on the DataGridView's cell values
                                command.Parameters.AddWithValue("@Param1", selectedRow.Cells[0].Value);

                                // Execute command
                                command.ExecuteNonQuery();
                            }

                            // Refresh table
                            fillTable("loadInventory.sql");
                            break;

                        case "Items":
                            // delete tuple
                            sqlDeletePath = sqlFolderPath + "deleteFromItems.sql";

                            sqlDelete = File.ReadAllText(sqlDeletePath);

                            // Prepare SQL command
                            using (SqlCommand command = new SqlCommand(sqlDelete, connection))
                            {
                                // Set parameter values based on the DataGridView's cell values
                                command.Parameters.AddWithValue("@Param1", selectedRow.Cells[2].Value);

                                // Execute command
                                command.ExecuteNonQuery();
                            }

                            // Refresh table
                            fillTable("loadItems.sql");
                            break;

                        case "OrderDetail":
                            // delete tuple
                            sqlDeletePath = sqlFolderPath + "deleteFromOrderDetail.sql";

                            sqlDelete = File.ReadAllText(sqlDeletePath);

                            // Prepare SQL command
                            using (SqlCommand command = new SqlCommand(sqlDelete, connection))
                            {
                                // Set parameter values based on the DataGridView's cell values
                                command.Parameters.AddWithValue("@Param1", selectedRow.Cells[0].Value);

                                // Execute command
                                command.ExecuteNonQuery();
                            }

                            // Refresh table
                            fillTable("loadOrderDetail.sql");
                            break;

                        case "Orders":
                            // delete tuple
                            sqlDeletePath = sqlFolderPath + "deleteFromOrders.sql";

                            sqlDelete = File.ReadAllText(sqlDeletePath);

                            // Prepare SQL command
                            using (SqlCommand command = new SqlCommand(sqlDelete, connection))
                            {
                                // Set parameter values based on the DataGridView's cell values
                                command.Parameters.AddWithValue("@Param1", selectedRow.Cells[0].Value);

                                // Execute command
                                command.ExecuteNonQuery();
                            }

                            // Refresh table
                            fillTable("loadOrders.sql");
                            break;

                        case "Supplier":
                            // delete tuple
                            sqlDeletePath = sqlFolderPath + "deleteFromSupplier.sql";

                            sqlDelete = File.ReadAllText(sqlDeletePath);

                            // Prepare SQL command
                            using (SqlCommand command = new SqlCommand(sqlDelete, connection))
                            {
                                // Set parameter values based on the DataGridView's cell values
                                command.Parameters.AddWithValue("@Param1", selectedRow.Cells[1].Value);

                                // Execute command
                                command.ExecuteNonQuery();
                            }

                            // Refresh table
                            fillTable("loadSupplier.sql");
                            break;
                    }

                    // Close connection
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
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
            string sqlUpdatePath;
            string sqlUpdate;

            try
            {
                // Initialize File Path
                string sqlFilePath = sqlFolderPath;

                // Create SQLConnection Object
                using (SqlConnection connection = new SqlConnection(connectionString))
                {                  
                    // Open Connection
                    connection.Open();

                    // Iterate through the rows of the DataGridView
                    foreach (DataGridViewRow row in dgvEditTables.Rows)
                    {
                        // Check if the row is not a new row and if changes have been made to it's cells
                        if (!row.IsNewRow  && RowDirtyCells(row))
                        {
                            if (row.Cells[0].Tag != null)
                            {                                
                                // Save Changes to existing tuples
                                switch (currentTable)
                                {
                                    case "Inventory":
                                        sqlUpdatePath = sqlFilePath + "modifyInventory.sql";

                                        sqlUpdate = File.ReadAllText(sqlUpdatePath);

                                        using (SqlCommand command = new SqlCommand(sqlUpdate, connection))
                                        {                                           
                                            // Set parameter values based on the DataGridView's cell values
                                            command.Parameters.AddWithValue("@Param1", row.Cells["ItemCode"].Value);
                                            command.Parameters.AddWithValue("@Param2", row.Cells["ItemName"].Value);
                                            command.Parameters.AddWithValue("@Param3", row.Cells["SalePrice"].Value);
                                            command.Parameters.AddWithValue("@Param4", row.Cells["Category"].Value);
                                            command.Parameters.AddWithValue("@Param5", row.Cells["Quantity"].Value);

                                            // Execute the SQL command
                                            command.ExecuteNonQuery();
                                        }
                                        break;

                                    case "Items":
                                        // Select UPC - Primary Key
                                        sqlUpdatePath = sqlFilePath + "modifyItems.sql";

                                        sqlUpdate = File.ReadAllText(sqlUpdatePath);

                                        using (SqlCommand command = new SqlCommand(sqlUpdate, connection))
                                        {
                                            // Set parameter values based on the DataGridView's cell values
                                            command.Parameters.AddWithValue("@Param1", row.Cells["ItemCode"].Value);
                                            command.Parameters.AddWithValue("@Param2", row.Cells["UnitCost"].Value);
                                            command.Parameters.AddWithValue("@Param3", row.Cells["UPC"].Value);
                                            command.Parameters.AddWithValue("@Param4", row.Cells["SKU"].Value);
                                            command.Parameters.AddWithValue("@Param5", row.Cells["Supplier"].Value);
                                            command.Parameters.AddWithValue("@Param6", row.Cells["Brand"].Value);

                                            // Execute the SQL command
                                            command.ExecuteNonQuery();
                                        }
                                        break;

                                    case "OrderDetail":
                                        sqlUpdatePath = sqlFilePath + "modifyOrderDetails.sql";

                                        sqlUpdate = File.ReadAllText(sqlUpdatePath);

                                        using (SqlCommand command = new SqlCommand(sqlUpdate, connection))
                                        {
                                            // Set parameter values based on the DataGridView's cell values
                                            command.Parameters.AddWithValue("@Param1", row.Cells["DetailId"].Value);
                                            command.Parameters.AddWithValue("@Param2", row.Cells["OrderNo"].Value);
                                            command.Parameters.AddWithValue("@Param3", row.Cells["ItemId"].Value);
                                            command.Parameters.AddWithValue("@Param4", row.Cells["Quantity"].Value);
                                            command.Parameters.AddWithValue("@Param5", row.Cells["UnitPrice"].Value);
                                            command.Parameters.AddWithValue("@Param6", row.Cells["Total"].Value);

                                            // Execute the SQL command
                                            command.ExecuteNonQuery();
                                        }
                                        break;

                                    case "Orders":
                                        sqlUpdatePath = sqlFilePath + "modifyOrders.sql";

                                        sqlUpdate = File.ReadAllText(sqlUpdatePath);

                                        using (SqlCommand command = new SqlCommand(sqlUpdate, connection))
                                        {
                                            // Set parameter values based on the DataGridView's cell values
                                            command.Parameters.AddWithValue("@Param1", row.Cells["OrderNo"].Value);
                                            command.Parameters.AddWithValue("@Param2", row.Cells["ItemCode"].Value);
                                            command.Parameters.AddWithValue("@Param3", row.Cells["ItemName"].Value);
                                            command.Parameters.AddWithValue("@Param4", row.Cells["Customer"].Value);
                                            command.Parameters.AddWithValue("@Param5", row.Cells["TotalAmount"].Value);
                                            command.Parameters.AddWithValue("@Param6", row.Cells["Status"].Value);

                                            // Execute the SQL command
                                            command.ExecuteNonQuery();
                                        }
                                        break;

                                    case "Supplier":
                                        sqlUpdatePath = sqlFilePath + "modifySupplier.sql";

                                        sqlUpdate = File.ReadAllText(sqlUpdatePath);

                                        using (SqlCommand command = new SqlCommand(sqlUpdate, connection))
                                        {
                                            // Set parameter values based on the DataGridView's cell values
                                            command.Parameters.AddWithValue("@Param1", row.Cells["SupplierName"].Value);
                                            command.Parameters.AddWithValue("@Param2", row.Cells["ID"].Value);
                                            command.Parameters.AddWithValue("@Param3", row.Cells["City"].Value);
                                            command.Parameters.AddWithValue("@Param4", row.Cells["StreetName"].Value);
                                            command.Parameters.AddWithValue("@Param5", row.Cells["StreetNumber"].Value);
                                            command.Parameters.AddWithValue("@Param6", row.Cells["ZipCode"].Value);
                                            command.Parameters.AddWithValue("@Param7", row.Cells["State"].Value);

                                            // Execute the SQL command
                                            command.ExecuteNonQuery();
                                        }
                                        break;
                                }
                            }

                            else
                            {
                                // Add new tuples
                                string sqlInsertPath = sqlFilePath + sqlQueryFile;

                                string sqlInsert = File.ReadAllText(sqlInsertPath);

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
                                            // Set parameter values based on the DataGridView's cell values
                                            command.Parameters.AddWithValue("@Param1", row.Cells["ItemCode"].Value);
                                            command.Parameters.AddWithValue("@Param2", row.Cells["UnitCost"].Value);
                                            command.Parameters.AddWithValue("@Param3", row.Cells["UPC"].Value);
                                            command.Parameters.AddWithValue("@Param4", row.Cells["SKU"].Value);
                                            command.Parameters.AddWithValue("@Param5", row.Cells["Supplier"].Value);
                                            command.Parameters.AddWithValue("@Param6", row.Cells["Brand"].Value);
                                            break;

                                        case "saveOrderDetails.sql":
                                            // Set parameter values based on the DataGridView's cell values
                                            command.Parameters.AddWithValue("@Param1", row.Cells["DetailId"].Value);
                                            command.Parameters.AddWithValue("@Param2", row.Cells["OrderNo"].Value);
                                            command.Parameters.AddWithValue("@Param3", row.Cells["ItemId"].Value);
                                            command.Parameters.AddWithValue("@Param4", row.Cells["Quantity"].Value);
                                            command.Parameters.AddWithValue("@Param5", row.Cells["UnitPrice"].Value);
                                            command.Parameters.AddWithValue("@Param6", row.Cells["Total"].Value);
                                            break;

                                        case "saveOrders.sql":
                                            // Set parameter values based on the DataGridView's cell values
                                            command.Parameters.AddWithValue("@Param1", row.Cells["OrderNo"].Value);
                                            command.Parameters.AddWithValue("@Param2", row.Cells["ItemCode"].Value);
                                            command.Parameters.AddWithValue("@Param3", row.Cells["ItemName"].Value);
                                            command.Parameters.AddWithValue("@Param4", row.Cells["Customer"].Value);
                                            command.Parameters.AddWithValue("@Param5", row.Cells["TotalAmount"].Value);
                                            command.Parameters.AddWithValue("@Param6", row.Cells["Status"].Value);
                                            break;

                                        case "saveSupplier.sql":
                                            command.Parameters.AddWithValue("@Param1", row.Cells["SupplierName"].Value);
                                            command.Parameters.AddWithValue("@Param2", row.Cells["ID"].Value);
                                            command.Parameters.AddWithValue("@Param3", row.Cells["City"].Value);
                                            command.Parameters.AddWithValue("@Param4", row.Cells["StreetName"].Value);
                                            command.Parameters.AddWithValue("@Param5", row.Cells["StreetNumber"].Value);
                                            command.Parameters.AddWithValue("@Param6", row.Cells["ZipCode"].Value);
                                            command.Parameters.AddWithValue("@Param7", row.Cells["State"].Value);
                                            break;
                                    }
                              
                                    // Execute the SQL command
                                    command.ExecuteNonQuery();
                                }
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

        private void dgvEditTables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchDataGridView(string columnName, string searchValue)
        {
            // User cancelled search, do nothing
            if (string.IsNullOrEmpty(searchValue))
            {
                return;
            }

            // Iterate through each row in the DataGridView
            foreach (DataGridViewRow row in dgvEditTables.Rows)
            {
                // Check if the row is not a new row and contains cells
                if (!row.IsNewRow && row.Cells[columnName].Value != null)
                {
                    // Get the value in the specified column for the current row
                    string cellValue = row.Cells[columnName].Value.ToString();

                    // Check if the cell value matches the search value
                    if (cellValue.Equals(searchValue, StringComparison.OrdinalIgnoreCase)) // Use StringComparison.OrdinalIgnoreCase for case-insensitive comparison
                    {
                        // Select the row and scroll to it
                        row.Selected = true;
                        dgvEditTables.FirstDisplayedScrollingRowIndex = row.Index;

                        // Make the found row the current cell to ensure it's visible
                        dgvEditTables.CurrentCell = row.Cells[columnName];

                        return; // Exit the method after the first match is found
                    }
                }
            }

            // If no match is found, display a message
            MessageBox.Show($"No match found for '{searchValue}' in column '{columnName}'.");
        }
    }
}
