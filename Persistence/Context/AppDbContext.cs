using Domain.Entities;

namespace Persistence.Context;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<AffiliateLink> AffiliateLinks { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<ContactMessage> ContactMessages { get; set; }
    public DbSet<ClickStat> ClickStats { get; set; }
    public DbSet<SiteSetting> SiteSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ClickStat>()
            .HasOne(c => c.AffiliateLink)
            .WithMany()
            .HasForeignKey(c => c.AffiliateLinkId);

        modelBuilder.Entity<User>()
            .HasData(new User()
            {
                Id = 1,
                Username = "admin",
                PasswordHash = "admin@bet"
            });
    }
}