using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        public async Task<IActionResult> Index(string code = null)
        {
            if (string.IsNullOrEmpty(code))
                return Ok("This is my default action...");

            var ticket = await _shortenerService.VisitLinkTicket(code);

            //todo: if (ticket == null)

            return Redirect(ticket.OriginalUrl);
        }


    }
}