using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWithSqlServerUsingDataTable
{
   public  class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
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
        public static void AddCountry(int CountryId,string CountryName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString;
            string insert = "SET IDENTITY_INSERT Country ON; Insert into Country(CountryId,Country) values(@CountryId,@Country); SET IDENTITY_INSERT Country OFF;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(insert, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@CountryId", SqlDbType.Int).Value = CountryId;
            sqlCommand.Parameters.Add("@Country", SqlDbType.NVarChar).Value= CountryName;
            try
            {
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Record Added Successfully!!");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
