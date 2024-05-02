namespace StoreGUI
{
    partial class Queries
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
            this.btnInventory = new System.Windows.Forms.Button();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.btnExpandedProfitReport = new System.Windows.Forms.Button();
            this.btnProfitReport = new System.Windows.Forms.Button();
            this.btnPickingList = new System.Windows.Forms.Button();
            this.btnFullOrderInfo = new System.Windows.Forms.Button();
            this.btnInvetorySupplier = new System.Windows.Forms.Button();
            this.btnBasicOrderInfo = new System.Windows.Forms.Button();
            this.btnPurchaseGuide = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInventory
            // 
            this.btnInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.Location = new System.Drawing.Point(12, 247);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(166, 55);
            this.btnInventory.TabIndex = 1;
            this.btnInventory.Text = "Generate Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // dgvInventory
            // 
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(12, 33);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.Size = new System.Drawing.Size(754, 208);
            this.dgvInventory.TabIndex = 2;
            // 
            // btnExpandedProfitReport
            // 
            this.btnExpandedProfitReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpandedProfitReport.Location = new System.Drawing.Point(404, 297);
            this.btnExpandedProfitReport.Name = "btnExpandedProfitReport";
            this.btnExpandedProfitReport.Size = new System.Drawing.Size(166, 55);
            this.btnExpandedProfitReport.TabIndex = 3;
            this.btnExpandedProfitReport.Text = "Generate Expanded Profitabilty Report";
            this.btnExpandedProfitReport.UseVisualStyleBackColor = true;
            this.btnExpandedProfitReport.Click += new System.EventHandler(this.btnExpandedProfitReport_Click);
            // 
            // btnProfitReport
            // 
            this.btnProfitReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfitReport.Location = new System.Drawing.Point(208, 297);
            this.btnProfitReport.Name = "btnProfitReport";
            this.btnProfitReport.Size = new System.Drawing.Size(166, 55);
            this.btnProfitReport.TabIndex = 4;
            this.btnProfitReport.Text = "Generate Profitability Report";
            this.btnProfitReport.UseVisualStyleBackColor = true;
            this.btnProfitReport.Click += new System.EventHandler(this.btnProfitReport_Click);
            // 
            // btnPickingList
            // 
            this.btnPickingList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickingList.Location = new System.Drawing.Point(600, 297);
            this.btnPickingList.Name = "btnPickingList";
            this.btnPickingList.Size = new System.Drawing.Size(166, 55);
            this.btnPickingList.TabIndex = 5;
            this.btnPickingList.Text = "Generate Picking List";
            this.btnPickingList.UseVisualStyleBackColor = true;
            this.btnPickingList.Click += new System.EventHandler(this.btnPickingList_Click);
            // 
            // btnFullOrderInfo
            // 
            this.btnFullOrderInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFullOrderInfo.Location = new System.Drawing.Point(600, 247);
            this.btnFullOrderInfo.Name = "btnFullOrderInfo";
            this.btnFullOrderInfo.Size = new System.Drawing.Size(166, 55);
            this.btnFullOrderInfo.TabIndex = 6;
            this.btnFullOrderInfo.Text = "Generate Full Order Information";
            this.btnFullOrderInfo.UseVisualStyleBackColor = true;
            this.btnFullOrderInfo.Click += new System.EventHandler(this.btnFullOrderInfo_Click);
            // 
            // btnInvetorySupplier
            // 
            this.btnInvetorySupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvetorySupplier.Location = new System.Drawing.Point(208, 247);
            this.btnInvetorySupplier.Name = "btnInvetorySupplier";
            this.btnInvetorySupplier.Size = new System.Drawing.Size(166, 55);
            this.btnInvetorySupplier.TabIndex = 7;
            this.btnInvetorySupplier.Text = "Generate Inventory with Supplier";
            this.btnInvetorySupplier.UseVisualStyleBackColor = true;
            this.btnInvetorySupplier.Click += new System.EventHandler(this.btnInvetorySupplier_Click);
            // 
            // btnBasicOrderInfo
            // 
            this.btnBasicOrderInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBasicOrderInfo.Location = new System.Drawing.Point(404, 247);
            this.btnBasicOrderInfo.Name = "btnBasicOrderInfo";
            this.btnBasicOrderInfo.Size = new System.Drawing.Size(166, 55);
            this.btnBasicOrderInfo.TabIndex = 8;
            this.btnBasicOrderInfo.Text = "Generate Basic Order Information";
            this.btnBasicOrderInfo.UseVisualStyleBackColor = true;
            this.btnBasicOrderInfo.Click += new System.EventHandler(this.btnBasicOrderInfo_Click);
            // 
            // btnPurchaseGuide
            // 
            this.btnPurchaseGuide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchaseGuide.Location = new System.Drawing.Point(12, 300);
            this.btnPurchaseGuide.Name = "btnPurchaseGuide";
            this.btnPurchaseGuide.Size = new System.Drawing.Size(166, 55);
            this.btnPurchaseGuide.TabIndex = 9;
            this.btnPurchaseGuide.Text = "Generate Purchasing Guide";
            this.btnPurchaseGuide.UseVisualStyleBackColor = true;
            this.btnPurchaseGuide.Click += new System.EventHandler(this.btnPurchaseGuide_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 375);
            this.Controls.Add(this.btnPurchaseGuide);
            this.Controls.Add(this.btnBasicOrderInfo);
            this.Controls.Add(this.btnInvetorySupplier);
            this.Controls.Add(this.btnFullOrderInfo);
            this.Controls.Add(this.btnPickingList);
            this.Controls.Add(this.btnProfitReport);
            this.Controls.Add(this.btnExpandedProfitReport);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.btnInventory);
            this.Name = "Form1";
            this.Text = "Data Reports";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Button btnExpandedProfitReport;
        private System.Windows.Forms.Button btnProfitReport;
        private System.Windows.Forms.Button btnPickingList;
        private System.Windows.Forms.Button btnFullOrderInfo;
        private System.Windows.Forms.Button btnInvetorySupplier;
        private System.Windows.Forms.Button btnBasicOrderInfo;
        private System.Windows.Forms.Button btnPurchaseGuide;
    }
}

