using BLL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTest.Models;

namespace WebApplicationTest.Controllers
{
        public class HomeController : Controller
        {
                private readonly IPlayerRepository _playerRepository;

                public HomeController(IPlayerRepository playerRepository)
                {
                        _playerRepository = playerRepository;
                }

                public IActionResult Index([FromServices] IGameRepository gameRepository)
                {
                        var model = new IndexViewModel
                        {
                                Players = _playerRepository.GetAll().ToList(),    // constructor injected mac99
                                Games = gameRepository.GetTodaysGames().ToList()      // parameter injecteddddddssssddddd
                        };

                        return View(model);
                }

                public IActionResult About()
                {

                        ViewData["Message"] = "Your application description pageeee.    kkkkk mac999";

                        return View();
                }

                public IActionResult Contact()
                {
                        ViewData["Message"] = "Your contact page.";

                        return View();
                }

                public IActionResult Error()
                {
                        return View();
                }
        }
}
