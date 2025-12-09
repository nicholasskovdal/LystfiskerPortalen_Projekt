namespace LystfiskerPortalen.Application.Models
{
    public class Profile
    {
        public string ProfileId { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Biography { get; set; }

        /*Navigation Properties*/
        public required string AppUserId { get; set; } //1-1, SKAL være bruger til profilen
        public AppUser AppUser { get; set; }
    }
}
