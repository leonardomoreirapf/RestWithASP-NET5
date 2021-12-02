using RestWithASP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASP.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private volatile int _count;
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public IEnumerable<Person> FindAll()
        {
            var persons = new List<Person>();
            for(int i = 0; i<8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindById(long id)
        {
            return new Person {
                Id = IncrementeAndGet(),
                FirstName = "Leonardo",
                LastName = "Moreira",
                Address = "Rua dos Marceneiros n 14",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementeAndGet(),
                FirstName = $"Person Name {i}",
                LastName = $"Person LastName {i}",
                Address = $"Some Address {i}",
                Gender = i % 2 == 0 ? "Male" : "Female"
            };
        }

        private long IncrementeAndGet()
        {
            return Interlocked.Increment(ref _count);
        }
    }
}
