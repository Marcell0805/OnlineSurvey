using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSurvey.DataAccessLayer.Entities;
using OnlineSurvey.Repos;
using OnlineSurvey.Services.Contract;

namespace OnlineSurvey.WebApp.Service.Controllers
{
    public class SurveyController : Controller
    {
        private readonly IGenericRepo<RespondentResult> _accessService;
        private readonly DbSet<RespondentResult> _entities;
        public SurveyController(IGenericRepo<RespondentResult> accessService, ApplicationDbContext context)
        {
            this._accessService = accessService;
            _entities = context.Set<RespondentResult>();
        }
    }
}
