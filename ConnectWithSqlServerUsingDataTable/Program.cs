using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWithSqlServerUsingDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person = person.GetPersonById(2);
            Gender gender = new Gender();
            List<Gender> genders = gender.GetGenders();
            Country country = new Country();
            List<Country> countries = country.GetCountry();
            Country.AddCountry(6, "Algeria");
            Country.AddCountry(7, "Dubai");
            PersonAddress personAddress = new PersonAddress();
            List<PersonAddress> personAddresses = personAddress.GetPersonAddress();
            State state = new State();
            List<State> states = state.GetState();

            //DataRepository.ExecuteDataTable("spPersonDetails");
            Console.Read();
        }
    }
}
