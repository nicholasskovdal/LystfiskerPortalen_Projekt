using System.ComponentModel.DataAnnotations;

namespace LystfiskerPortalen.UI.ViewModels
{
    public class PostFormViewModel
    {
        [Required] public string Description { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public string? Bait { get; set; }
        public string? Location { get; set; }
        public string? Technique { get; set; }
        public string? ImageUrl { get; set; }
        public string? Inspiration { get; set; }

        public string ChannelId { get; set; } = string.Empty;
    }



}

