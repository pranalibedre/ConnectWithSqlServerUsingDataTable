using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataRepository;
using System.Web.Routing;
using Entities;
using Interfaces;
using Repository;
using SampleMVC.Models;

namespace SampleMVC.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public ActionResult List()
        {
            List<Person> getPersonDetails = new List<Person>();
            //IPersonRepository personRepository = new PersonOracleReporstory();
            getPersonDetails = _personRepository.GetPerson();

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
            return View("List", peopleContext);
        }

        public ActionResult AjaxList()
        {
            return PartialView("_List", _personRepository.GetPerson().Take(5).ToList());
            //return Json(_personRepository.GetPerson().Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add(int? personId)
        {
            var personContext = new PersonContext();
            if (personId != null && personId > 0)
            {
                //IPersonRepository personRepository = new PersonOracleReporstory();
                var person = _personRepository.GetPersonById(personId.Value);
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
            return View("Add", personContext);
        }

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
            //IPersonRepository personRepository = new PersonRepository();

            if (person.PersonId > 0)
            {
                _personRepository.UpdatePerson(person);
            }
            else
            {
                _personRepository.AddPerson(person);
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

        public JsonResult Details()
        {
            //IPersonRepository personRepository = new PersonRepository();
            //var person = personRepository.GetPersonById(personId);
            //var personContext = new PersonContext();
            //personContext.FirstName = person.FirstName;
            //personContext.LastName = person.LastName;
            //personContext.Gender = person.Gender.GenderName;
            //personContext.Age = person.Age;
            //personContext.Email = person.Email;
            //personContext.DateOfBirth = Convert.ToDateTime(person.DateOfBirth);
            //personContext.TelephoneNo = person.TelephoneNo;
            //personContext.AddressLine1 = person.PersonAddress.AddressLine1;
            //personContext.AddressLine2 = person.PersonAddress.AddressLine2;
            //personContext.City = person.PersonAddress.City;
            //personContext.PinCode = person.PersonAddress.PinCode;
            //personContext.SelectedCountry = person.Country.CountryName;
            ////personContext.SelectedState = person.State.StateName;
            //return View("Details", personContext);

            return Json(_personRepository.GetPerson(), JsonRequestBehavior.AllowGet);
        }
    }
}


































