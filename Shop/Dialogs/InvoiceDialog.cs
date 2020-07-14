using Shop.Data;
using Shop.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop.Dialogs
{
    public partial class InvoiceDialog : Form
    {
        private DateTime InvoiceDate;
        private bool isThereInitialization = true;

        public InvoiceDialog()
        {
            InitializeComponent();
        }

        private Invoice _Value;

        public Invoice Value
        {
            get
            {
                try
                {
                    _Value.Code = _Value.State == ObjectState.New ? InvoiceCollection.InitialInvoiceCode++.ToString("D5") : _Value.Code;
                    _Value.InvoiceDate = _Value.State == ObjectState.New ? InvoiceDate : _Value.InvoiceDate;
                    _Value.Discount = decimal.Parse(this.Discount.Text);
                    _Value.CustomerID = long.Parse(this.CustomerID.Text);
                }
                catch
                {

                }

                return _Value;
            }
            set
            {
                _Value = value;

                if (isThereInitialization == false)
                    return;

                this.Discount.Text = _Value.Discount.ToString();
                this.CustomerID.Text = _Value.CustomerID.ToString();
                _Value.InvoiceItems.ForEach(i => ShowInvoiceItem(i));
                InvoiceDate = _Value.InvoiceDate;
            }
        }

        private void InvoiceDialog_Load(object sender, EventArgs e)
        {
            if (_Value == null)
            {
                _Value = new Invoice();
                isThereInitialization = false;
                InvoiceDate = DateTime.Now;
            }
        }

        private bool GetProductDetails(Product product)
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Shop"].ConnectionString);
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "SelectProductByCode",
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Code", product.Code);
            command.Parameters.AddWithValue("@InvoiceDate", InvoiceDate);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    product.ID = (long)reader["ID"];
                    product.Title = (string)reader["Title"];
                    product.Code = (string)reader["Code"];
                    product.BrandID = (long)reader["BrandID"];
                    product.SellPrice = (decimal)reader["Sell"];

                    product.State = ObjectState.Original;
                }

                reader.Close();

                return true;
            }
            catch
            {
                MessageBox.Show("Product does not Exist!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        private void ShowInvoiceItem(InvoiceItem invoiceItem)
        {
            ListViewItem listItem = new ListViewItem();
            listItem.SubItems.Insert(0, new ListViewItem.ListViewSubItem(listItem, invoiceItem.Product.Code));
            listItem.SubItems.Insert(1, new ListViewItem.ListViewSubItem(listItem, invoiceItem.Product.Title));
            listItem.SubItems.Insert(2, new ListViewItem.ListViewSubItem(listItem, invoiceItem.Product.SellPrice.ToString()));
            listItem.SubItems.Insert(3, new ListViewItem.ListViewSubItem(listItem, invoiceItem.Quantity.ToString()));
            listItem.Tag = invoiceItem;
            this.InvoiceItemsList.Items.Add(listItem);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Product productItem = new Product()
            {
                Code = this.ProductCode.Text
            };

            InvoiceItem invoiceItem = new InvoiceItem()
            {
                Quantity = int.Parse(this.ProductQuantity.Text),
                Invoice = _Value,
                Product = productItem
            };

            _Value.InvoiceItems.Add(invoiceItem);
            if (!GetProductDetails(invoiceItem.Product)) return;
            ShowInvoiceItem(invoiceItem);

            if (this.OK.Enabled == false)
                this.OK.Enabled = true;
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (this.InvoiceItemsList.SelectedItems.Count == 0)
                return;

            InvoiceItem invoiceItem = (InvoiceItem)this.InvoiceItemsList.SelectedItems[0].Tag;

            if (MessageBox.Show(string.Format("Do you want to delete {0} from the list?", invoiceItem),
                "Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                return;

            _Value.InvoiceItems.Remove(invoiceItem);
            this.InvoiceItemsList.SelectedItems[0].Remove();

            if (this.OK.Enabled == false)
                this.OK.Enabled = true;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
