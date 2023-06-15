using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class Jobs
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int MaxSalary { get; set; }
        public int MinSalary { get; set; }

        public List<Jobs> GetAllJob()
        {
            List<Jobs> jobs = new List<Jobs>();
            /*var jobs = new List<Jobs>();*/
            try
            {

                // instance command
                SqlCommand command = new SqlCommand();
                command.Connection = Koneksi.Get();
                command.CommandText = "SELECT * FROM tb_m_jobs";

                // membuat koneksi
                Koneksi.Get();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var job = new Jobs();
                        job.Id = reader.GetString(0);
                        job.Title = reader.GetString(1);
                        job.MaxSalary = reader.GetInt32(2);
                        job.MinSalary = reader.GetInt32(3);

                        jobs.Add(job);
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
            /*foreach (Jobs job in jobs)
            {
                Console.WriteLine($"Id : {job.Id}, Title : {job.Title}, Max Salary : {job.MaxSalary}, Min Salary : {job.MinSalary}");
            }*/
            Koneksi.Get().Close();
            return jobs;
        }
        public void GetJob()
        {
            Jobs jo = new Jobs();
            var jobs = new List<Jobs>();
            jobs = jo.GetAllJob();
            foreach (Jobs job in jobs)
            {
                Console.WriteLine($"Id : {job.Id}, Title : {job.Title}, Max Salary : {job.MaxSalary}, Min Salary : {job.MinSalary}");
            }            
        }
    }
}
