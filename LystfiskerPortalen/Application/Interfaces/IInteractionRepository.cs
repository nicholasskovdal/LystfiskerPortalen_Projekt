using LystfiskerPortalen.Application.Models;

namespace LystfiskerPortalen.Application.Interfaces
{
    public interface IInteractionRepository
    {
        Task<Interaction?> GetLikeAsync(string postId, string userId);
        Task AddInteractionAsync(Interaction interaction);
        Task RemoveInteractionAsync(Interaction interacton);
    }
}
