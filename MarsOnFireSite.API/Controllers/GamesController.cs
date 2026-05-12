using MarsOnFireSite.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace MarsOnFireSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private HttpClient _httpClient = new HttpClient();

        [HttpGet("GetMyGames")]
        public async Task<IActionResult> GetMyGames()
        {
            //setup the ids of the games
            List<string> appIds = new List<string>() { "2745080", "2929510", "3197230", "3652230", "4097350" };
            List<Game> games = new List<Game>();
            
            try
            {
                //try and loop through each one, getting its info in json
                foreach (var id in appIds)
                {
                    //technically this is an API that isn't 'official' from Valve so it could go away at any point, but that seems unlikely...
                    var steamAppResponse = await _httpClient.GetAsync($"https://store.steampowered.com/api/appdetails?appids={id}");
                    
                    if (steamAppResponse.IsSuccessStatusCode)
                    {

                        //get our JSON data read from the call
                        var jsonData = await steamAppResponse.Content.ReadFromJsonAsync<Dictionary<string, SteamResponse>>();

                        //can't do anything if an AppId is invalid for whatever reason
                        if (jsonData != null && jsonData.Count > 0)
                        {
                            //root is the appId, so simplify this for accessing later
                            var appData = jsonData[id].Data;
                            var releaseDate = appData.ReleaseDate;
                            var price = appData.Price;

                            //add the game to our list to return later to the frontend
                            games.Add(new Game
                            {
                                SteamAppId = id,
                                Name = appData.Name,
                                ShortDescription = appData.ShortDescription,
                                ReleaseDate = releaseDate.ComingSoon ? "Coming Soon " + releaseDate.Date : releaseDate.Date,
                                Price = price == null ? "Coming Soon" : price.FormattedPrice,
                                Link = $"https://store.steampowered.com/app/{id}"
                            });
                        }
                    }
                }

                //order by price
                return Ok(games.OrderBy(x => x.Price));
            }
            catch (Exception ex)
            {
                return BadRequest("Failure! " + ex.Message);
            }
        }
    }
}
