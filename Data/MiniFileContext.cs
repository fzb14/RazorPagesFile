using Microsoft.EntityFrameworkCore;

namespace RazorPagesFile.Data
{
    public class MiniFileContext : DbContext
    {
        public MiniFileContext (
            DbContextOptions<MiniFileContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesFile.Models.MiniFile> MiniFile { get; set; }
    }
}