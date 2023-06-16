using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class Linq
    {
        Employee employee = new Employee();
        Department department = new Department();
        Location location = new Location();
        Country country = new Country();
        Region region = new Region();
        Jobs job = new Jobs();
        //Histories history = new Histories();
        public void Menu (int limit)
        {
            /*var linq = (from e in employee.GetAllEmployee()
                             join j in job.GetAllJob() on e.JobId equals j.Id
                             join d in department.GetAllDepartment() on e.DepartmentId equals d.Id
                             join l in location.GetAllLocation() on d.LocationId equals l.Id
                             join c in country.GetAllCountry() on l.CountryId equals c.Id
                             join r in region.GetAllRegion() on c.RegionId equals r.Id
                             select new
                             {
                                 id = e.Id,
                                 fullName = $"{e.FirstName} {e.LastName}",
                                 email = e.Email,
                                 phone = e.PhoneNumber,
                                 salary = e.Salary,
                                 department_Name = d.Name,
                                 streetAddress = l.StreetAddress,
                                 countryName = c.Name,
                                 regionName = r.Name
                             }).Take(limit).ToList();*/

            var linq = employee.GetAllEmployee()
                    .Join(job.GetAllJob(), 
                        e => e.JobId, j => j.Id, 
                        (e, j) => new { e, j })
                    .Join(department.GetAllDepartment(), 
                        ej => ej.e.DepartmentId, d => d.Id, 
                        (ej, d) => new { ej.e, ej.j, d })
                    .Join(location.GetAllLocation(),
                        ejd => ejd.d.LocationId,  l => l.Id, 
                        (ejd, l) => new { ejd.e, ejd.j, ejd.d, l })
                    .Join(country.GetAllCountry(), 
                        ejdl => ejdl.l.CountryId, c => c.Id, 
                        (ejdl, c) => new { ejdl.e, ejdl.j, ejdl.d, ejdl.l, c })
                    .Join(region.GetAllRegion(), 
                        ejdlc => ejdlc.c.RegionId, r => r.Id,
                        (ejdlc, r) => new { ejdlc.e, ejdlc.j, ejdlc.d, ejdlc.l, ejdlc.c, r })
                    .Select(x => new
                    {
                        id = x.e.Id,
                        fullName = $"{x.e.FirstName} {x.e.LastName}",
                        email = x.e.Email,
                        phone = x.e.PhoneNumber,
                        salary = x.e.Salary,
                        department_Name = x.d.Name,
                        streetAddress = x.l.StreetAddress,
                        countryName = x.c.Name,
                        regionName = x.r.Name
                    }).Take(limit).ToList();


            foreach (var employe in linq)
            {
                Console.WriteLine($"Id: {employe.id}");
                Console.WriteLine($"Full Name: {employe.fullName}");
                Console.WriteLine($"Email: {employe.email}");
                Console.WriteLine($"Phone: {employe.phone}");
                Console.WriteLine($"Salary: {employe.salary}");
                Console.WriteLine($"Department Name: {employe.department_Name}");
                Console.WriteLine($"Street Address: {employe.streetAddress}");
                Console.WriteLine($"Country Name: {employe.countryName}");
                Console.WriteLine($"Region Name: {employe.regionName}");
                Console.WriteLine();
            }
            Console.ReadKey();
            MenuUtama.FirstMenu();
        }
        public void GetDepartments()
        {
            var employees = (from e in employee.GetAllEmployee()
                             join d in department.GetAllDepartment() on e.DepartmentId equals d.Id
                             group e by new { d.Name, e.DepartmentId }
                             into g
                             where g.Count() > 3
                             select new
                             {
                                 departmentName = g.Key.Name,
                                 totalEmployee = g.Count(),
                                 minSalary = g.Min(e => e.Salary),
                                 maxSalary = g.Max(e => e.Salary),
                                 averageSalary = g.Average(e => e.Salary)
                             }).ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine($"Department Name: {employee.departmentName}");
                Console.WriteLine($"Total Employee: {employee.totalEmployee}");
                Console.WriteLine($"Min Salary: {employee.minSalary}");
                Console.WriteLine($"Max Salary: {employee.maxSalary}");
                Console.WriteLine($"Average Salary: {employee.averageSalary}");
                Console.WriteLine();
            }
        Console.ReadKey();
        MenuUtama.FirstMenu();
        }

    }
}
