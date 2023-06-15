using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable enable
namespace Account
{
    internal class Data
    {
        public string NamaDepan { get; set; }
        public string NamaBelakang { get; set; }
        public string NamaPengguna { get; set; }
        public string Password { get; set; }
        public static string AdminUsername = "Admin";
        public static string AdminPassword = "admin";
        public Data(string namaDepan, string namaBelakang, string password)
        {
            this.NamaDepan = namaDepan;
            this.NamaBelakang = namaBelakang;
            this.NamaPengguna = "@"+namaDepan + namaBelakang;
            this.Password = password;
        }
        public Data(string password)
        {
            this.Password = password;
        }
        public Data()
        {
        }
        
    }
}
