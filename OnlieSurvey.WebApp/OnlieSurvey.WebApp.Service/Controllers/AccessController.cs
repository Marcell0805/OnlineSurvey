using Microsoft.AspNetCore.Mvc;

namespace OnlineSurvey.WebApp.Service.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
