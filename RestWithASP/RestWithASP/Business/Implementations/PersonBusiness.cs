using RestWithASP.Data.Converter.Contract;
using RestWithASP.Data.VO;
using RestWithASP.Model;
using RestWithASP.Model.Context;
using RestWithASP.Repository;
using RestWithASP.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASP.Business.Implementations
{
    public class PersonBusiness : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        private readonly IPersonConverter _converter;
        public PersonBusiness(IRepository<Person> repository, IPersonConverter converter)
        {
            _repository = repository;
            _converter = converter;
        }
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            var result = _repository.Create(personEntity);
            var response = _converter.Parse(result);
            return response;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);

        }

        public IEnumerable<PersonVO> FindAll()
        {
            var result = _repository.FindAll();
            var response = _converter.Parse(result);
            return response;
        }

        public PersonVO FindById(long id)
        {
            var result = _repository.FindById(id);
            var response = _converter.Parse(result);
            return response;
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            var result = _repository.Update(personEntity);
            var response = _converter.Parse(result);
            return response;
        }
    }
}
