using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCoreDelete.Data
{
    public class FeedBackQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(200)]
        public string Question { get; set; }

        public long CodeId { get; set; }

        [ForeignKey("CodeId")]
        public Code Code { get; set; }

    }
}
