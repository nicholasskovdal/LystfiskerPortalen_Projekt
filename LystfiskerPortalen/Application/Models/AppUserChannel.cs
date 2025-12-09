namespace LystfiskerPortalen.Application.Models
{
    //Many-to-many relationship, så her er en klasse for at lave et normaliseret, separat table med EF Core
    public class AppUserChannel
    {
        /*Navigation Properties*/
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string ChannelId { get; set; }
        public Channel Channel { get; set; }
    }
}
