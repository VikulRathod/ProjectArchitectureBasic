using System.Configuration;
using System.Data.SqlClient;

namespace VHaaSh.API.DAL
{
    public class Connection
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["VHaaShDB"].ConnectionString;
            }
        }

        public static SqlConnection SqlConnectionObject
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }
    }
}
