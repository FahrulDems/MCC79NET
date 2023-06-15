using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class MenuRegion
    {
        public static void Menu()
        {
            Region reg = new Region();
            var regions = new List<Region>();
            regions = reg.GetAllRegion();
            Console.Clear();
            Console.WriteLine("       Menu Of Regions      ");
            Console.WriteLine("============================");
            Console.WriteLine("1. Get All Data of Regions");
            Console.WriteLine("2. Get Data By id in Regions");
            Console.WriteLine("3. Insert Data to Regions");
            Console.WriteLine("4. Update Data in Regions");
            Console.WriteLine("5. Delete Data in Regions");
            Console.WriteLine("6. Exit");
            Console.WriteLine("============================");
            Console.Write("Pilih : ");
            int menu = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("=====\t\t\t    Get All Regions\t\t\t\t=====");
                        reg.GetAllRegion();
                        foreach (Region region in regions)
                        {
                            Console.WriteLine($"id : {region.Id}, nama : {region.Name}");
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("=====\t\t\t   Get By Id Regions\t\t\t\t=====");
                        Region.GetByIdRegion();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("=====\t\t\t   Insert Data To Regions\t\t\t\t=====");
                        Koneksi.Get();
                        Console.Write("Masukan Nama: ");
                        string insertnamaIR = Console.ReadLine();
                        int insertsuccesIR = Region.InsertRegion(insertnamaIR);
                        if (insertsuccesIR > 0)
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
                        Console.Write("Masukan Nama: ");
                        string insertnamaUR = Console.ReadLine();
                        Console.Write("Masukan Id: ");
                        int insertidUR = Convert.ToInt32(Console.ReadLine());
                        int insertsuccesUR = Region.UpdateRegion(insertidUR, insertnamaUR);
                        if (insertsuccesUR > 0)
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
                        int insertidDR = Convert.ToInt32(Console.ReadLine());
                        int insertsuccesDR = Region.DeleteRegion(insertidDR);
                        if (insertsuccesDR > 0)
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
            }
            Menu();
        }
    }
}
