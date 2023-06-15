#nullable enable
namespace Account
{
    internal class Menu // class menu
    {
        private Compute compute = new Compute();
        private List<Data> datas;
        public Menu(List<Data> datas)
        {
            this.datas = datas;
        }

        /*public Menu()
        {
            
        }*/

        public void Run() // method utama untuk menjalankan menu
        {
            // menampilkan menu aplikasi account database
            Console.Clear();
            Console.WriteLine("====================");
            Console.WriteLine("  Account Database  ");
            Console.WriteLine("====================");
            Console.WriteLine("1. Login Admin");
            Console.WriteLine("2. Login User");
            Console.WriteLine("3. Exit");
            Console.WriteLine("====================");
            Console.Write("Pilih Menu : ");
            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        LoginAdmin();
                        break;
                    case 2:
                        this.Login(this.datas);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Input Tidak Valid");
                        Console.ReadKey();
                        this.Run();
                        break;
                }
            }
            catch (Exception ex) // variabel ex untuk catch
            {
                Console.WriteLine("Maaf Pilihan Menu Tidak Valid");
                Console.ReadKey();
                this.Run();
            }
        }
        public void Buat(List<Data> datas)
        {
            Validasi validasi = new Validasi(); // membuat variabel untuk class validasi
            Console.Clear();
            Console.WriteLine("====================");
            Console.WriteLine(" Buat Akun Database ");
            Console.WriteLine("====================");
            Console.Write("Nama Depan       : ");
            string namaDepan = validasi.NamaValid1(Console.ReadLine());
            Console.Write("Nama Belakang    : ");
            string namaBelakang = validasi.NamaValid2(Console.ReadLine());
            Console.Write("Masukan Password : ");
            string password = validasi.ValidSandi(Console.ReadLine());
            Data data = new Data(namaDepan, namaBelakang, password);
            Console.WriteLine(this.compute.Buat(datas, data));
            Console.WriteLine("Nama Penggunanya : @" + namaDepan + namaBelakang);
            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
            this.IfLoginAdmin();
        }
        public void Login(List<Data> datas)
        {
            Validasi validasi = new Validasi();
            Console.Clear();
            Console.WriteLine("====================");
            Console.WriteLine("     Login User     ");
            Console.WriteLine("====================");
            Console.Write("Masukan Nama Pengguna : ");
            string username = Console.ReadLine();
            Console.Write("Masukan Password      : ");
            string password = Console.ReadLine();
            if (validasi.ValidLogin(datas, username, password))
            {
                IfLoginUser();
            }
            else
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("  Data Akun Tidak Ada ");
                Console.WriteLine("----------------------");
                Console.WriteLine("1. Login Kembali");
                Console.WriteLine("2. Exit");
                Console.WriteLine("----------------------");
                Console.Write("Pilih Menu : ");
                int pilih = Convert.ToInt32(Console.ReadLine());
                switch (pilih)
                {
                    case 1:
                        this.Login(datas);
                        Console.ReadKey();
                        break;
                    case 2:
                        this.Run();
                        break;
                    default:
                        this.Login(datas);
                        break;
                }
                Console.ReadKey();
                this.Login(datas);
            }
        }
        public void LoginAdmin()
        {

            Validasi validasi = new Validasi();
            Console.Clear();
            Console.WriteLine("====================");
            Console.WriteLine("     Login Admin    ");
            Console.WriteLine("====================");
            Console.Write("Masukan Nama Pengguna : ");
            string username = Console.ReadLine();
            Console.Write("Masukan Password      : ");
            string password = Console.ReadLine();
            bool login = Validasi.AdminValid(username, password);
            if (login)
            {
                IfLoginAdmin();
            }
            else
            {
                Console.WriteLine("Anda Bukan Admin");
                Console.ReadKey();
                this.Run();
            }
        }
        public static void IfLoginUser()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("     Login Berhasil   ");
            Console.WriteLine("----------------------");
            GanjilGenap.ProgramEvenOdd();
        }
        public void IfLoginAdmin()
        {
            Console.Clear();
            Console.WriteLine("Halooooo Admin!!!!!!");
            Console.WriteLine("====================");
            Console.WriteLine("  Account Database  ");
            Console.WriteLine("====================");
            Console.WriteLine("1. Buat Akun User");
            Console.WriteLine("2. Cek Akun User");
            Console.WriteLine("3. Cari Akun User");
            Console.WriteLine("4. Logout");
            Console.WriteLine("====================");
            Console.Write("Pilih Menu : ");
            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        this.Buat(this.datas);
                        break;
                    case 2:
                        this.CekAkun(this.datas);
                        break;
                    case 3:
                        this.Cari(this.datas);
                        break;
                    case 4:
                        this.Run();
                        break;
                    default:
                        Console.WriteLine("Input Tidak Valid");
                        Console.ReadKey();
                        this.IfLoginAdmin();
                        break;
                }
            }
            catch (Exception ex1) // variabel ex untuk catch
            {
                Console.WriteLine("Input Tidak Valid");
                Console.ReadKey();
                this.IfLoginAdmin();
            }
        }

        public void CekAkun(List<Data> datas)
        {
            Data cek = new Data();
            Console.Clear();
            Console.WriteLine("=============================");
            Console.WriteLine("      Cek Akun Database      ");
            Console.WriteLine("=============================");
            this.compute.Cek(datas);
            Console.WriteLine("=============================");
            Console.WriteLine("       Pengaturan Akun       ");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Ubah Akun");
            Console.WriteLine("2. Hapus Akun");
            Console.WriteLine("3. Keluar");
            Console.WriteLine(" ");
            Console.Write("Pilih Menu : ");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    this.UbahData(datas, cek);
                    break;
                case 2:
                    this.Hapus(datas);
                    break;
                case 3:
                    this.IfLoginAdmin();
                    break;
                default:
                    Console.WriteLine("Pilihan Tidak Ada");
                    Console.ReadKey();
                    this.CekAkun(datas);
                    break;
            }
            Console.ReadKey();
        }
        public void Cari(List<Data> datas)
        {
            List<Data> cari = new List<Data>();
            Console.Clear();
            Console.WriteLine("=============================");
            Console.WriteLine("     Cari Akun Database      ");
            Console.WriteLine("=============================");
            Console.Write("Masukan Nama Akun : ");
            string nama = Console.ReadLine();
            this.compute.Cek(datas.Where<Data>((Func<Data, bool>)
            (data => data.NamaDepan.ToLower().Contains(nama.ToLower())
            || data.NamaBelakang.ToLower().Contains(nama.ToLower()))).
            Select
            <Data, Data>((Func<Data, Data>)(datas => new Data()
            {
                NamaDepan = datas.NamaDepan,
                NamaBelakang = datas.NamaBelakang,
                NamaPengguna = datas.NamaPengguna,
                Password = datas.Password
            })).ToList<Data>());
            Console.ReadKey();
            this.IfLoginAdmin();
        }
        private void UbahData(List<Data> datas, Data data)
        {
            bool loopubah;
            do
            {
                Console.WriteLine("---------------------------");
                Console.Write("Id Akun Yang Ingin Diubah : ");
                int id = Convert.ToInt32(Console.ReadLine());
                if (id <= datas.Count)
                {
                    Validasi edit = new Validasi();
                    Console.Write("Nama Depan       : ");
                    data.NamaDepan = edit.NamaValid1(Console.ReadLine());
                    Console.Write("Nama Belakang    : ");
                    data.NamaBelakang = edit.NamaValid2(Console.ReadLine());
                    new Validasi().NamaValid2(data.NamaBelakang);
                    Console.Write("Masukan Password : ");
                    data.Password = edit.ValidSandi(Console.ReadLine());
                    new Validasi().ValidSandi(data.Password);
                    Console.WriteLine(this.compute.Edit(datas, data, id));
                    loopubah = false;
                }
                else
                {
                    Console.WriteLine("Akun Tidak Ada Didalam Database");
                    loopubah = true;
                }
            }
            while (loopubah);
            Console.ReadKey();
            this.CekAkun(datas);
        }
        private void Hapus(List<Data> datas)
        {
            Console.WriteLine("---------------------------");
            Console.Write("Id Akun Yang Ingin Dihapus : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write(this.compute.Hapus(datas, id));
            Console.ReadKey();
            this.CekAkun(datas);
        }
    }
}
