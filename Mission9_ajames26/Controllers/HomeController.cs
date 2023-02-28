using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission9_ajames26.Models;
using Mission9_ajames26.Models.ViewModels;
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

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            BooksViewModel vm = new BooksViewModel()
            {
                Books = _bookRepo
                    .Books
                    .OrderBy(b => b.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(10),

                PageInfo = new PageInfo
                {
                    NumBooks = _bookRepo.Books.Count(),
                    PageSize = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(vm);
        }

    }
}
