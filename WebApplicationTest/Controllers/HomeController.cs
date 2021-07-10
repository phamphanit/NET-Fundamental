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
<<<<<<< HEAD
                                Players = _playerRepository.GetAll().ToList(),    // constructor injected win 88
=======
                                Players = _playerRepository.GetAll().ToList(),    // constructor injected mac88
>>>>>>> rep test 18
                                Games = gameRepository.GetTodaysGames().ToList()      // parameter injecteddddddssssddddd
                        };

                        return View(model);
                }

                public IActionResult About()
                {

<<<<<<< HEAD
                        ViewData["Message"] = "Your application description pageeee.    kkkkk win88";
=======
                        ViewData["Message"] = "Your application description pageeee.    kkkkk mac888";
>>>>>>> rep test 18

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
