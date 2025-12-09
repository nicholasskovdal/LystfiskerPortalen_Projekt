namespace LystfiskerPortalen.UI.ViewModels
{
    public class PostViewModel
    {
        public string PostId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Bait { get; set; }

        public string Location { get; set; }
        public string Technique { get; set; }
        public string ImageUrl { get; set; }
        public string Inspiration { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
