using AdayOgrenci.Entity;
using AdayOgrenci.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

namespace AdayOgrenci.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DataContext db = new DataContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize(Policy = "ManagerAccess")]
        public IActionResult Index(int page=1,string searchString="")
        {
            var admissions = new List<Admission>();
            if (!String.IsNullOrEmpty(searchString))
            {
                admissions = db.Admissions.Where(i => i.OIN.Contains(searchString)).ToList();
                return View(admissions.ToPagedList(page, 30));
            }
            admissions = db.Admissions
                .Select(i => new Admission()
                {
                    OIN = i.OIN,
                    NameRU = i.NameRU,
                    SurnameRU = i.SurnameRU,
                    FatherNameRU = i.FatherNameRU
                }).ToList();
            
            var homeViewModel = new HomeViewModel()
            {
                Admissions = admissions
            };
            return View(homeViewModel.Admissions.ToPagedList(page, 30));
        }

        [HttpPost]
        [Authorize(Policy = "ManagerAccess")]
        public IActionResult Search(string oin)
        {
            return RedirectToAction("Index", new {page = 1, searchString = oin});
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
