using RestWithASP.Data.Converter.Contract;
using RestWithASP.Data.VO;
using RestWithASP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>,IPersonConverter
    {
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return null;

            return new Person()
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public PersonVO Parse(Person origin)
        {
            if (origin == null) return null;

            return new PersonVO()
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public IEnumerable<PersonVO> Parse(IEnumerable<Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(x => Parse(x));
        }

        public IEnumerable<Person> Parse(IEnumerable<PersonVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(x => Parse(x));
        }
    }
}
