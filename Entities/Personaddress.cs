using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PersonAddress
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int PinCode { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public Person Person { get; set; }
      
    }
}
