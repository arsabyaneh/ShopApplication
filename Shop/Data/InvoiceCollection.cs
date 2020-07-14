using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop.Data
{
    public class InvoiceCollection : ObservableCollection<Invoice>
    {
        private static InvoiceCollection _Current;
        public static InvoiceCollection Current
        {
            get
            {
                if (_Current == null)
                    _Current = LoadFromDataBase();

                return _Current;
            }
            set
            {
                _Current = value;
            }
        }

        private static List<Invoice> RemovedInvoices;

        public static int InitialInvoiceCode { get; set; }

        public static InvoiceCollection LoadFromDataBase()
        {
            RemovedInvoices = new List<Invoice>();
            InitialInvoiceCode = 1;

            InvoiceCollection Invoices = new InvoiceCollection();

            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Shop"].ConnectionString);
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "InvoiceCollection",
                CommandType = System.Data.CommandType.StoredProcedure
            };

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                bool isFirstTime = true;

                while (reader.Read())
                {
                    if (isFirstTime)
                    {
                        isFirstTime = false;
                        InitialInvoiceCode = int.Parse(
                            (string)reader["Code"], System.Globalization.NumberStyles.Integer) + 1;
                    }

                    Invoice invoice = new Invoice()
                    {
                        ID = (long)reader["ID"],
                        Code = (string)reader["Code"],
                        InvoiceDate = (DateTime)reader["InvoiceDate"],
                        Discount = (decimal)reader["Discount"],
                        CustomerID = (long)reader["CustomerID"]
                    };

                    invoice.InvoiceItems = invoice.InvoiceItems.LoadFromDataBase(invoice);
                    invoice.State = ObjectState.Original;

                    Invoices.Add(invoice);
                }

                reader.Close();
            }
            catch
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return Invoices;
        }

        public void RefreshData(Invoice invoice)
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Shop"].ConnectionString);
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "SelectInvoice",
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ID", invoice.ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    invoice.ID = (long)reader["ID"];
                    invoice.Code = (string)reader["Code"];
                    invoice.InvoiceDate = (DateTime)reader["InvoiceDate"];
                    invoice.Discount = (decimal)reader["Discount"];
                    invoice.CustomerID = (long)reader["CustomerID"];

                    invoice.InvoiceItems.LoadFromDataBase(invoice);
                    invoice.State = ObjectState.Original;
                }

                reader.Close();
            }
            catch
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        public void SaveToDataBase()
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Shop"].ConnectionString);
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.StoredProcedure
            };

            try
            {
                connection.Open();

                command.CommandText = "SaveInvoice";
                foreach (Invoice invoice in Current)
                {
                    switch (invoice.State)
                    {
                        case ObjectState.Original:
                            continue;

                        case ObjectState.New:
                        case ObjectState.Modified:
                            command.Parameters.Clear();

                            command.Parameters.AddWithValue("@ID", invoice.ID);
                            command.Parameters.AddWithValue("@Code", invoice.Code);
                            command.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate);
                            command.Parameters.AddWithValue("@Discount", invoice.Discount);
                            command.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);

                            SqlParameter returnValue = new SqlParameter { Direction = System.Data.ParameterDirection.ReturnValue };
                            command.Parameters.Add(returnValue);

                            object result = command.ExecuteScalar();

                            switch ((int)returnValue.Value)
                            {
                                case -1:
                                    MessageBox.Show(
                                        string.Format("Code '{0}' is dupplicated.", invoice.Code),
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                    break;

                                case 0:
                                    invoice.ID = (long)result;
                                    RefreshData(invoice);
                                    break;
                            }

                            invoice.InvoiceItems.SaveToDataBase();

                            break;
                    }
                }

                command.CommandText = "DeleteInvoice";
                foreach (Invoice invoice in RemovedInvoices)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID", invoice.ID);
                    command.ExecuteNonQuery();
                }
                RemovedInvoices.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

        }

        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    RemovedInvoices.Add((Invoice)item);
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    (item as Invoice).PropertyChanged += Customer_PropertyChanged;
                }
            }

            base.OnCollectionChanged(e);
        }

        private void Customer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Invoice).State = ObjectState.Modified;
            // only to raise the event
            this.OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
        }
    }
}