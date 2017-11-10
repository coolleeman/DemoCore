using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCoreDelete.Data
{
    public class Code
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public DateTime ActiveFrom { get; set; }

        public DateTime ActiveTo { get; set; }

        public long CodeTypeId { get; set; }
        [ForeignKey("CodeTypeId")]
        public CodeType CodeType { get; set; }

        public int DisplayOrder { get; set; }

    }
}
