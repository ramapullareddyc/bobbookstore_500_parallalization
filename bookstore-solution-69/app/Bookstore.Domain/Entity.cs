using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Domain
{
    public abstract class Entity
    {
        [Column("Id_mod")]
        public int Id { get; set; }

        [Column("CreatedBy_mod")]
        public string CreatedBy { get; set; } = "System";

        [Column("CreatedOn_mod")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Column("UpdatedOn_mod")]
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;

        //[Timestamp]
        //public long RowVersion { get; set; }

        public bool IsNewEntity()
        {
            return Id == 0;
        }
    }
}