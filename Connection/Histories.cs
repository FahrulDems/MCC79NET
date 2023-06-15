using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable enable
namespace Connection
{
    public class Histories
    {
        public DateTime MulaiDate { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? EndDate { get; set; }
        public int DepartmentId { get; set; }
        public string JobId { get; set; }

        public List<Histories> GetAllHistories()
        {
            List<Histories> histories = new List<Histories>();
            //var histories = new List<Histories>();
            try
            {

                // instance command
                SqlCommand command = new SqlCommand();
                command.Connection = Koneksi.Get();
                command.CommandText = "SELECT * FROM tb_tr_histories";

                // membuat koneksi
                Koneksi.Get();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var historie = new Histories();
                        historie.MulaiDate = reader.GetDateTime(0);
                        historie.EmployeeId = reader.GetInt32(1);
                        /*historie.EndDate = reader.GetDateTime(2);*/
                        if (reader.IsDBNull(2))
                        {
                            historie.EndDate = null; // Atur sebagai null jika nilainya null
                        }
                        else
                        {
                            historie.EndDate = reader.GetDateTime(2);
                        }
                        historie.DepartmentId = reader.GetInt32(3);
                        historie.JobId = reader.GetString(4);

                        histories.Add(historie);
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
            /*foreach (Histories historie in histories)
            {
                Console.WriteLine($"Mulai Date : {historie.MulaiDate}, Employee Id : {historie.EmployeeId}, End Date  : {(historie.EndDate.HasValue ? historie.EndDate.Value.ToString() : "NULL")}, Department Id : {historie.DepartmentId}, Job Id : {historie.JobId}");
            }*/
            Koneksi.Get().Close();
            return histories;
        }
        public void GetHistories()
        {
            Histories his = new Histories();
            var histories = new List<Histories>();
            histories = his.GetAllHistories();
            foreach (Histories historie in histories)
            {
                Console.WriteLine($"Mulai Date : {historie.MulaiDate}, Employee Id : {historie.EmployeeId}, End Date  : {(historie.EndDate.HasValue ? historie.EndDate.Value.ToString() : "NULL")}, Department Id : {historie.DepartmentId}, Job Id : {historie.JobId}");
            }
        }
    }
}

