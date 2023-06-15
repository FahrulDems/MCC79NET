using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        public List<Country> GetAllCountry()
        {
            List<Country> countrys = new List<Country>();
            //var countrys = new List<Country>();
            try
            {

                // instance command
                SqlCommand command = new SqlCommand();
                command.Connection = Koneksi.Get();
                command.CommandText = "SELECT * FROM tb_m_countries";

                // membuat koneksi
                Koneksi.Get();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var con = new Country();
                        con.Id = reader.GetString(0);
                        con.Name = reader.GetString(1);
                        con.RegionId = reader.GetInt32(2);

                        countrys.Add(con);
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
            /*foreach (Country country in countrys)
            {
                Console.WriteLine($"id : {country.Id}, nama : {country.Name},\t region_id : {country.RegionId}");
            }*/
            Koneksi.Get().Close();
            return countrys;
        }
        public static List<Country> GetByIdCountry()
        {
            var countrygetbyid = new List<Country>();
            try
            {
                Console.Write("Masukan Id Yang Ingin Didapatkan Dari Data Tabel Country : ");
                int insertid = Convert.ToInt32(Console.ReadLine());
                string com = "SELECT * FROM tb_m_countries WHERE id = " + insertid;
                // instance command
                SqlCommand command = new SqlCommand();
                command.Connection = Koneksi.Get();
                command.CommandText = com;

                // membuat koneksi
                Koneksi.Get();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var con = new Country();
                        con.Id = reader.GetString(0);
                        con.Name = reader.GetString(1);
                        con.RegionId = reader.GetInt32(2);

                        countrygetbyid.Add(con);
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
            foreach (Country country in countrygetbyid)
            {
                Console.WriteLine($"Id : {country.Id}, Nama : {country.Name}, Region Id : {country.RegionId}");
            }
            Koneksi.Get().Close();
            return countrygetbyid;
        }
        public static int InsertCountry(String id,String nama,int regionid)
        {
            int result = 0;
            Koneksi.connection2.Open();
            SqlTransaction transaction = Koneksi.connection2.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Koneksi.connection2;
                command.CommandText = "INSERT INTO tb_m_countries (id, nama, region_id) VALUES (@id, @nama, @region_id)";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter("@id", SqlDbType.VarChar);
                pId.Value = id;
                command.Parameters.Add(pId);

                SqlParameter pNama = new SqlParameter("@nama", SqlDbType.VarChar);
                pNama.Value = nama;
                command.Parameters.Add(pNama);

                SqlParameter pManId = new SqlParameter("@region_id", SqlDbType.Int);
                pManId.Value = regionid;
                command.Parameters.Add(pManId);

                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }            
            Koneksi.connection2.Close();
            return result;
        }
        public static int UpdateCountry(String id, String nama, int regionid)
        {
            int result = 0;
            Koneksi.connection2.Open();
            SqlTransaction transaction = Koneksi.connection2.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Koneksi.connection2;
                command.CommandText = "UPDATE tb_m_countries SET nama = @namaU, region_id = @region_idU WHERE id = @idU";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter("@idU", SqlDbType.VarChar);
                pId.Value = id;
                command.Parameters.Add(pId);

                SqlParameter pNama = new SqlParameter("@namaU", SqlDbType.VarChar);
                pNama.Value = nama;
                command.Parameters.Add(pNama);

                SqlParameter pManId = new SqlParameter("@region_idU", SqlDbType.Int);
                pManId.Value = regionid;
                command.Parameters.Add(pManId);

                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            Koneksi.connection2.Close();
            return result;
        }
        public static int DeleteCountry(string id)
        {
            int result = 0;
            Koneksi.connection2.Open();
            SqlTransaction transaction = Koneksi.connection2.BeginTransaction();
            try
            {

                SqlCommand command = new SqlCommand();
                command.Connection = Koneksi.connection2;
                command.CommandText = "DELETE FROM tb_m_countries WHERE id = @idD";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@idD";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Char;
                command.Parameters.Add(pId);

                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            Koneksi.connection2.Close();
            return result;
        }
    }
}
