using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
   public  interface ICountryRepository
    {
        List<Country> GetCountry();
        void AddCountry(string Country);
    }
}
