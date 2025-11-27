using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Authors
{
    [Table("Author_mod", Schema = "database-1_dbo")]
    public class Author
    {
        [Key]
        [Column("BusinessEntityID_mod")]
        public int BusinessEntityID { get; set; }

        [Required]
        [StringLength(15)]
        [Column("NationalIDNumber_mod")]
        public string NationalIDNumber { get; set; }

        [Required]
        [StringLength(256)]
        [Column("LoginID_mod")]
        public string LoginID { get; set; }

        [Required]
        [StringLength(50)]
        [Column("JobTitle_mod")]
        public string JobTitle { get; set; }

        [Required]
        [Column("BirthDate_mod")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(1)]
        [Column("MaritalStatus_mod")]
        public string MaritalStatus { get; set; }

        [Required]
        [StringLength(1)]
        [Column("Gender_mod")]
        public string Gender { get; set; }

        [Required]
        [Column("HireDate_mod")]
        public DateTime HireDate { get; set; }

        [Required]
        [Column("VacationHours_mod")]
        public short VacationHours { get; set; }
        
        [Required]
        [Column("ModifiedDate_mod")]
        public DateTime ModifiedDate { get; set; }
    }
}
