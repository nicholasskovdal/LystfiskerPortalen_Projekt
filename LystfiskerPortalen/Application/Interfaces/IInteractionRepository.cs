using LystfiskerPortalen.Application.Models;
namespace LystfiskerPortalen.Application.Interfaces
{
    public interface IInteractionRepository
    {
        Task AddCommentAsync(string profileId, string postId, string content);

        Task LikePostAsync(string profileId, string postId);

        Task UnlikePostAsync(string profileId, string postId);

        Task AddShareAsync(string profileId, string postId);

        Task<IEnumerable<Interaction>> GetSharesForPostAsync(string postId);
    }
}
