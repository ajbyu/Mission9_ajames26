using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission9_ajames26.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_ajames26.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _bookRepo { get; }

        public HomeController(IBookRepository bookRepository)
        {
            _bookRepo = bookRepository;
        }

        public IActionResult Index()
        {
            var books = _bookRepo.Books.ToList();

            return View(books);
        }

    }
}
