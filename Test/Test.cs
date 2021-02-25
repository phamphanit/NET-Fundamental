using BLL;
using BLL.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using WebApplicationTest.Controllers;
using Xunit;

namespace Test
{
    public class Test
    {

        //[Fact]
        public void GetTotalGoalsForSeason_returns_expected_goal_count()
        {
            // ARRANGE 
            var mockTeamStatRepo = new Mock<ITeamStatRepository>();

            // setup a mock stat repo to return some fake data in our target method
            mockTeamStatRepo
           .Setup(mtsr => mtsr.FindAll(It.IsAny<Func<TeamStatSummary, bool>>()))
           .Returns(new List<TeamStatSummary>
               {
        new TeamStatSummary {SeasonId = 1,Team = "team 1",GoalsFor=1},
        new TeamStatSummary {SeasonId=1,Team = "team 2",GoalsFor=2},
        new TeamStatSummary {SeasonId = 1,Team = "team 3",GoalsFor=3}
               });

            // create our TeamStatCalculator by injecting our mock repository
            var teamStatCalculator = new TeamStatCalculator(mockTeamStatRepo.Object);

            // ACT - call our method under test
            var result = teamStatCalculator.GetTotalGoalsForSeason(1);

            // ASSERT - we got the result we expected - our fake data has 6 goals
            //we should get this back from the method
            Assert.True(result == 6);
        }
        [Fact]
        public void TestHomeControllerWithIndexAction()
        {
            var mockPlayerRepo = new Mock<IPlayerRepository>();
            mockPlayerRepo
                .Setup(x => x.GetAll())
                .Returns(new List<Player>
                {
                    new Player {Name="Vincent",Height = 175,Weight = 63},
                    new Player {Name="Max",Height = 165,Weight = 56},
                    new Player {Name="Elli",Height = 155,Weight = 50},
                });
            var mockGameRepo = new Mock<IGameRepository>();
            mockGameRepo
                .Setup(x => x.GetTodaysGames())
                .Returns(new List<Game>
                {
                    new Game{HomeTeam = "AB",Date= DateTime.Now.AddMonths(-2),AwayTeam = "OKOK"},
                    new Game{HomeTeam = "CD",Date= DateTime.Now.AddMonths(-1),AwayTeam = "OKOK"},
                    new Game{HomeTeam = "EF",Date= DateTime.Now.AddMonths(-3),AwayTeam = "OKOK"},
                });
            // player repository is injected through constructor
            var controller = new HomeController(mockPlayerRepo.Object);

            // ACT 
            // game repository is injected through action parameter
            var result = controller.Index(mockGameRepo.Object);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IndexViewModel>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Players.Count);
            Assert.Equal(3, model.Games.Count);


        } 
    }

}
