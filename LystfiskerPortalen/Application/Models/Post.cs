namespace LystfiskerPortalen.Application.Models
{
    public class Post
    {
        public string PostId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string? Bait { get; set; }

        public string? Location { get; set; }
        public string? Technique { get; set; }
        public string? ImageUrl { get; set; }
        public string? Inspiration { get; set; }
        public DateTime CreatedAt { get; set; } //måske nice at kunne se hvornår post er slået op

        /*Nagivation Properties*/
        public required string AppUserId { get; set; } //1-M, post SKAL have bruger
        public AppUser AppUser { get; set; }
        public required string ChannelId { get; set; } //1-M, post SKAL have channel
        public Channel Channel { get; set; }
        public ICollection<Interaction> Interactions { get; set; } = new List<Interaction>(); //1-M

    }

}
