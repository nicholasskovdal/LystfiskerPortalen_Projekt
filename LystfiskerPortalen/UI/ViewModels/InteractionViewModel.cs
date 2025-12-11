using LystfiskerPortalen.Application.Enums;

namespace LystfiskerPortalen.UI.ViewModels
{
    public class InteractionViewModel
    {
        public string InteractionId { get; set; }
        public InteractionType Type { get; set; }
        public string? Content { get; set; } //comments
        public DateTime CreatedAt { get; set; }
        public string AuthorName { get; set; } = string.Empty;
    }
}
