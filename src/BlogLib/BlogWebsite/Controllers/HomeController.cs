using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogWebsite.Models;
using StraussDA.BlogLib;

namespace BlogWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository _postRepo;
        public HomeController(IPostRepository postRepository)
        {
            _postRepo = postRepository;
        }

        
        public IActionResult Index()
        {

            return View(_postRepo.SortByDate());
        }

        public ActionResult Details(int id)
        {
            
            return View(_postRepo.GetByID(id));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
