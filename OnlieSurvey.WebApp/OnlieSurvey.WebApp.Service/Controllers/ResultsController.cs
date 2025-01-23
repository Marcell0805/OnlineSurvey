using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSurvey.DataAccessLayer.Entities;
using OnlineSurvey.Repos;
using OnlineSurvey.Services.Contract;
using System.Net;

namespace OnlineSurvey.WebApp.Service.Controllers
{
    public class ResultsController : Controller
    {
        private readonly IGenericRepo<RespondentResult> _repository;
        private readonly DbSet<RespondentResult> _entities;
        public ResultsController(IGenericRepo<RespondentResult> accessService, ApplicationDbContext context)
        {
            this._repository = accessService;
            _entities = context.Set<RespondentResult>();
        }
        [HttpGet("GetAllResults/", Name = "GetAllResults")]
        public async Task<IEnumerable<RespondentResult>> GetAllResults()
        {
            try
            {
                var t = _repository.GetAll().Result;
                return t;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost("PostSurvey/", Name = "PostSurvey")]
        public async Task<ActionResult<IEnumerable<RespondentResult>>> PostSurvey(RespondentResult respondentResult)
        {
            try
            {
                AddResult(respondentResult);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        public async void AddResult(RespondentResult respondentResult)
        {
            if (_entities != null)
            {
                _repository.Insert(respondentResult);
                _repository.SaveChanges();
            }
        }
    }
}
