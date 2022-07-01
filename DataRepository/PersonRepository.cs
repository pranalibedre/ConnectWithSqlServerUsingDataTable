using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PersonRepository : IPersonRepository
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString;

        public Person GetPersonById(int PersonId)
        {
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@PersonId";
            sqlParameter.SqlDbType = SqlDbType.Int;
            sqlParameter.Value = PersonId;
            DataTable dataTable = DataRepository.ExecuteDataTable("spGetPersonDetailsByID", sqlParameter);
            Person person = new Person();
            Console.WriteLine("Details By Passing Employee Id");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                person.PersonId = Convert.ToInt16(dataRow["PersonId"]);
                person.FirstName = Convert.ToString(dataRow["FirstName"]);
                person.LastName = Convert.ToString(dataRow["LastName"]);
                person.Age = Convert.ToInt16(dataRow["Age"]);
                person.DateOfBirth = Convert.ToDateTime(dataRow["DateOfBirth"]);
                person.Email = Convert.ToString(dataRow["Email"]);
                person.TelephoneNo = Convert.ToInt64(dataRow["TelephoneNo"]);
                person.Gender = new Gender
                {
                    GenderName = Convert.ToString(dataRow["Gender"])
                };
                person.PersonAddress = new PersonAddress
                {
                    AddressLine1 = Convert.ToString(dataRow["AddressLine1"]),
                    AddressLine2 = Convert.ToString(dataRow["AddressLine2"]),
                    City = Convert.ToString(dataRow["City"]),
                    PinCode = Convert.ToInt32(dataRow["PinCode"])
                };
                person.Country = new Country
                {
                    CountryName = Convert.ToString(dataRow["Country"])
                };

                Console.WriteLine($"{person.PersonId}\t{person.FirstName}\t{person.LastName}\t{person.Age}\t{person.Gender.GenderName}\t{person.DateOfBirth}\t{person.Email}\t{person.TelephoneNo}\t{person.PersonAddress.AddressLine1}\t{person.PersonAddress.AddressLine2}\t{person.PersonAddress.City}\t{person.Country.CountryName}\t{person.PersonAddress.PinCode}");

            }
            Console.WriteLine();
            return person;
        }
        public void AddPerson(Person person)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("spAddPerson", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = person.FirstName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = person.LastName;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = person.Gender.GenderName;
            sqlCommand.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = person.DateOfBirth;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = person.Age;
            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = person.Email;
            sqlCommand.Parameters.Add("@TelephoneNo", SqlDbType.BigInt).Value = person.TelephoneNo;
            sqlCommand.Parameters.Add("@AddressLine1", SqlDbType.NVarChar).Value = person.PersonAddress.AddressLine1;
            sqlCommand.Parameters.Add("@AddressLine2", SqlDbType.NVarChar).Value = person.PersonAddress.AddressLine2;
            sqlCommand.Parameters.Add("@City", SqlDbType.NVarChar).Value = person.PersonAddress.City;
            sqlCommand.Parameters.Add("@Country", SqlDbType.NVarChar).Value = person.Country.CountryName;
            sqlCommand.Parameters.Add("@State", SqlDbType.NVarChar).Value = person.State.StateName;
            sqlCommand.Parameters.Add("@Pincode", SqlDbType.BigInt).Value = person.PersonAddress.PinCode;

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@returnValue";
            sqlParameter.SqlDbType = SqlDbType.Int;
            sqlParameter.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter);

            try
            {

                int result = sqlCommand.ExecuteNonQuery();
                int PesonId = (int)sqlCommand.Parameters["@returnValue"].Value;
                if (PesonId > 0)
                {
                    Console.WriteLine(" Person Id: {0}", PesonId);
                }
                if (result > 0)
                {
                    Console.WriteLine("Added successfully");
                }
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

        public void UpdatePerson(Person person)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("UspGetPerson", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@PersonId", SqlDbType.Int).Value = person.PersonId;
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = person.FirstName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = person.LastName;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = person.Gender.GenderName;
            sqlCommand.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = person.DateOfBirth;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = person.Age;
            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = person.Email;
            sqlCommand.Parameters.Add("@TelephoneNo", SqlDbType.BigInt).Value = person.TelephoneNo;
            sqlCommand.Parameters.Add("@AddressLine1", SqlDbType.NVarChar).Value = person.PersonAddress.AddressLine1;
            sqlCommand.Parameters.Add("@AddressLine2", SqlDbType.NVarChar).Value = person.PersonAddress.AddressLine2;
            sqlCommand.Parameters.Add("@City", SqlDbType.NVarChar).Value = person.PersonAddress.City;
            sqlCommand.Parameters.Add("@Pincode", SqlDbType.BigInt).Value = person.PersonAddress.PinCode;
            sqlCommand.Parameters.Add("@Country", SqlDbType.NVarChar).Value = person.Country.CountryName;
            sqlCommand.Parameters.Add("@State", SqlDbType.NVarChar).Value = person.State.StateName;

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@ReturnValue";
            sqlParameter.SqlDbType = SqlDbType.Int;
            sqlParameter.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter);

            try
            {
                int result = sqlCommand.ExecuteNonQuery();
                int Id = (int)sqlCommand.Parameters["@ReturnValue"].Value;
                if (Id > 0)
                {
                    Console.WriteLine(" Person Id: {0}", Id);
                }
                if (result > 0)
                {
                    Console.WriteLine("Updated successfully");

                }

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
