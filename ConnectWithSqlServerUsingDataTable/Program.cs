using System;
using System.Collections.Generic;
using Repository;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entities;

namespace ConnectWithSqlServerUsingDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            IPersonRepository personRepository = new PersonRepository();
            personRepository.GetPersonById(1);

            IPersonAddressRepository personAddressRepository = new PersonAddressRepository();
            personAddressRepository.GetPersonAddress();

            IGenderRepository genderRepository = new GenderRepository();
            genderRepository.GetGenders();

            ICountryRepository countryRepository = new CountryRepository();
            countryRepository.AddCountry("");


            //Repository.PersonHelper personHelper = new PersonHelper();
            //personHelper.GetPersonById(2);
  

            //Person person = new Person();
            //person.FirstName = "Devi";
            //person.LastName = "Vishvkumar";
            //person.Gender = new Gender
            //{
            //    GenderName = "female"
            //};
            //person.DateOfBirth = Convert.ToDateTime("1999/08/10");
            //person.Age = 22;
            //person.Email = "devi@gmail.com";
            //person.TelephoneNo = 8756433423;
            //person.PersonAddress = new PersonAddress
            //{
            //    AddressLine1 = "Rustom park",
            //    AddressLine2 = "3A wing",
            //    PinCode = 89890,
            //    City = "Ludhiana"
            //};
            //person.Country = new Country
            //{
            //    CountryName = "India"
            //};
            //person.State = new State
            //{
            //    StateName = "Punjab"
            //};
            ////personHelper.AddPerson(person);
            //Person uPerson = new Person();
            //uPerson.PersonId = 5;
            //uPerson.FirstName = "Rahul";
            //uPerson.LastName = "Roy";
            //uPerson.Gender = new Gender
            //{
            //    GenderName = "male"
            //};
            //uPerson.Email = "roy@yahoo.com";
            //uPerson.DateOfBirth= Convert.ToDateTime("2001/07/07");
            //uPerson.Age = 20;
            //uPerson.TelephoneNo = 7765438790;
            //uPerson.PersonAddress = new PersonAddress
            //{
            //    AddressLine1 = "beverly hills",
            //    AddressLine2 = "room no 501",
            //    PinCode = 90110,
            //    City = "Cape Town"
            //};
            //uPerson.Country = new Country
            //{
            //    CountryName = "South Africa"
            //};
            //uPerson.State = new State
            //{
            //    StateName = "Gauteng"
            //};
            //personHelper.UpdatePerson(uPerson);

            //GenderHelper genderHelper = new GenderHelper();
            //Gender gender = new Gender();
            //List<Gender> genders = genderHelper.GetGenders();

            //CountryHelper countryHelper = new CountryHelper();
            //Country country = new Country();
            //List<Country> countries = countryHelper.GetCountry();
            //countryHelper.AddCountry("Argentina");

            //PersonAddressHelper personAddressHelper = new PersonAddressHelper();
            //PersonAddress personAddress = new PersonAddress();
            //List<PersonAddress> personAddresses = personAddressHelper.GetPersonAddress();

            //StateHelper stateHelper = new StateHelper();
            //State state = new State();
            //List<State> states = stateHelper.GetState();


            Console.Read();
        }
    }
}
