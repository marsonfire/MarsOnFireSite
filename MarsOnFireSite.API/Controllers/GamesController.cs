using MarsOnFireSite.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace MarsOnFireSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMyGames()
        {
            return Ok(new List<Game>()
            {
                new Game()
                {
                    Name = "We Need More Steam!",
                    ReleaseDate = new DateTime(2024, 01, 06),
                    Description = "test",
                    Link = "link"
                },
                new Game()
                {
                    Name = "An Agonized Mind",
                    ReleaseDate = new DateTime(2024, 06, 17),
                    Description = "test",
                    Link = "link"
                },
                //new Game()
                //{

                //},
                //new Game()
                //{

                //}
            });
        }
    }
}
