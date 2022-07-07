using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVC.Models
{
    public class PersonContext
    {
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Please enter your First Name")]
        [Display(Name = "First Name: ")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "First Name should contain only characters")]
        [StringLength(maximumLength: 10, MinimumLength = 2, ErrorMessage = "Last Name must be min 2 & max 10")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        [Display(Name = "Last Name: ")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Last Name should contain only characters")]
        [StringLength(maximumLength: 10, MinimumLength = 2, ErrorMessage = "Last Name must be min 2 & max 10")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        [Display(Name = "Gender: ")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter your age")]
        [Display(Name = "Age: ")]
        [Range(18, 100)]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter your Date of Birth")]
        [Display(Name = "Date of Birth: (yyyy/mm/dd)")]
        [DataType(DataType.DateTime)]
        //[RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter your Email Id")]
        [Display(Name = "Email Id: ")]
        [RegularExpression(@"^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$", ErrorMessage = "Enter Valid Email Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Telephone No")]
        [Display(Name = "Telephone No: ")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Not a valid phone number")]
        public long TelephoneNo { get; set; }

        //[Required(ErrorMessage = "Please select your country")]
        //[Display(Name = "Country: ")]
        //public List<SelectListItem> CountryList { get; set; }

        [Required(ErrorMessage = "Please select your country")]
        [Display(Name = "Country: ")]
        public CountryNames CountryList { get; set; }
        public string SelectedCountry { get; set; }
        public enum CountryNames
        {
            India,
            USA,
            Dubai,
            Malaysia,
            SouthAfrica,
            SriLanka,
            China,
            Argentina
        }

        [Required(ErrorMessage = "Please select your State")]
        [Display(Name = "State: ")]
        public StateNames StateName { get; set; }
        public string SelectedState { get; set; }

        public enum StateNames
        {
            Maharashtra,
            Punjab,
            Ludhiana,
            Kedah,
            UvaProvince,
            CentralProvince,
            California,
            Texas,
            Gauteng,
            NorthenCape
        }

        [Required(ErrorMessage = "Please enter your aAddress Line 1")]
        [Display(Name = "Address Line 1: ")]
        //[StringLength(200)]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage = "Please enter your Address Line 2")]
        [Display(Name = "Address Line 2: ")]
        //[StringLength(200)]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter your City")]
        [Display(Name = "City: ")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Pincode")]
        [Display(Name = "Pincode: ")]
        //[StringLength(10, MinimumLength = 5)]
        public int PinCode { get; set; }
    }
}