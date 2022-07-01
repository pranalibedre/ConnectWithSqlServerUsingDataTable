using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CountryRepository : ICountryRepository
    {
        public List<Country> GetCountry()
        {
            DataTable dataTable = DataRepository.ExecuteDataTable("spGetCountries");
            var listCountries = new List<Country>();
            Console.WriteLine("Country Details");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Country country = new Country();
                country.CountryId = Convert.ToInt16(dataTable.Rows[i]["CountryId"]);
                country.CountryName = Convert.ToString(dataTable.Rows[i]["Country"]);
                listCountries.Add(country);
            }

            foreach (var list in listCountries)
            {
                Console.WriteLine("\t{0}\t{1}", list.CountryId, list.CountryName);
            }
            return listCountries;
        }

        public void AddCountry(string Country)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("spAddCountry", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@Country", SqlDbType.NVarChar).Value = Country;
            try
            {
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Added successfully");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
