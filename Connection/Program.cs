using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Connection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Koneksi.Get();
            try
            {
                Koneksi.Get();
                Console.WriteLine("Connected");
                Koneksi.Get().Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Failed");
                Console.WriteLine(ex.Message);
            }
            MenuUtama.FirstMenu();
        }
    }
}