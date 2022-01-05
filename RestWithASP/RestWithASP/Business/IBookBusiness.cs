using RestWithASP.Data.VO;
using RestWithASP.Model;
using System.Collections.Generic;

namespace RestWithASP.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        IEnumerable<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
