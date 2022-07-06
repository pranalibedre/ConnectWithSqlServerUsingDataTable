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
            Person person = new Person();
            getPersonDetails = personRepository.GetPerson();
            PersonContext personContext = new PersonContext();
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
            getPersonDetails.Add(person);

            return View(getPersonDetails);
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