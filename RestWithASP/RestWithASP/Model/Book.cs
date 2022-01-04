using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASP.Model
{
    [Table("books")]
    public class Book
    {
        [Column("Id")]
        public long Id { get; set; }
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
