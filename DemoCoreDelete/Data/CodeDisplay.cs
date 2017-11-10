using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCoreDelete.Data
{
    public class CodeDisplay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public Language Language { get; set; }

        public long CodeId { get; set; }
        [ForeignKey("CodeId")]
        public Code Code { get; set; }

        [StringLength(50)]
        public string ShortDescription { get; set; }

        [StringLength(150)]
        public string LongDescription { get; set; }

    }
}
