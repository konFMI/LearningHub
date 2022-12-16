using Microsoft.AspNetCore.Mvc;
using ShareHub.Models;

namespace ShareHub.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        public IActionResult All()
        {
            return View(new AllBooksQueryModel());
        }

        [Authorized]
        public IActionResult Mine()
        {
            return View(new AllBooksQueryModel());
        }

    }
}