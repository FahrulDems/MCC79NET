using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Contexts;

public class Koneksi
{

    private static string connectionString = "Data Source=DEMS;Database=db_hr;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    public static SqlConnection Get()
    {
        return new SqlConnection(connectionString);
    }
}
