using System.ComponentModel.DataAnnotations;

namespace LystfiskerPortalen.UI.ViewModels
{
    public class CommentFormViewModel
    {
        [Required] public string Content { get; set; } = string.Empty;
        public string PostId { get; set; } = string.Empty;
    }

}
