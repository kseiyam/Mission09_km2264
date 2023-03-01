using Microsoft.AspNetCore.Mvc;
using Mission09_km2264.Models;
using Mission09_km2264.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_km2264.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(int pageNum = 1)
        {
            //results per page
            int numResults = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip(numResults * (pageNum - 1))
                .Take(numResults),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = numResults,
                    CurrentPage = pageNum
                }
            };
            return View(x);
        }
    }
}
