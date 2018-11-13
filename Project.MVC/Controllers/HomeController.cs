using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.MVC.Models;
using Project.Service;
using Project.Domain;

namespace Project.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        
        public HomeController(IUserService userService){
            this._userService = userService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            User u = new User
            {
                Id = 1,
                UserName = "test",
                Email = "test",
                Password= "test"
            };

            _userService.Add(u);

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
