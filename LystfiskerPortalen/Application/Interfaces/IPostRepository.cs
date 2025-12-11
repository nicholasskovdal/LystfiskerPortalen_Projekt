using LystfiskerPortalen.Application.Models;

namespace LystfiskerPortalen.Application.Interfaces
{
    public interface IPostRepository
    {
        Task AddPostAsync(Post post);
        Task<IEnumerable<Post>> GetPostsByChannelAsync(string channelId);
        Task<Post?> GetPostByIdAsync(string postId);
       
    }
}
