using Shop.Extensions;
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

            SqlHelper.ExecuteReader(SqlHelper.CreateCommand("CustomerCollection", System.Data.CommandType.StoredProcedure),
                reader =>
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
                        Email = (string)reader["Email"],
                        Address = reader["Address"] == DBNull.Value ? null : (string)reader["Address"]
                    };

                    customer.State = ObjectState.Original;

                    Customers.Add(customer);
                }
                );

            return Customers;
        }

        public void RefreshData(Customer customer)
        {
            SqlHelper.ExecuteReader(SqlHelper.CreateCommand("SelectCustomer", System.Data.CommandType.StoredProcedure, new SqlParameter("@ID", customer.ID)),
                reader =>
                {
                    customer.ID = (long)reader["ID"];
                    customer.Code = (string)reader["Code"];
                    customer.FirstName = (string)reader["FirstName"];
                    customer.LastName = (string)reader["LastName"];
                    customer.Gender = ((bool)reader["Gender"]) ? Gender.Male : Gender.Female;
                    customer.BirthDate = (DateTime)reader["BirthDate"];
                    customer.Country = (string)reader["Country"];
                    customer.Telephone = (string)reader["Telephone"];
                    customer.Email = (string)reader["Email"];
                    customer.Address = reader["Address"] == DBNull.Value ? null : (string)reader["Address"];

                    customer.State = ObjectState.Original;
                }
                );
        }

        public void SaveToDataBase()
        {
            SqlCommand command = SqlHelper.CreateCommand("SaveCustomer", System.Data.CommandType.StoredProcedure);

            try
            {
                command.Connection.Open();

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

                            SqlParameter returnValue = new SqlParameter { Direction = System.Data.ParameterDirection.ReturnValue };
                            command.Parameters.Add(returnValue);

                            command.Parameters.AddWithValue("@ID", customer.ID);
                            command.Parameters.AddWithValue("@Code", customer.Code);
                            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                            command.Parameters.AddWithValue("@LastName", customer.LastName);
                            command.Parameters.AddWithValue("@Gender", customer.Gender == Gender.Male ? "1" : "0");
                            command.Parameters.AddWithValue("@BirthDate", customer.BirthDate);
                            command.Parameters.AddWithValue("@Country", customer.Country ?? string.Empty);
                            command.Parameters.AddWithValue("@Telephone", customer.Telephone);
                            command.Parameters.AddWithValue("@Email", customer.Email);
                            command.Parameters.AddWithValue("@Address", customer.Address);

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
                if (command.Connection.State == System.Data.ConnectionState.Open)
                    command.Connection.Close();
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
