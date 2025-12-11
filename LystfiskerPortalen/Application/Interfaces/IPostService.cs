using LystfiskerPortalen.UI.ViewModels;

namespace LystfiskerPortalen.Application.Interfaces
{
    public interface IPostService
    {
        Task CreatePostAsync(PostFormViewModel viewModel, string userId);
        Task<List<PostViewModel>> GetPostsForChannelAsync(string channelId);
    }
}
