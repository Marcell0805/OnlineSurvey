using Microsoft.EntityFrameworkCore;
using OnlineSurvey.DataAccessLayer.Entities;
using System;
using System.Linq;

namespace OnlineSurvey.Repos
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Expectations> Expectations { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Respondents> Respondents { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder
                    .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=UserStorageDB");
        }
    }
}
