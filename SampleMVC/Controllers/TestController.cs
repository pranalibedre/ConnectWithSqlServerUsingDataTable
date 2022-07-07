using Entities;
using Interfaces;
using Repository;
using SampleMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVC.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPerson()
        {
            return View("Person");
        }

        public ActionResult Detail()
        {
            return View("Person");
        }

        public ActionResult Update()
        {
            return View("Person");
        }

        public ActionResult Person(int? personId)
        {
            var personContext = new PersonContext();
            if (personId != null && personId > 0)
            {
                IPersonRepository personRepository = new PersonRepository();
                var person = personRepository.GetPersonById(personId.Value);
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
            }
            return View("Person", personContext);
        }

        [HttpPost]
        public ActionResult SavePerson(PersonContext personContext)
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
            if (person.PersonId > 0)
            {
                personRepository.UpdatePerson(person);
            }
            else
            {
                personRepository.AddPerson(person);
            }

            TempData["AlertMessage"] = "Record Added Successfully";

            return RedirectToAction("List", "Person");
        }

    }
}