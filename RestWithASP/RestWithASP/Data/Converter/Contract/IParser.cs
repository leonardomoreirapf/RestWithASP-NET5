using System.Collections.Generic;

namespace RestWithASP.Data.Converter.Contract
{
    public interface IParser<O,D>
    {
        D Parse(O origin);
        IEnumerable<D> Parse(IEnumerable<O> origin);
    }
}
