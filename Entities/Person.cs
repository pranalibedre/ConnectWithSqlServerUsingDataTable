using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public long TelephoneNo { get; set; }
        public PersonAddress PersonAddress { get; set; }
        public Gender Gender { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
     
    }
}
