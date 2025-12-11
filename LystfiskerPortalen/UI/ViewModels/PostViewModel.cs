namespace LystfiskerPortalen.UI.ViewModels
{
    public class PostViewModel
    {
        public string PostId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Bait { get; set; }
        public string Location { get; set; }
        public string Technique { get; set; }
        public string ImageUrl { get; set; }
        public string Inspiration { get; set; }
        public DateTime CreatedAt { get; set; }

        public string AuthorName { get; set; } = string.Empty;

        public List<InteractionViewModel> Interactions { get; set; } = new();



    }
}
