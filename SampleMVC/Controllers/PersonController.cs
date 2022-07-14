using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Entities;
using Interfaces;
using Repository;
using SampleMVC.Models;

namespace SampleMVC.Controllers
{
    public class PersonController : Controller
    {
       [CustomAuthorize]
        public ActionResult List()
        {
            List<Person> getPersonDetails = new List<Person>();
            IPersonRepository personRepository = new PersonRepository();
            getPersonDetails = personRepository.GetPerson();

            List<PersonContext> peopleContext = new List<PersonContext>();
            foreach (var person in getPersonDetails)
            {
                var personContext = new PersonContext();
                personContext.PersonId = person.PersonId;
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
            return View("List",peopleContext);
        }
     
        public ActionResult Add(int? personId)
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
            return View("Add",personContext);
        }
        //public ActionResult Add(string personId)
        //{
        //    var personContext = new PersonContext();
        //    if (personId != null)
        //    {
        //        IPersonRepository personRepository = new PersonRepository();
        //        var person = personRepository.GetPersonById(Convert.ToInt16(personId));
        //        personContext.FirstName = person.FirstName;
        //        personContext.LastName = person.LastName;
        //        personContext.Gender = person.Gender.GenderName;
        //        personContext.Age = person.Age;
        //        personContext.Email = person.Email;
        //        personContext.DateOfBirth = Convert.ToDateTime(person.DateOfBirth);
        //        personContext.TelephoneNo = person.TelephoneNo;
        //        personContext.AddressLine1 = person.PersonAddress.AddressLine1;
        //        personContext.AddressLine2 = person.PersonAddress.AddressLine2;
        //        personContext.City = person.PersonAddress.City;
        //        personContext.PinCode = person.PersonAddress.PinCode;
        //        personContext.SelectedCountry = person.Country.CountryName;
        //        personContext.SelectedState = person.State.StateName;
        //    }
        //    return View("Add", personContext);
        //}

        [HttpPost]
        public ActionResult Add(PersonContext personContext)
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

        public class CustomAuthorize : AuthorizeAttribute
        {
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
    
            }
        }

        public PartialViewResult _List()
        {
            return PartialView();
        }

        //public ActionResult Details(int personId)
        //{
        //    IPersonRepository personRepository = new PersonRepository();
        //    var person = personRepository.GetPersonById(personId);
        //    var personContext = new PersonContext();
        //    personContext.FirstName = person.FirstName;
        //    personContext.LastName = person.LastName;
        //    personContext.Gender = person.Gender.GenderName;
        //    personContext.Age = person.Age;
        //    personContext.Email = person.Email;
        //    personContext.DateOfBirth = Convert.ToDateTime(person.DateOfBirth);
        //    personContext.TelephoneNo = person.TelephoneNo;
        //    personContext.AddressLine1 = person.PersonAddress.AddressLine1;
        //    personContext.AddressLine2 = person.PersonAddress.AddressLine2;
        //    personContext.City = person.PersonAddress.City;
        //    personContext.PinCode = person.PersonAddress.PinCode;
        //    personContext.SelectedCountry = person.Country.CountryName;
        //    //personContext.SelectedState = person.State.StateName;
        //    return View("Details", personContext);
        //}
    }
}


































