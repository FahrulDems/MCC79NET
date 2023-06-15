using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class MenuCountry
    {
        public static void Menu()
        {
            Country coun = new Country();
            var countrys = new List<Country>();
            countrys = coun.GetAllCountry();
            Console.Clear();
            Console.WriteLine("       Menu Of Country      ");
            Console.WriteLine("============================");
            Console.WriteLine("1. Get All Data of Country");
            Console.WriteLine("2. Get Data By id in Country");
            Console.WriteLine("3. Insert Data to Country");
            Console.WriteLine("4. Update Data in Country");
            Console.WriteLine("5. Delete Data in Country");
            Console.WriteLine("6. Exit");
            Console.WriteLine("============================");
            Console.Write("Pilih : ");
            int menu = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("=====\t\t\t   Get All Countries\t\t\t\t=====");
                        foreach (Country country in countrys)
                        {
                            Console.WriteLine($"id : {country.Id}, nama : {country.Name},\t region_id : {country.RegionId}");
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("=====\t\t\t   Get By Id Countries \t\t\t\t=====");
                        Country.GetByIdCountry();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("=====\t\t\t   Insert Data To Countries\t\t\t\t=====");
                        Koneksi.Get();
                        Console.Write("Masukan id: ");
                        string insertidIC = Console.ReadLine();
                        Console.Write("Masukan Nama: ");
                        string insertnamaIC = Console.ReadLine();
                        Console.Write("Masukan RegId: ");
                        int insertregidIC = Convert.ToInt32(Console.ReadLine());
                        int insertsuccesIC = Country.InsertCountry(insertidIC, insertnamaIC, insertregidIC);
                        if (insertsuccesIC > 0)
                        {
                            Console.WriteLine("Data Sudah Ditambahkan");
                        }
                        else
                        {
                            Console.WriteLine("Data Gagal Ditambahkan");
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("=====\t\t\t   Update Data In Regions\t\t\t\t=====");
                        Koneksi.Get();
                        Console.Write("Masukan Update Nama: ");
                        string insertnamaUC = Console.ReadLine();
                        Console.Write("Masukan Update RegId: ");
                        int insertregidUC = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Masukan Id Yang Ingin Dirubah : ");
                        string insertidUC = Console.ReadLine();
                        int insertsuccesUC = Country.UpdateCountry(insertidUC, insertnamaUC, insertregidUC);
                        if (insertsuccesUC > 0)
                        {
                            Console.WriteLine("Data Sudah Diupdate");
                        }
                        else
                        {
                            Console.WriteLine("Data Gagal Diupdate");
                        }
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("=====\t\t\t   Delete Data In Regions\t\t\t\t=====");
                        Koneksi.Get();
                        Console.Write("Masukan Id Yang Ingin Dihapus: ");
                        string insertidDC = Console.ReadLine();
                        int insertsuccesDC = Country.DeleteCountry(insertidDC);
                        if (insertsuccesDC > 0)
                        {
                            Console.WriteLine("Data Sudah Dihapus");
                        }
                        else
                        {
                            Console.WriteLine("Data Gagal Dihapus");
                        }
                        Console.ReadKey();
                        break;
                    case 6:
                        MenuUtama.FirstMenu();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Menu();
            }
        }
    }
}
