using System;
using System.Data.SqlClient;

namespace Staff_database
{
    public interface IAuthorization
    {
        String getSalt(SqlConnection connection, String login);
        bool loginDB(String login, String password);
        String getServer();

    }
}