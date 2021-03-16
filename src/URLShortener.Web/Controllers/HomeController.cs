using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using URLShortener.Common.ErrorTypes;
using URLShortener.Common.Exceptions;
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
            if (string.IsNullOrEmpty(code) || code.Contains("/"))
                return Ok("This is my default action...");

            var ticket = await _shortenerService.VisitLinkTicket(code);

            if (ticket == null)
                throw new BusinessException<LinkTicketErrorType>(LinkTicketErrorType.NotExistUrl);

            return Redirect(ticket.OriginalUrl);
        }


    }
}