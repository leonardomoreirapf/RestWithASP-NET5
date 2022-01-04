using RestWithASP.Model;
using RestWithASP.Repository;
using System.Collections.Generic;

namespace RestWithASP.Business.Implementations
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IBookRepository _repository;

        public BookBusiness(IBookRepository repository)
        {
            _repository = repository;
        }
        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
