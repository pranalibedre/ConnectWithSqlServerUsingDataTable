using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPersonRepository
    {
        Person GetPersonById(int PersonId);
        List<Person> GetPerson();
        void AddPerson(Person person);
        void UpdatePerson(Person person);
    }

}

