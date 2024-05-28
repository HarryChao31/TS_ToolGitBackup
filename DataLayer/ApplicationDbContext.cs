using Microsoft.EntityFrameworkCore;
using TS_Tool.Models;

namespace TS_Tool.DataLayer
{
    public class FirstDbContext : DbContext
    {
        public FirstDbContext(DbContextOptions<FirstDbContext> options) : base(options)
        {
        }

        public DbSet<Betdetail> BetInformation { get; set; }
        // Add other DbSet properties for tables in the first database

    }
    public class SecondDbContext : DbContext
    {
        public SecondDbContext(DbContextOptions<SecondDbContext> options) : base(options)
        {
        }
        public DbSet<SeamlessWalletError> SWErrorInfo { get; set; }

    }
    public class ThirdDbContext : DbContext
    {
        public ThirdDbContext(DbContextOptions<ThirdDbContext> options) : base(options)
        {
        }
        public DbSet<Betdetail> OSBetInformation { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Betdetail>().HasNoKey();
        }

        // Add other DbSet properties for tables in the second database
    }
}
