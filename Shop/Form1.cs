using Shop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    public partial class Form1 : Form
    {
        Control LastClickedTabBotton;

        public Form1()
        {
            InitializeComponent();
            CustomerCollection.Current.CollectionChanged += CustomerCollection_CollectionChanged;
            InvoiceCollection.Current.CollectionChanged += InvoiceCollection_CollectionChanged;
        }

        private void CustomerCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach(var customer in e.NewItems)
                {
                    ListViewItem listItem = new ListViewItem();
                    listItem.SubItems.Insert(0, new ListViewItem.ListViewSubItem(listItem, (customer as Customer).Code));
                    listItem.SubItems.Insert(1, new ListViewItem.ListViewSubItem(listItem, (customer as Customer).FirstName));
                    listItem.SubItems.Insert(2, new ListViewItem.ListViewSubItem(listItem, (customer as Customer).LastName));
                    listItem.Tag = customer;
                    (this.ListViewPanel.Controls[0] as ListView).Items.Add(listItem);
                }
            }
        }

        private void InvoiceCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (var invoice in e.NewItems)
                {
                    ListViewItem listItem = new ListViewItem();
                    listItem.SubItems.Insert(0, new ListViewItem.ListViewSubItem(listItem, (invoice as Invoice).Code));
                    listItem.SubItems.Insert(1, new ListViewItem.ListViewSubItem(listItem, (invoice as Invoice).InvoiceDate.ToString()));
                    listItem.SubItems.Insert(2, new ListViewItem.ListViewSubItem(listItem, (invoice as Invoice).Discount.ToString()));
                    listItem.Tag = invoice;
                    (this.ListViewPanel.Controls[0] as ListView).Items.Add(listItem);
                }
            }
        }

        private void ShowCurrentCustomerCollection()
        {
            foreach(Customer customer in CustomerCollection.Current)
            {
                ListViewItem listItem = new ListViewItem();
                listItem.SubItems.Insert(0, new ListViewItem.ListViewSubItem(listItem, customer.Code));
                listItem.SubItems.Insert(1, new ListViewItem.ListViewSubItem(listItem, customer.FirstName));
                listItem.SubItems.Insert(2, new ListViewItem.ListViewSubItem(listItem, customer.LastName));
                listItem.Tag = customer;
                (this.ListViewPanel.Controls[0] as ListView).Items.Add(listItem);
            }
        }

        private void ShowCurrentInvoiceCollection()
        {
            foreach (Invoice invoice in InvoiceCollection.Current)
            {
                ListViewItem listItem = new ListViewItem();
                listItem.SubItems.Insert(0, new ListViewItem.ListViewSubItem(listItem, invoice.Code));
                listItem.SubItems.Insert(1, new ListViewItem.ListViewSubItem(listItem, invoice.InvoiceDate.ToString()));
                listItem.SubItems.Insert(2, new ListViewItem.ListViewSubItem(listItem, invoice.Discount.ToString()));
                listItem.Tag = invoice;
                (this.ListViewPanel.Controls[0] as ListView).Items.Add(listItem);
            }
        }

        private void Customers_Click(object sender, EventArgs e)
        {
            this.ListViewPanel.Controls.Clear();

            ListView listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.MultiSelect = false;
            listView.FullRowSelect = true;
            listView.Columns.Add("Code", 100);
            listView.Columns.Add("First Name", 200);
            listView.Columns.Add("Last Name", 200);

            this.ListViewPanel.Controls.Add(listView);

            ShowCurrentCustomerCollection();

            LastClickedTabBotton = this.Customers;
        }

        private void Invoices_Click(object sender, EventArgs e)
        {
            this.ListViewPanel.Controls.Clear();

            ListView listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.MultiSelect = false;
            listView.FullRowSelect = true;
            listView.Columns.Add("Code", 100);
            listView.Columns.Add("Date", 200);
            listView.Columns.Add("Discount", 100);

            this.ListViewPanel.Controls.Add(listView);

            ShowCurrentInvoiceCollection();

            LastClickedTabBotton = this.Invoices;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Customers.Focus();
            this.Customers.PerformClick();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            switch (LastClickedTabBotton.Name)
            {
                case "Customers":
                    Dialogs.CustomerDialog customerDialog = new Dialogs.CustomerDialog();
                    if (customerDialog.ShowDialog() == DialogResult.Cancel) return;
                    CustomerCollection.Current.Add(customerDialog.Value);
                    break;

                case "Invoices":
                    Dialogs.InvoiceDialog invoiceDialog = new Dialogs.InvoiceDialog();
                    if (invoiceDialog.ShowDialog() == DialogResult.Cancel) return;
                    InvoiceCollection.Current.Add(invoiceDialog.Value);
                    break;
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            switch (LastClickedTabBotton.Name)
            {
                case "Customers":
                    Dialogs.CustomerDialog customerDialog = new Dialogs.CustomerDialog()
                    {
                        Value = (Customer)(this.ListViewPanel.Controls[0] as ListView).SelectedItems[0].Tag
                    };
                    if (customerDialog.ShowDialog() == DialogResult.Cancel) return;
                    Customer customer = customerDialog.Value; // ** is updated in CustomerCollection.Current

                    (this.ListViewPanel.Controls[0] as ListView).SelectedItems[0].SubItems[0].Text = customer.Code;
                    (this.ListViewPanel.Controls[0] as ListView).SelectedItems[0].SubItems[1].Text = customer.FirstName;
                    (this.ListViewPanel.Controls[0] as ListView).SelectedItems[0].SubItems[2].Text = customer.LastName;
                    break;

                case "Invoices":
                    Dialogs.InvoiceDialog invoiceDialog = new Dialogs.InvoiceDialog()
                    {
                        Value = (Invoice)(this.ListViewPanel.Controls[0] as ListView).SelectedItems[0].Tag
                    };
                    if (invoiceDialog.ShowDialog() == DialogResult.Cancel) return;
                    Invoice invoice = invoiceDialog.Value; // ** is updated in InvoiceCollection.Current

                    (this.ListViewPanel.Controls[0] as ListView).SelectedItems[0].SubItems[0].Text = invoice.Code;
                    (this.ListViewPanel.Controls[0] as ListView).SelectedItems[0].SubItems[1].Text = invoice.InvoiceDate.ToLongDateString();
                    (this.ListViewPanel.Controls[0] as ListView).SelectedItems[0].SubItems[2].Text = invoice.Discount.ToString();
                    break;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            switch (LastClickedTabBotton.Name)
            {
                case "Customers":
                    CustomerCollection.Current.SaveToDataBase();
                    break;

                case "Invoices":
                    InvoiceCollection.Current.SaveToDataBase();
                    break;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
