using Microsoft.EntityFrameworkCore;
using OnlineSurvey.DataAccessLayer.Entities;

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
        public DbSet<UserRoles> UserRole { get; set; }
        public DbSet<RespondentResult> RespondentResults { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder
                    .UseSqlServer("Data Source=(localdb)\\localDb; Initial Catalog=Survey");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expectations>().HasData(
                new Expectations { ObjectiveID = 1, FocusArea = "Internal Meetings", ExpectedWeight = 8 },
                new Expectations { ObjectiveID = 2, FocusArea = "Client Meetings", ExpectedWeight = 8 },
                new Expectations { ObjectiveID = 3, FocusArea = "Emails & Phone / Skype calls", ExpectedWeight = 5 },
                new Expectations { ObjectiveID = 4, FocusArea = "Research", ExpectedWeight = 5 },
                new Expectations { ObjectiveID = 5, FocusArea = "DB Design", ExpectedWeight = 2 },
                new Expectations { ObjectiveID = 6, FocusArea = "Architecture Design and Planning", ExpectedWeight = 5 },
                new Expectations { ObjectiveID = 7, FocusArea = "Back-end Development", ExpectedWeight = 30 },
                new Expectations { ObjectiveID = 8, FocusArea = "Front-end Development", ExpectedWeight = 22 },
                new Expectations { ObjectiveID = 9, FocusArea = "Integration", ExpectedWeight = 5 },
                new Expectations { ObjectiveID = 10, FocusArea = "Testing", ExpectedWeight = 10 }
            );
            modelBuilder.Entity<Respondents>().HasData(
                new Respondents { UserID = 1, UserName = "Marcell", Password = "Smith", RoleID = 1},
                new Respondents { UserID = 2, UserName = "John", Password = "Snow", RoleID=2},
                new Respondents { UserID = 3, UserName = "Kevin", Password = "Eleven", RoleID = 2},
                new Respondents { UserID = 4, UserName = "Joe", Password = "DuoLingo", RoleID = 2 },
                new Respondents { UserID = 5, UserName = "Carl", Password = "Watermellons", RoleID = 2 }
             );
            modelBuilder.Entity<UserRoles>().HasData(
                new UserRoles { RoleID = 1, RoleName= "Administrator"},
                new UserRoles { RoleID = 2, RoleName = "Worker" }
             );
            modelBuilder.Entity<Questions>().HasData(
               new Questions { QuestionID = 1, QuestionDescription = "Internal Meetings" },
               new Questions { QuestionID = 2, QuestionDescription = "Client Meetings" },
               new Questions { QuestionID = 3, QuestionDescription = "Emails & Phone / Skype calls" },
               new Questions { QuestionID = 4, QuestionDescription = "Research" },
               new Questions { QuestionID = 5, QuestionDescription = "DB Design" },
               new Questions { QuestionID = 6, QuestionDescription = "Architecture Design and Planning" },
               new Questions { QuestionID = 7, QuestionDescription = "Back-end Development" },
               new Questions { QuestionID = 8, QuestionDescription = "Front-end Development" },
               new Questions { QuestionID = 9, QuestionDescription = "Integration" },
               new Questions { QuestionID = 10, QuestionDescription = "Testing" }
           );
        }
    }
}
