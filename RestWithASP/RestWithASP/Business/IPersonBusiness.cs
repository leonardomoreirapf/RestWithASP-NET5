using RestWithASP.Model;
using System.Collections.Generic;

namespace RestWithASP.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(long id);
        IEnumerable<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
