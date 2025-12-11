namespace LystfiskerPortalen.Application.Models
{
    public class Profile
    {
        public string ProfileId { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Biography { get; set; }

        public ICollection<Profile> Followers { get; set; } = new List<Profile>();
        public ICollection<Profile> Following { get; set; } = new List<Profile>();


        /*Navigation Properties*/
        public required string AppUserId { get; set; } //1-1, SKAL være bruger til profilen
        public AppUser AppUser { get; set; }
    }
}
