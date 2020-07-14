namespace Shop.Dialogs
{
    partial class InvoiceDialog
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
            this.Add = new System.Windows.Forms.Button();
            this.ProductCodeLabel = new System.Windows.Forms.Label();
            this.ProductCode = new System.Windows.Forms.TextBox();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.ProductQuantity = new System.Windows.Forms.TextBox();
            this.InvoiceItemsList = new System.Windows.Forms.ListView();
            this.CodeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PricePerItemColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemQuantityColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DiscountLabel = new System.Windows.Forms.Label();
            this.Discount = new System.Windows.Forms.TextBox();
            this.CustomerIDLabel = new System.Windows.Forms.Label();
            this.CustomerID = new System.Windows.Forms.TextBox();
            this.Remove = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Location = new System.Drawing.Point(452, 54);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // ProductCodeLabel
            // 
            this.ProductCodeLabel.AutoSize = true;
            this.ProductCodeLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductCodeLabel.Location = new System.Drawing.Point(21, 57);
            this.ProductCodeLabel.Name = "ProductCodeLabel";
            this.ProductCodeLabel.Size = new System.Drawing.Size(86, 14);
            this.ProductCodeLabel.TabIndex = 1;
            this.ProductCodeLabel.Text = "Product Code:";
            // 
            // ProductCode
            // 
            this.ProductCode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductCode.Location = new System.Drawing.Point(106, 53);
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.Size = new System.Drawing.Size(124, 22);
            this.ProductCode.TabIndex = 2;
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityLabel.Location = new System.Drawing.Point(249, 57);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(58, 14);
            this.QuantityLabel.TabIndex = 3;
            this.QuantityLabel.Text = "Quantity:";
            // 
            // ProductQuantity
            // 
            this.ProductQuantity.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductQuantity.Location = new System.Drawing.Point(313, 54);
            this.ProductQuantity.Name = "ProductQuantity";
            this.ProductQuantity.Size = new System.Drawing.Size(124, 22);
            this.ProductQuantity.TabIndex = 4;
            // 
            // InvoiceItemsList
            // 
            this.InvoiceItemsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CodeColumn,
            this.TitleColumn,
            this.PricePerItemColumn,
            this.ItemQuantityColumn});
            this.InvoiceItemsList.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceItemsList.FullRowSelect = true;
            this.InvoiceItemsList.HideSelection = false;
            this.InvoiceItemsList.Location = new System.Drawing.Point(12, 85);
            this.InvoiceItemsList.MultiSelect = false;
            this.InvoiceItemsList.Name = "InvoiceItemsList";
            this.InvoiceItemsList.Size = new System.Drawing.Size(515, 353);
            this.InvoiceItemsList.TabIndex = 5;
            this.InvoiceItemsList.UseCompatibleStateImageBehavior = false;
            this.InvoiceItemsList.View = System.Windows.Forms.View.Details;
            // 
            // CodeColumn
            // 
            this.CodeColumn.Text = "Product Code";
            this.CodeColumn.Width = 100;
            // 
            // TitleColumn
            // 
            this.TitleColumn.Text = "Title";
            this.TitleColumn.Width = 100;
            // 
            // PricePerItemColumn
            // 
            this.PricePerItemColumn.Text = "Price Per Item";
            this.PricePerItemColumn.Width = 100;
            // 
            // ItemQuantityColumn
            // 
            this.ItemQuantityColumn.Text = "Quantity";
            this.ItemQuantityColumn.Width = 100;
            // 
            // DiscountLabel
            // 
            this.DiscountLabel.AutoSize = true;
            this.DiscountLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiscountLabel.Location = new System.Drawing.Point(249, 14);
            this.DiscountLabel.Name = "DiscountLabel";
            this.DiscountLabel.Size = new System.Drawing.Size(58, 14);
            this.DiscountLabel.TabIndex = 6;
            this.DiscountLabel.Text = "Discount:";
            // 
            // Discount
            // 
            this.Discount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Discount.Location = new System.Drawing.Point(313, 11);
            this.Discount.Name = "Discount";
            this.Discount.Size = new System.Drawing.Size(124, 22);
            this.Discount.TabIndex = 7;
            // 
            // CustomerIDLabel
            // 
            this.CustomerIDLabel.AutoSize = true;
            this.CustomerIDLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerIDLabel.Location = new System.Drawing.Point(21, 14);
            this.CustomerIDLabel.Name = "CustomerIDLabel";
            this.CustomerIDLabel.Size = new System.Drawing.Size(79, 14);
            this.CustomerIDLabel.TabIndex = 8;
            this.CustomerIDLabel.Text = "Customer ID:";
            // 
            // CustomerID
            // 
            this.CustomerID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerID.Location = new System.Drawing.Point(106, 11);
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.Size = new System.Drawing.Size(124, 22);
            this.CustomerID.TabIndex = 9;
            // 
            // Remove
            // 
            this.Remove.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remove.Location = new System.Drawing.Point(12, 450);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(75, 23);
            this.Remove.TabIndex = 10;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // OK
            // 
            this.OK.Enabled = false;
            this.OK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.Location = new System.Drawing.Point(369, 450);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 11;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.Location = new System.Drawing.Point(451, 450);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 12;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // InvoiceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 483);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.CustomerID);
            this.Controls.Add(this.CustomerIDLabel);
            this.Controls.Add(this.Discount);
            this.Controls.Add(this.DiscountLabel);
            this.Controls.Add(this.InvoiceItemsList);
            this.Controls.Add(this.ProductQuantity);
            this.Controls.Add(this.QuantityLabel);
            this.Controls.Add(this.ProductCode);
            this.Controls.Add(this.ProductCodeLabel);
            this.Controls.Add(this.Add);
            this.Name = "InvoiceDialog";
            this.Text = "Invoice Dialog";
            this.Load += new System.EventHandler(this.InvoiceDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Label ProductCodeLabel;
        private System.Windows.Forms.TextBox ProductCode;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.TextBox ProductQuantity;
        private System.Windows.Forms.ListView InvoiceItemsList;
        private System.Windows.Forms.ColumnHeader CodeColumn;
        private System.Windows.Forms.ColumnHeader TitleColumn;
        private System.Windows.Forms.ColumnHeader PricePerItemColumn;
        private System.Windows.Forms.ColumnHeader ItemQuantityColumn;
        private System.Windows.Forms.Label DiscountLabel;
        private System.Windows.Forms.TextBox Discount;
        private System.Windows.Forms.Label CustomerIDLabel;
        private System.Windows.Forms.TextBox CustomerID;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}