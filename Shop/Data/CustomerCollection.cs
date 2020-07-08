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
    public class CustomerCollection : ObservableCollection<Customer>
    {
        private static CustomerCollection _Current;
        public static CustomerCollection Current
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

        private static List<Customer> RemovedCustomers;

        public static CustomerCollection LoadFromDataBase()
        {
            RemovedCustomers = new List<Customer>();

            CustomerCollection Customers = new CustomerCollection();

            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Shop"].ConnectionString);
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "CustomerCollection",
                CommandType = System.Data.CommandType.StoredProcedure
            };

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Customer customer = new Customer()
                    {
                        ID = (long)reader["ID"],
                        Code = (string)reader["Code"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Gender = ((bool)reader["Gender"]) ? Gender.Male : Gender.Female,
                        BirthDate = (DateTime)reader["BirthDate"],
                        Country = (string)reader["Country"],
                        Telephone = (string)reader["Telephone"],
                        Address = reader["Address"] == DBNull.Value ? null : (string)reader["Address"]
                    };

                    customer.State = ObjectState.Original;

                    Customers.Add(customer);
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

            return Customers;
        }

        public void RefreshData(Customer customer)
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Shop"].ConnectionString);
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "SelectCustomer",
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ID", customer.ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    customer.ID = (long)reader["ID"];
                    customer.Code = (string)reader["Code"];
                    customer.FirstName = (string)reader["FirstName"];
                    customer.LastName = (string)reader["LastName"];
                    customer.Gender = ((bool)reader["Gender"]) ? Gender.Male : Gender.Female;
                    customer.BirthDate = (DateTime)reader["BirthDate"];
                    customer.Country = (string)reader["Country"];
                    customer.Telephone = (string)reader["Telephone"];
                    customer.Address = reader["Address"] == DBNull.Value ? null : (string)reader["Address"];

                    customer.State = ObjectState.Original;
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

                command.CommandText = "SaveCustomer";
                foreach (Customer customer in Current)
                {
                    switch (customer.State)
                    {
                        case ObjectState.Original:
                            continue;

                        case ObjectState.New:
                        case ObjectState.Modified:
                            command.Parameters.Clear();

                            command.Parameters.AddWithValue("@ID", customer.ID);
                            command.Parameters.AddWithValue("@Code", customer.Code);
                            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                            command.Parameters.AddWithValue("@LastName", customer.LastName);
                            command.Parameters.AddWithValue("@Gender", customer.Gender == Gender.Male ? "1" : "0");
                            command.Parameters.AddWithValue("@BirthDate", customer.BirthDate);
                            command.Parameters.AddWithValue("@Country", customer.Country ?? string.Empty);
                            command.Parameters.AddWithValue("@Telephone", customer.Telephone);
                            command.Parameters.AddWithValue("@Address", customer.Address);

                            SqlParameter returnValue = new SqlParameter { Direction = System.Data.ParameterDirection.ReturnValue };
                            command.Parameters.Add(returnValue);

                            object result = command.ExecuteScalar();

                            switch ((int)returnValue.Value)
                            {
                                case -1:
                                    MessageBox.Show(
                                        string.Format("Code '{0}' for the '{1}' is dupplicated.",
                                            customer.Code,
                                            customer.FullName),
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                    break;

                                case 0:
                                    customer.ID = (long)result;
                                    RefreshData(customer);
                                    break;
                            }

                            break;
                    }
                }

                command.CommandText = "DeleteCustomer";
                foreach (Customer customer in RemovedCustomers)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID", customer.ID);
                    command.ExecuteNonQuery();
                }
                RemovedCustomers.Clear();
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
                    RemovedCustomers.Add((Customer)item);
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    (item as Customer).PropertyChanged += Customer_PropertyChanged;
                }
            }

            base.OnCollectionChanged(e);
        }

        private void Customer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Customer).State = ObjectState.Modified;
            // only to raise the event
            this.OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
        }
    }
}
