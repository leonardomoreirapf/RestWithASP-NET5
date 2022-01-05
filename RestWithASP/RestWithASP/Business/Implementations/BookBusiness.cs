using RestWithASP.Data.Converter.Contract;
using RestWithASP.Data.VO;
using RestWithASP.Model;
using RestWithASP.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASP.Business.Implementations
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly IBookConverter _converter;

        public BookBusiness(IRepository<Book> repository, IBookConverter converter)
        {
            _repository = repository;
            _converter = converter;
        }
        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            var result = _repository.Create(bookEntity);
            var response = _converter.Parse(result);
            return response;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<BookVO> FindAll()
        {
            var result = _repository.FindAll();
            var response = _converter.Parse(result);
            return response;
        }

        public BookVO FindById(long id)
        {
            var result = _repository.FindById(id);
            var response = _converter.Parse(result);
            return response;
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            var result = _repository.Update(bookEntity);
            var response = _converter.Parse(result);
            return response;
        }
    }
}
