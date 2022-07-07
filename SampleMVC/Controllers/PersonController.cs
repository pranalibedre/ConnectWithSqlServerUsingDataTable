using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Interfaces;
using Repository;
using SampleMVC.Models;

namespace SampleMVC.Controllers
{
    public class PersonController : Controller
    {

        public ActionResult List()
        {
            List<Person> getPersonDetails = new List<Person>();
            IPersonRepository personRepository = new PersonRepository();
            getPersonDetails = personRepository.GetPerson();

            List<PersonContext> peopleContext = new List<PersonContext>();
            foreach (var person in getPersonDetails)
            {
                var personContext = new PersonContext();
                personContext.FirstName = person.FirstName;
                personContext.LastName = person.LastName;
                personContext.Gender = person.Gender.GenderName;
                personContext.Age = person.Age;
                personContext.Email = person.Email;
                personContext.DateOfBirth = Convert.ToDateTime(person.DateOfBirth);
                personContext.TelephoneNo = person.TelephoneNo;
                personContext.AddressLine1 = person.PersonAddress.AddressLine1;
                personContext.AddressLine2 = person.PersonAddress.AddressLine2;
                personContext.City = person.PersonAddress.City;
                personContext.PinCode = person.PersonAddress.PinCode;
                personContext.SelectedCountry = person.Country.CountryName;
                personContext.SelectedState = person.State.StateName;
                peopleContext.Add(personContext);
            }
            return View(peopleContext);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(PersonContext personContext)
        {
            Person person = new Person();
            person.FirstName = personContext.FirstName;
            person.LastName = personContext.LastName;
            person.Gender = new Gender
            {
                GenderName = personContext.Gender
            };
            person.Age = personContext.Age;
            person.Email = personContext.Email;
            person.DateOfBirth = Convert.ToDateTime(personContext.DateOfBirth);
            person.TelephoneNo = personContext.TelephoneNo;
            person.PersonAddress = new PersonAddress
            {
                AddressLine1 = personContext.AddressLine1,
                AddressLine2 = personContext.AddressLine2,
                City = personContext.City,
                PinCode = personContext.PinCode
            };
            person.Country = new Country
            {
                CountryName = personContext.SelectedCountry
            };
            person.State = new State
            {
                StateName = personContext.SelectedState
            };

            IPersonRepository personRepository = new PersonRepository();
            personRepository.AddPerson(person);
            TempData["AlertMessage"] = "Record Added Successfully";

            return RedirectToAction("List", "Person");
        }

        public ActionResult Update(PersonContext personContext)
        {
            Person person = new Person();
            person.PersonId = personContext.PersonId;
            person.FirstName = personContext.FirstName;
            person.LastName = personContext.LastName;
            person.Gender = new Gender
            {
                GenderName = personContext.Gender
            };
            person.Age = personContext.Age;
            person.Email = personContext.Email;
            person.DateOfBirth = Convert.ToDateTime(personContext.DateOfBirth);
            person.TelephoneNo = personContext.TelephoneNo;
            person.PersonAddress = new PersonAddress
            {
                AddressLine1 = personContext.AddressLine1,
                AddressLine2 = personContext.AddressLine2,
                City = personContext.City,
                PinCode = personContext.PinCode
            };
            person.Country = new Country
            {
                CountryName = personContext.SelectedCountry
            };
            person.State = new State
            {
                StateName = personContext.SelectedState
            };

            IPersonRepository personRepository = new PersonRepository();
            personRepository.UpdatePerson(person);
            TempData["AlertMessage"] = "Record Updated Successfully";
            return RedirectToAction("List", "Person");
        }

        [HttpGet]
        public ActionResult Update(int personId)
        {
            IPersonRepository personRepository = new PersonRepository();
            var person = personRepository.GetPersonById(personId);
            var personContext = new PersonContext();
            personContext.FirstName = person.FirstName;
            personContext.LastName = person.LastName;
            personContext.Gender = person.Gender.GenderName;
            personContext.Age = person.Age;
            personContext.Email = person.Email;
            personContext.DateOfBirth = Convert.ToDateTime(person.DateOfBirth);
            personContext.TelephoneNo = person.TelephoneNo;
            personContext.AddressLine1 = person.PersonAddress.AddressLine1;
            personContext.AddressLine2 = person.PersonAddress.AddressLine2;
            personContext.City = person.PersonAddress.City;
            personContext.PinCode = person.PersonAddress.PinCode;
            personContext.SelectedCountry = person.Country.CountryName;
            personContext.SelectedState = person.State.StateName;
            return View("Update", personContext);
        }

        public ActionResult Details(int personId)
        {
            IPersonRepository personRepository = new PersonRepository();
            var person = personRepository.GetPersonById(personId);
            var personContext = new PersonContext();
            personContext.FirstName = person.FirstName;
            personContext.LastName = person.LastName;
            personContext.Gender = person.Gender.GenderName;
            personContext.Age = person.Age;
            personContext.Email = person.Email;
            personContext.DateOfBirth = Convert.ToDateTime(person.DateOfBirth);
            personContext.TelephoneNo = person.TelephoneNo;
            personContext.AddressLine1 = person.PersonAddress.AddressLine1;
            personContext.AddressLine2 = person.PersonAddress.AddressLine2;
            personContext.City = person.PersonAddress.City;
            personContext.PinCode = person.PersonAddress.PinCode;
            personContext.SelectedCountry = person.Country.CountryName;
            personContext.SelectedState = person.State.StateName;
            return View("Details", personContext);
        }
    }
}


































//public ActionResult Delete(string name)
//{
//    List<Person> getPersonDetails = new List<Person>();
//    IPersonRepository personRepository = new PersonRepository();
//    getPersonDetails = personRepository.GetPerson();
//    var result = getPersonDetails.Where(x => x.FirstName == name).First();
//    getPersonDetails.Remove(result);
//    return View();

//}