using Microsoft.AspNetCore.Identity;

namespace LystfiskerPortalen.Models
{
    public class User : IdentityUser
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Adresse { get; set; }
    }
}
