using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSurvey.DataAccessLayer.Entities;
using OnlineSurvey.Repos;
using OnlineSurvey.Services.Contract;
using OnlineSurvey.Services.Implementation;

namespace OnlineSurvey.WebApp.Service.Controllers
{
    public class AccessController : Controller
    {
        private readonly IGenericRepo<Respondents> _accessService;
        private readonly DbSet<Respondents> _entities;
        public AccessController(IGenericRepo<Respondents> accessService, ApplicationDbContext context)
        {
            this._accessService = accessService;
            _entities = context.Set<Respondents>();
        }
        [HttpGet("GetAllUsers/", Name = "GetAllUsers")]
        public async Task<IEnumerable<Respondents>> GetAllUsers()
        {
            try
            {
                var t = _accessService.GetAll().Result;
                return t;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost("GetLoginState/", Name = "getLoginState")]
        public async Task<IEnumerable<Respondents>> Login(string UserName, string Password)
        {
            try
            {
                var result = await _entities.FirstOrDefaultAsync(u=> u.UserName==UserName && u.Password==Password);
                Respondents fourSqaureVenues = result;
                List<Respondents> l = new();
                l.Add(result);
                return l;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
