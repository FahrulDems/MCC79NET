using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int ManagerId { get; set; }      

        public List<Department> GetAllDepartment()
        {
            List<Department> departments = new List<Department>();
            //var departments = new List<Department>();
            try
            {

                // instance command
                SqlCommand command = new SqlCommand();
                command.Connection = Koneksi.Get();
                command.CommandText = "SELECT * FROM tb_m_departments";

                // membuat koneksi
                Koneksi.Get();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var dep = new Department();
                        dep.Id = reader.GetInt32(0);
                        dep.Name = reader.GetString(1);
                        dep.LocationId = reader.GetInt32(2);
                        dep.ManagerId = reader.GetInt32(3);

                        departments.Add(dep);
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            /*foreach (Department department in departments)
            {
                Console.WriteLine($"Id : {department.Id}, Nama : {department.Name}, Location Id : {department.LocationId}, Manager Id : {department.ManagerId}");
            }*/
            Koneksi.Get().Close();
            return departments;
        }
        public void GetDepartment()
        {
            Department dep = new Department();
            var departments = new List<Department>();
            departments = dep.GetAllDepartment();
            foreach (Department department in departments)
            {
                Console.WriteLine($"Id : {department.Id}, Nama : {department.Name}, Location Id : {department.LocationId}, Manager Id : {department.ManagerId}");
            }
        }
    }
}
