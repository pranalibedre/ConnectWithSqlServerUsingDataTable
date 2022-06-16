using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWithSqlServerUsingDataTable
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public long TelephoneNo { get; set; }
        public PersonAddress PersonAddress { get; set; }
        public Gender Gender { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }

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
    }
}
