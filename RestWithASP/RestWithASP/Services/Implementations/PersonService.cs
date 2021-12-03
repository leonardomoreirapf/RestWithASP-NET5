using RestWithASP.Model;
using RestWithASP.Model.Context;
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
        private MySqlContext _context;
        public PersonService(MySqlContext context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public IEnumerable<Person> FindAll()
        {
    
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();
            
            var result =  _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if(result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
           

            return person;
        }

        private bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
