using System.ComponentModel.DataAnnotations;

namespace LystfiskerPortalen.Application.Models
{
    public class Channel
    {
        public string ChannelId { get; set; }
        public string Name { get; set; }

        /*Navigation Properties*/
        public ICollection<AppUserChannel> AppUserChannels { get; set; } = new List<AppUserChannel>(); //M-M
        public ICollection<Post> Posts { get; set; } = new List<Post>(); //1-M

    }
}
