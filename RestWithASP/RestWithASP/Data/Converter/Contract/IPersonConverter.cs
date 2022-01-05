using RestWithASP.Data.VO;
using RestWithASP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.Data.Converter.Contract
{
    public interface IPersonConverter
    {
        Person Parse(PersonVO origin);
        PersonVO Parse(Person origin);
        IEnumerable<PersonVO> Parse(IEnumerable<Person> origin);
        IEnumerable<Person> Parse(IEnumerable<PersonVO> origin);
    }
}
