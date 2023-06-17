using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class Koneksi
    {
        
        static string connectionString = "Data Source=DEMS;Database=db_hr;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        static SqlConnection connection;
        public static SqlConnection connection2 = new SqlConnection(connectionString);
        public static SqlConnection Get()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
