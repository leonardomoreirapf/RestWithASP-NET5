using RestWithASP.Hypermedia;
using RestWithASP.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace RestWithASP.Data.VO
{
    public class BookVO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LauchDate { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
