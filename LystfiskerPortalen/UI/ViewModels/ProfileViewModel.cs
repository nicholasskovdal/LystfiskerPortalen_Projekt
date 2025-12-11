using LystfiskerPortalen.Application.Models;

namespace LystfiskerPortalen.UI.ViewModels
{
    public class ProfileViewModel
    {
        public string ProfileId { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Biography { get; set; }
        public ICollection<Profile> Followers { get; set; } = new List<Profile>();
        public ICollection<Profile> Following { get; set; } = new List<Profile>();

    }
}
