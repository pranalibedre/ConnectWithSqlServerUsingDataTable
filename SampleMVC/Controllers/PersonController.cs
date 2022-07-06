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
  
        public ActionResult Main()
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
                //personContext.Gender = new Gender
                //{
                //    GenderName = personContext.Gender
                //};
                personContext.Age = person.Age;
                personContext.Email = person.Email;
                personContext.DateOfBirth = Convert.ToDateTime(person.DateOfBirth);
                personContext.TelephoneNo = person.TelephoneNo;
                //personContext.PersonAddress = new PersonAddress
                //{
                //    AddressLine1 = personContext.AddressLine1,
                //    AddressLine2 = personContext.AddressLine2,
                //    City = personContext.City,
                //    PinCode = personContext.PinCode
                //};
                //personContext.Country = new Country
                //{
                //    CountryName = personContext.SelectedCountry
                //};
                //personContext.State = new State
                //{
                //    StateName = personContext.SelectedState
                //};
                peopleContext.Add(personContext);
            }
            return View(peopleContext);
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(PersonContext personContext)
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

            return View();
        }

    }
}