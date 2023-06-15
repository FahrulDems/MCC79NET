using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class MenuUtama
    {
        public static void FirstMenu()
        {
            Location location = new Location();
            Department department = new Department();
            Employee employee = new Employee();
            Jobs jobs = new Jobs();
            Histories histories = new Histories();
            Linq linq = new Linq();

            Console.Clear();
            Console.WriteLine("============Wellcome To Database db_hr==========");
            Console.WriteLine("================================================");
            Console.WriteLine("                   PILIH MENU                   ");
            Console.WriteLine("1.  Regions");
            Console.WriteLine("2.  Countries");
            Console.WriteLine("3.  Locations");
            Console.WriteLine("4.  Employees");
            Console.WriteLine("5.  Departments");
            Console.WriteLine("6.  Jobs");
            Console.WriteLine("7.  Histories");
            Console.WriteLine("8.  LINQ");
            Console.WriteLine("9.  LINQ2");
            Console.WriteLine("10. EXIT");
            Console.WriteLine("================================================");
            Console.Write("Silahkan Pilih Menu: ");
            int pilih = Convert.ToInt32(Console.ReadLine());
            switch (pilih)
            {
                case 1:
                    MenuRegion.Menu();
                    FirstMenu();
                    break;
                case 2:
                    MenuCountry.Menu();
                    FirstMenu();
                    break;
                case 3:
                    Console.WriteLine("=====\t\t\t   Get All Locations\t\t\t\t=====");
                    location.GetLocation();
                    Console.ReadKey();
                    FirstMenu();
                    break;
                case 4:
                    Console.WriteLine("=====\t\t\t   Get All Employees\t\t\t\t=====");
                    employee.GetEmployee();
                    Console.ReadKey();
                    FirstMenu();
                    break;
                case 5:
                    Console.WriteLine("=====\t\t\t   Get All Departments\t\t\t\t=====");
                    department.GetDepartment();
                    Console.ReadKey();
                    FirstMenu();
                    break;
                case 6:
                    Console.WriteLine("=====\t\t\t   Get All Jobs\t\t\t\t=====");
                    jobs.GetJob();
                    Console.ReadKey();
                    FirstMenu();
                    break;
                case 7:
                    Console.WriteLine("=====\t\t\t   Get All Histories\t\t\t\t=====");
                    histories.GetHistories();
                    Console.ReadKey();
                    FirstMenu();
                    break;
                case 8:
                    Console.WriteLine("LINQ");
                    linq.Menu(5);
                    break;
                case 9:
                    Console.WriteLine("LINQ2");
                    linq.GetDepartments();
                    break;
                case 10:
                    Environment.Exit(0);
                    break;
                default:
                    FirstMenu();
                    break;                 
            }
        }
    }
}
