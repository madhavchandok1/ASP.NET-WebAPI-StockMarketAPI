using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace api.Data
{
    public class ApplicationDbContext: IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
               
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stock>()
                .Property(e => e.ID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(seed: 1, increment: 1);

            modelBuilder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));

            modelBuilder.Entity<Portfolio>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(k => k.AppUserId);

            modelBuilder.Entity<Portfolio>()
                .HasOne(u => u.Stock)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(k => k.StockId);


            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
