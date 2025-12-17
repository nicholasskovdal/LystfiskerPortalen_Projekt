namespace LystfiskerPortalen.Domain.Models
{
    public class Profile
    {
        public string ProfileId { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Biography { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }


        /*Navigation Properties*/
        public required string AppUserId { get; set; } //1-1, SKAL være bruger til profilen
        public AppUser AppUser { get; set; }
    }
}
