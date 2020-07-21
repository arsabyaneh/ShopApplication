using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop.Extensions
{
    public static class SqlHelper
    {
        public static SqlConnection CreateConnection()
        {
            SqlConnection sqlConnection = new SqlConnection
            {
                ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Shop"].ConnectionString
            };

            return sqlConnection;
        }

        public static SqlCommand CreateCommand(string commandText, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = CreateConnection(),
                CommandText = commandText,
                CommandType = commandType
            };

            SqlParameter returnParameter = new SqlParameter() { Direction = ParameterDirection.ReturnValue };

            sqlCommand.Parameters.Add(returnParameter);
            sqlCommand.Parameters.AddRange(sqlParameters);

            return sqlCommand;
        }

        public static void Execute(SqlCommand sqlCommand, ExecuteHandler handler)
        {
            Execute(sqlCommand, handler, null);
        }

        public static void Execute(SqlCommand sqlCommand, ExecuteHandler handler, ExceptionHandler exceptionHandler)
        {
            try
            {
                sqlCommand.Connection.Open();

                handler(sqlCommand);
            }
            catch (Exception ex)
            {
                if (exceptionHandler == null)
                {
                    MessageBox.Show(ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    return;
                }

                exceptionHandler(ex);
            }
            finally
            {
                if (sqlCommand.Connection.State == ConnectionState.Open)
                    sqlCommand.Connection.Close();
            }
        }

        public static void ExecuteReader(SqlCommand sqlCommand, ExecuteReaderHandler handler)
        {
            ExecuteReader(sqlCommand, handler, null);
        }

        public static void ExecuteReader(SqlCommand sqlCommand, ExecuteReaderHandler handler, ExceptionHandler exceptionHandler)
        {
            Execute(sqlCommand,
                c =>
                {
                    SqlDataReader reader = c.ExecuteReader();

                    while (reader.Read())
                        handler(reader);

                    reader.Close();
                },
                exceptionHandler);
        }

        public static int ExecuteNonQuery(SqlCommand sqlCommand)
        {
            return ExecuteNonQuery(sqlCommand, null);
        }

        public static int ExecuteNonQuery(SqlCommand sqlCommand, ExceptionHandler exceptionHandler)
        {
            int rowsAffeted = -1;

            Execute(sqlCommand,
                c =>
                {
                    rowsAffeted = c.ExecuteNonQuery();
                },
                exceptionHandler);

            return rowsAffeted;
        }

        public static object ExecuteScalar(SqlCommand sqlCommand)
        {
            return ExecuteScalar(sqlCommand);
        }

        public static object ExecuteScalar(SqlCommand sqlCommand, ExceptionHandler exceptionHandler)
        {
            object result = null;

            Execute(sqlCommand,
                c =>
                {
                    result = c.ExecuteScalar();
                },
                exceptionHandler);

            return result;
        }

        public delegate void ExecuteHandler(SqlCommand command);
        public delegate void ExceptionHandler(Exception ex);
        public delegate void ExecuteReaderHandler(SqlDataReader reader);
    }
}
