using LystfiskerPortalen.UI.ViewModels;

namespace LystfiskerPortalen.Application.Interfaces
{
    public interface IInteractionService
    {
        Task ToggleLikeAsync(string postId, string userId);
        Task AddCommentAsync(CommentFormViewModel viewModel, string userId);
        Task AddShareAsync(string postId, string userId);
    }
}
