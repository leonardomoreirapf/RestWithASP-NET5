using RestWithASP.Model;
using System.Collections.Generic;

namespace RestWithASP.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book FindById(long id);
        IEnumerable<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
    }
}
