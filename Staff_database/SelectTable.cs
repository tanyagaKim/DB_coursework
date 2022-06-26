using System;
using System.Data.SqlClient;

namespace Staff_database
{
    class SelectTable
    {
        public SqlDataAdapter selectCommand(string stringCommand, SqlConnection connection)
        {
            try
            {
                connection.Open();
            }
            catch
            {
                throw new Exception("Error open connection");
            }

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(stringCommand, connection);

            adapter.SelectCommand = command;

            connection.Close();

            return adapter;
        }
    }
}
