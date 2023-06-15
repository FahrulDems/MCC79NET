using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        public decimal Commision { get; set; }
        public int ManagerId { get; set; }
        public string JobId { get; set; }
        public int DepartmentId { get; set; }

        public List<Employee> GetAllEmployee()
        {
            //var employees = new List<Employee>();
            List<Employee> employees = new List<Employee>();
            try
            {

                // instance command
                SqlCommand command = new SqlCommand();
                command.Connection = Koneksi.Get();
                command.CommandText = "SELECT * FROM tb_m_employees";

                // membuat koneksi
                Koneksi.Get();                
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var emp = new Employee();
                        emp.Id = reader.GetInt32(0);
                        emp.FirstName = reader.GetString(1);
                        emp.LastName = reader.GetString(2);
                        emp.Email = reader.GetString(3);
                        emp.PhoneNumber = reader.GetString(4);
                        emp.HireDate = reader.GetDateTime(5);
                        emp.Salary = reader.GetInt32(6);
                        emp.Commision = reader.GetDecimal(7);
                        emp.ManagerId = reader.GetInt32(8);
                        emp.JobId = reader.GetString(9);
                        emp.DepartmentId = reader.GetInt32(10);

                        employees.Add(emp);
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
            /*foreach (Employee employee in employees)
            {
                Console.WriteLine($"Id : {employee.Id}, First Name : {employee.FirstName}, Last Name : {employee.LastName}, Email : {employee.Email}, Phone Number : {employee.PhoneNumber}, Hire Date : {employee.HireDate}, Salary : {employee.Salary}, Commision : {employee.Commision}, Manager Id : {employee.ManagerId}, Job Id : {employee.JobId}, Department Id : {employee.DepartmentId}");
            }*/
            Koneksi.Get().Close();
            return employees;
        }
        public void GetEmployee()
        {
            Employee emp = new Employee();
            var employees = new List<Employee>();
            employees = emp.GetAllEmployee();
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"Id : {employee.Id}, First Name : {employee.FirstName}, Last Name : {employee.LastName}, Email : {employee.Email}, Phone Number : {employee.PhoneNumber}, Hire Date : {employee.HireDate}, Salary : {employee.Salary}, Commision : {employee.Commision}, Manager Id : {employee.ManagerId}, Job Id : {employee.JobId}, Department Id : {employee.DepartmentId}");
            }
        }
    }
}

