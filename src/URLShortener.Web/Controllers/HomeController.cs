using Microsoft.AspNetCore.Mvc;
using URLShortener.IntegrationService.Contracts;

namespace URLShortener.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IURlShortenerService _shortenerService;
        public HomeController(IURlShortenerService shortenerService)
        {
            _shortenerService = shortenerService;
        }

        public IActionResult Index(string code = null)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Ok("This is my default action...");
            }

            return Redirect("https://google.com");
        }


    }
}