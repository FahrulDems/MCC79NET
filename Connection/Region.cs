using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace Connection
{       
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Region> GetAllRegion()
        {
            var regions = new List<Region>();
            //List<Region> regions = new List<Region>(); 
            try
            {

                // instance command
                SqlCommand command = new SqlCommand();
                command.Connection = Koneksi.Get();
                command.CommandText = "SELECT * FROM tb_m_regions";

                // membuat koneksi
                Koneksi.Get();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var reg = new Region();
                        reg.Id = reader.GetInt32(0);
                        reg.Name = reader.GetString(1);

                        regions.Add(reg);
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
            /*foreach (Region region in regions)
            {
                Console.WriteLine($"id : {region.Id}, nama : {region.Name}");
            }
            Koneksi.Get().Close();*/
            return regions;
        }        
        public static List<Region> GetByIdRegion()
        {
            var regiongetbyid = new List<Region>();
            try
            {
                Console.Write("Masukan Id Yang Ingin Didapatkan Dari Data Tabel Region : ");
                int insertid = Convert.ToInt32(Console.ReadLine());
                string com = "SELECT * FROM tb_m_regions WHERE id = " + insertid;
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
                        var reg = new Region();
                        reg.Id = reader.GetInt32(0);
                        reg.Name = reader.GetString(1);

                        regiongetbyid.Add(reg);
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
            foreach (Region region in regiongetbyid)
            {
                Console.WriteLine($"id : {region.Id}, nama : {region.Name}");
            }
            Koneksi.Get().Close();
            
            return regiongetbyid;
        }
        public static int InsertRegion(String nama)
        {
            int result = 0;
            Koneksi.connection2.Open();
            SqlTransaction transaction = Koneksi.connection2.BeginTransaction();
            try
            {

                SqlCommand command = new SqlCommand();
                command.Connection = Koneksi.connection2;
                command.CommandText = "Insert Into tb_m_regions (nama) VALUES (@region_nama)";
                command.Transaction = transaction;

                SqlParameter pNama = new SqlParameter();
                pNama.ParameterName = "@region_nama";
                pNama.Value = nama;
                pNama.SqlDbType = SqlDbType.VarChar;

                command.Parameters.Add(pNama);
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
        public static int UpdateRegion(int id, String nama)
        {
            int result = 0;
            Koneksi.connection2.Open();
            SqlTransaction transaction = Koneksi.connection2.BeginTransaction();
            try
            {

                SqlCommand command = new SqlCommand();
                command.Connection = Koneksi.connection2;
                command.CommandText = "UPDATE tb_m_regions SET nama = @regionn WHERE id = @regioni";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@regioni";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pId);

                SqlParameter pNama = new SqlParameter();
                pNama.ParameterName = "@regionn";
                pNama.Value = nama;
                pNama.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(pNama);

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
        public static int DeleteRegion(int id)
        {
            int result = 0;
            Koneksi.connection2.Open();
            SqlTransaction transaction = Koneksi.connection2.BeginTransaction();
            try
            {

                SqlCommand command = new SqlCommand();
                command.Connection = Koneksi.connection2;
                command.CommandText = "DELETE FROM tb_m_regions WHERE id = @idD";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@idD";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
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
