using LystfiskerPortalen.Application.Enums;

namespace LystfiskerPortalen.Application.Models
{
    public class Interaction
    {
        public string InteractionId { get; set; }
        public InteractionType Type { get; set; }
        public string? Content { get; set; } //Only for comments
        public DateTime CreatedAt { get; set; } //for tidspunktet på Comment og Share

        /*Navigation Properties*/
        public string AppUserId { get; set; } //1-M
        public AppUser AppUser { get; set; }
        public string PostId { get; set; } //1-M
        public Post Post { get; set; }
    }
}
