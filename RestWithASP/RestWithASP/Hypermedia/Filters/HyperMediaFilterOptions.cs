using RestWithASP.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RestWithASP.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
