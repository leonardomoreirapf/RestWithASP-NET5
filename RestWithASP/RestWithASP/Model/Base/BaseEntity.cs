using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASP.Model.Base
{
    public class BaseEntity
    {
        [Column("Id")]
        public long Id { get; set; }
    }
}
