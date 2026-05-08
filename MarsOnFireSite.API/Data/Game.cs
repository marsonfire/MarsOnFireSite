namespace MarsOnFireSite.API.Data
{
    public class Game
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Link { get; set; } = String.Empty;
    }
}
