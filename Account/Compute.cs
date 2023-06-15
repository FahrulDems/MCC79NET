using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
#nullable enable
namespace Account
{
    internal class Compute
    {
        public string Buat(List<Data> datas, Data data)
        {
            if (new Validasi().DataValid(datas, data.NamaPengguna))
                return "----------------------" +
                      "\n   Data Sudah Ada    " +
                     "\n----------------------";
            datas.Add(data);
            return "----------------------" +
                  "\nBerhasil Membuat Data";
        }
        public void Cek(List<Data> datas)
        {
            int num = 0;
            foreach (Data data in datas)
            {
                ++num;
                DefaultInterpolatedStringHandler id= new DefaultInterpolatedStringHandler(5, 1);
                id.AppendLiteral("ID            : ");
                id.AppendFormatted<int>(num);
                Console.WriteLine(id.ToStringAndClear());
                Console.WriteLine("Nama          : " + data.NamaDepan + " " + data.NamaBelakang);
                Console.WriteLine("Nama Pengguna : " + data.NamaPengguna);
                Console.WriteLine("Password      : " + data.Password);
                Console.WriteLine(" ");
            }
        }
        public string Edit(List<Data> datas, Data data, int id)
        {    
            bool namaPengguna = Validasi.ValidEdit(datas, "@" + data.NamaDepan + data.NamaBelakang);
            if(!namaPengguna)
            {
                datas[id - 1].NamaDepan = new Validasi().NamaValid1(data.NamaDepan);
                datas[id - 1].NamaBelakang = new Validasi().NamaValid2(data.NamaBelakang);
                datas[id - 1].NamaPengguna = "@" + data.NamaDepan + data.NamaBelakang;
                datas[id - 1].Password = new Validasi().ValidSandi(data.Password);
                return "Data Sudah Diubah";        
            }
            else
            {
                return "\n-------------------" +
                       "\nNama Akun Sudah Ada" +
                       "\n-------------------";
            }
        }
        public string Hapus(List<Data> datas, int id)
        {
            if (id > datas.Count)
            {
                return "Id Akun Tidak Ada";
            }
            datas.RemoveAt(id - 1);
            return "Akun Berhasil Dihapus";
        }
    }


}
