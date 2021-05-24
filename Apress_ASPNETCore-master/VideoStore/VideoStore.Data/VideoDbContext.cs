using Microsoft.EntityFrameworkCore;
using VideoStore.Core;

namespace VideoStore.Data
{
    public class VideoDbContext : DbContext
    {
        public VideoDbContext(DbContextOptions<VideoDbContext> dbContextOptns) : base(dbContextOptns)
        {

        }

        public DbSet<Video> Videos { get; set; }
    }
}
