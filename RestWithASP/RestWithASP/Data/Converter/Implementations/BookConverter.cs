using RestWithASP.Data.Converter.Contract;
using RestWithASP.Data.VO;
using RestWithASP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>, IBookConverter
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null) return null;

            return new Book()
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LauchDate = origin.LauchDate
            };
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;

            return new BookVO()
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LauchDate = origin.LauchDate
            };
        }

        public IEnumerable<BookVO> Parse(IEnumerable<Book> origin)
        {
            if (origin == null) return null;

            return origin.Select(x => Parse(x));
        }

        public IEnumerable<Book> Parse(IEnumerable<BookVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(x => Parse(x));
        }
    }
}
