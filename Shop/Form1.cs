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

        private void Customers_Click(object sender, EventArgs e)
        {
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Customers.Focus();
            this.Customers.PerformClick();
            LastClickedTabBotton = this.Customers;
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
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            CustomerCollection.Current.SaveToDataBase();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
