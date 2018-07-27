using Microsoft.EntityFrameworkCore;
using NTCore.DataModel;
using NTCore.DataModel.Entities;

namespace NTCore.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserInfo>()
                .ToTable($"{DataEnum.DbTablePrefix}User");

            modelBuilder.Entity<SiteInfo>()
                .ToTable($"{DataEnum.DbTablePrefix}Site");
        }

        public DbSet<UserInfo> User { get; set; }
        public DbSet<SiteInfo> Site { get; set; }



    }
}
