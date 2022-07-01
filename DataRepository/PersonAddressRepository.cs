using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PersonAddressRepository : IPersonAddressRepository
    {
        public List<PersonAddress> GetPersonAddress()
        {
            DataTable dataTable = DataRepository.ExecuteDataTable("spGetPersonAddress");
            var listAddress = new List<PersonAddress>();
            Console.WriteLine("Address Details");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                PersonAddress personAddress = new PersonAddress();
                personAddress.AddressId = Convert.ToInt16(dataTable.Rows[i]["PersonAddressId"]);
                personAddress.AddressLine1 = Convert.ToString(dataTable.Rows[i]["AddressLine1"]);
                personAddress.AddressLine2 = Convert.ToString(dataTable.Rows[i]["AddressLine2"]);
                personAddress.City = Convert.ToString(dataTable.Rows[i]["City"]);
                personAddress.PinCode = Convert.ToInt32(dataTable.Rows[i]["PinCode"]);
                personAddress.Country = new Country
                {
                    CountryId = Convert.ToInt16(dataTable.Rows[i]["CountryId"])
                };
                personAddress.State = new State
                {
                    StateId = Convert.ToInt16(dataTable.Rows[i]["StateId"])
                };
                personAddress.Person = new Person
                {
                    PersonId = Convert.ToInt16(dataTable.Rows[i]["PersonId"])
                };

                listAddress.Add(personAddress);
            }

            foreach (var list in listAddress)
            {
                Console.WriteLine($"{list.AddressId}\t{list.Person.PersonId}\t{list.AddressLine1}\t{list.AddressLine2}\t{list.City}\t{list.Country.CountryId}\t{list.State.StateId}\t{list.PinCode}");
            }

            return listAddress;
        }
    }
}
