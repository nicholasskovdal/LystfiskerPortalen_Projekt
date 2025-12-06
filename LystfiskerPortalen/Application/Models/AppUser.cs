using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LystfiskerPortalen.Domain.Models
{
    public class AppUser : IdentityUser
    {
        public string AppUserId { get; set; } //Primary Key
        public int Age { get; set; }
        public string Gender { get; set; }
        public string? Address { get; set; }


        /*Navigation Properties til EF Core*/
        public Profile Profile { get; set; } //1-1
        public ICollection<Post> Posts { get; set; } = new List<Post>(); //1-M
        public ICollection<Interaction> Interactions { get; set; } = new List<Interaction>(); //1-M
        public ICollection<AppUserChannel> AppUserChannels { get; set; } = new List<AppUserChannel>(); //M-M

    }
}
