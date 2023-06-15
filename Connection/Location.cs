using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class Location
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryId { get; set; }

        public List<Location> GetAllLocation()
        {
            List<Location> locations = new List<Location>();
            //var locations = new List<Location>();
            try
            {

                // instance command
                SqlCommand command = new SqlCommand();
                command.Connection = Koneksi.Get();
                command.CommandText = "SELECT * FROM tb_m_locations";

                // membuat koneksi
                Koneksi.Get();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var loc = new Location();
                        loc.Id = reader.GetInt32(0);
                        loc.StreetAddress = reader.GetString(1);
                        loc.PostalCode = reader.GetString(2);
                        loc.City = reader.GetString(3);
                        loc.StateProvince = reader.GetString(4);
                        loc.CountryId = reader.GetString(5);

                        locations.Add(loc);
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
            /*foreach (Location location in locations)
            {
                Console.WriteLine($"Id : {location.Id}, Street Address : {location.StreetAddress}, Postal Code : {location.PostalCode}, City : {location.City}, Statae Province : {location.StateProvince}, Country Id : {location.CountryId}");
            }*/
            Koneksi.Get().Close();
            return locations;
        }
        public void GetLocation()
        {
            Location loc = new Location();
            var locations = new List<Location>();
            locations = loc.GetAllLocation();
            foreach (Location location in locations)
            {
                Console.WriteLine($"Id : {location.Id}, Street Address : {location.StreetAddress}, Postal Code : {location.PostalCode}, City : {location.City}, Statae Province : {location.StateProvince}, Country Id : {location.CountryId}");
            }
        }
    }
}
