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
    public class InvoiceItemCollection : ObservableCollection<InvoiceItem>
    {
        public List<InvoiceItem> RemovedInvoiceItems;

        public InvoiceItemCollection()
        {
            RemovedInvoiceItems = new List<InvoiceItem>();
        }

        public InvoiceItemCollection LoadFromDataBase(Invoice invoice)
        {
            InvoiceItemCollection InvoiceItems = new InvoiceItemCollection();

            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Shop"].ConnectionString);
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "InvoiceItemsOfAnInvoice",
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@InvoiceID", invoice.ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    InvoiceItem invoiceItem = new InvoiceItem()
                    {
                        ID = (long)reader["InvoiceItemID"],
                        Quantity = (int)reader["Quantity"],
                        Invoice = invoice,
                        Product = new Product
                        {
                            ID = (long)reader["ProductID"],
                            Title = (string)reader["Title"],
                            Code = (string)reader["Code"],
                            BrandID = (long)reader["BrandID"]
                        }
                    };

                    invoiceItem.State = ObjectState.Original;

                    InvoiceItems.Add(invoiceItem);
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

            return InvoiceItems;
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

                command.CommandText = "SaveInvoiceItem";
                foreach (InvoiceItem invoiceItem in this)
                {
                    switch (invoiceItem.State)
                    {
                        case ObjectState.Original:
                            continue;

                        case ObjectState.New:
                        case ObjectState.Modified:
                            command.Parameters.Clear();

                            command.Parameters.AddWithValue("@ID", invoiceItem.ID);
                            command.Parameters.AddWithValue("@Quantity", invoiceItem.Quantity);
                            command.Parameters.AddWithValue("@InvoiceID", invoiceItem.Invoice.ID);
                            command.Parameters.AddWithValue("@ProductID", invoiceItem.Product.ID);

                            SqlParameter returnValue = new SqlParameter { Direction = System.Data.ParameterDirection.ReturnValue };
                            command.Parameters.Add(returnValue);

                            object result = command.ExecuteScalar();

                            switch ((int)returnValue.Value)
                            {
                                case 0:
                                    invoiceItem.ID = (long)result;
                                    break;
                            }

                            invoiceItem.State = ObjectState.Original;
                            break;
                    }
                }

                command.CommandText = "DeleteInvoiceItem";
                foreach (InvoiceItem invoiceItem in RemovedInvoiceItems)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID", invoiceItem.ID);
                    command.ExecuteNonQuery();
                }
                RemovedInvoiceItems.Clear();
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
    }
}
