using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_MongoDB.Models;
using MVC_MongoDB.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_MongoDB.Controllers
{
    public class BooksController : Controller
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService) =>
        _booksService = booksService;

        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Delete(String id)
        {
            await _booksService.RemoveAsync(id);
            return RedirectToAction("ViewAll");
        }
        public IActionResult ViewAll()
        {
            List<Book> books = _booksService.Get();
            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile fileUpload, Book book)
        {
            using (var dataStream = new MemoryStream())
            {
                await fileUpload.CopyToAsync(dataStream);
                book.Picture = dataStream.ToArray();
            }

            _booksService.Create(book);
            return View("Create");
        }


            // GET: /<controller>/
            public IActionResult Index()
        {
            return View();
        }
    }
}

