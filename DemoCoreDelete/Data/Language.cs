using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCoreDelete.Data
{
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LanguageId { get; set; }
        public string Code{ get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        public int OrderSeq { get; set; }
    }
}
