using Microsoft.Data.Entity;

namespace SnowtifyApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Follower> Followers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}