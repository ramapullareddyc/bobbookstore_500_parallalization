using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Domain.ReferenceData
{
    [Table("ReferenceData_mod", Schema = "database-1_dbo")]
    public class ReferenceDataItem : Entity
    {
        // An empty constructor is required by EF Core
        private ReferenceDataItem() { }

        public ReferenceDataItem(ReferenceDataType referenceDataType, string text)
        {
            DataType = referenceDataType;
            Text = text;
        }

        [Column("DataType_mod")]
        public ReferenceDataType DataType { get; set; }

        [Column("Text_mod")]
        public string Text { get; set; }
    }
}
