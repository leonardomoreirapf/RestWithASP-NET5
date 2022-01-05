using RestWithASP.Data.VO;
using RestWithASP.Model;
using System.Collections.Generic;

namespace RestWithASP.Data.Converter.Contract
{
    public interface IBookConverter
    {
        Book Parse(BookVO origin);
        BookVO Parse(Book origin);
        IEnumerable<BookVO> Parse(IEnumerable<Book> origin);
        IEnumerable<Book> Parse(IEnumerable<BookVO> origin);
    }
}
