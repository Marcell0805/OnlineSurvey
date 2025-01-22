using Microsoft.EntityFrameworkCore;
using OnlineSurvey.DataAccessLayer.Entities;
using System;
using System.Linq;

namespace OnlineSurvey.Repos
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync();

        DbSet<Expectations> Expectations { get; set; }
        DbSet<Questions> Questions { get; set; }
        DbSet<Respondents> Respondents { get; set; }
        DbSet<UserDetails> UserDetails { get; set; }
    }
}
