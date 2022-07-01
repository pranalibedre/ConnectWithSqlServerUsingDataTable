using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Gender
    {
        public string GenderName { get; set; }
        public int GenderId { get; set; }
        public Person Person { get; set; }

    }
}
