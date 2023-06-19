using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using Connection.Contexts;
using Connection.Controllers;

namespace Connection;
public class Program
{
    public static void Main(string[] args)
    {
        new MenuUtama().FirstMenu();
    }
}