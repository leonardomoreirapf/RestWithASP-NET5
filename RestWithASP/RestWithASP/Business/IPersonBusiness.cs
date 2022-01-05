using RestWithASP.Data.VO;
using RestWithASP.Model;
using System.Collections.Generic;

namespace RestWithASP.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        IEnumerable<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
