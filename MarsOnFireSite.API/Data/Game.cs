namespace MarsOnFireSite.API.Data
{
    public class Game
    {
        public String SteamAppId { get; set; } = String.Empty;
        public String Name { get; set; } = String.Empty;
        public String ShortDescription { get; set; } = String.Empty;
        public String ReleaseDate { get; set; }
        public String? Price { get; set;} = String.Empty;
        public String Link { get; set; } = String.Empty;
    }
}
