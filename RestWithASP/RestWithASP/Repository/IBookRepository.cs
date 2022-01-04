using RestWithASP.Model;
using System.Collections.Generic;

namespace RestWithASP.Repository
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book FindById(long id);
        IEnumerable<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
        bool Exists(long id);
    }
}
