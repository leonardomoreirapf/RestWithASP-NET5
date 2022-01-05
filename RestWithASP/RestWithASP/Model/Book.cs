using RestWithASP.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASP.Model
{
    [Table("books")]
    public class Book : BaseEntity
    {
        [Column("Title")]
        public string Title { get; set; }
        [Column("Author")]
        public string Author { get; set; }
        [Column("Price")]
        public decimal Price { get; set; }
        [Column("LauchDate")]
        public DateTime LauchDate { get; set; }
    }
}
