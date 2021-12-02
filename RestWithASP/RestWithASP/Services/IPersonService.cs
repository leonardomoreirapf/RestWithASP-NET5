using RestWithASP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        IEnumerable<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
