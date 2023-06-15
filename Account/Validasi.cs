using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable enable
namespace Account
{
    internal class Validasi
    {
        
        public string NamaValid1(string nama)
        {
            bool loopnama = true;
            if (nama.Length < 2)
            {
                Console.WriteLine("Minimal Nama Depan 2 Karakter");
                Console.Write("Nama Depan       : ");
                nama =  this.NamaValid1(Console.ReadLine());
                return nama;
            }
            else
            {
                return nama;
            }
            loopnama = true;

        }
        public string NamaValid2(string nama)
        {
            if (nama.Length < 2)
            {
                Console.WriteLine("Minimal Nama Belakang 2 Karakter");
                Console.Write("Nama Belakang    : ");
                nama = this.NamaValid2(Console.ReadLine());
                return nama;
            }
            else
            {
                return nama;
            }
        }
        public static bool AdminValid(string username, string password)
        {
            // Memvalidasi username dan password
            if (username == Data.AdminUsername && password == Data.AdminPassword)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public string ValidSandi(string password)
        {
            bool loopsandi;
            do
            {
                if (password.Length >= 8 
                    && password.Any<char>(new Func<char, bool>(char.IsUpper)) 
                    && password.Any<char>(new Func<char, bool>(char.IsLower)) 
                    && password.Any<char>(new Func<char, bool>(char.IsNumber)))
                {
                    loopsandi = false;
                }
                else
                {
                    Console.WriteLine("Masukan Password min 8 dan harus ada karakter Angka dan Huruf BESAR / kecil");
                    Console.Write("Masukan Password : ");
                    password = this.ValidSandi(Console.ReadLine());
                    loopsandi = true;
                }
            }
                while (loopsandi) ;
                return password;
        }
        public bool DataValid(List<Data> datas, string namaPengguna)
        {
            for(int i = 0; i < datas.Count; i++)
            {
                if (datas[i].NamaPengguna == namaPengguna)
                    return true;
            }
            return false;
        }
        public bool ValidLogin(List<Data> datas, string namaPengguna, string password)
        {
            bool looplogin = false;
            for (int i = 0; i < datas.Count; ++i)
            {
                if(namaPengguna == datas[i].NamaPengguna &&  password == datas[i].Password)
                {
                    looplogin = true;
                    break;
                }
  
            }
            return looplogin;
        }
        public static bool ValidEdit(List<Data> datas, string namaPengguna)

        {
            foreach (var data in datas)
            {
                if(data.NamaPengguna == namaPengguna)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }   
    }
}
