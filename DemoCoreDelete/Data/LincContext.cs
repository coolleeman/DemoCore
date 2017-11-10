using Microsoft.EntityFrameworkCore;

namespace DemoCoreDelete.Data
{
    public class LincContext : DbContext
    {
        public LincContext(DbContextOptions<LincContext> options) : base(options)
        {
            
        }

        public DbSet<Code> Codes { get; set; }

        public DbSet<FeedBackQuestion> FeedBackQuestions { get; set; }

        public DbSet<CodeDisplay> CodeDisplays { get; set; }
    }
}
