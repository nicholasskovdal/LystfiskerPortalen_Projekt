using LystfiskerPortalen.Application.Enums;
using LystfiskerPortalen.Application.Interfaces;
using LystfiskerPortalen.Application.Models;
using LystfiskerPortalen.UI.ViewModels;

namespace LystfiskerPortalen.Application.Services
{
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionRepository _interactionRepo;
        public InteractionService(IInteractionRepository interactionRepo)
        {
            _interactionRepo = interactionRepo;
        }

        public async Task AddCommentAsync(CommentFormViewModel viewModel, string userId)
        {
            if (string.IsNullOrWhiteSpace(viewModel.Content)) { throw new Exception("Comment must not be empty"); }

            var comment = new Interaction
            {
                InteractionId = Guid.NewGuid().ToString(),
                PostId = viewModel.PostId,
                AppUserId = userId,
                Type = InteractionType.Comment,
                Content = viewModel.Content,
                CreatedAt = DateTime.UtcNow
            };
            await _interactionRepo.AddInteractionAsync(comment);
        }


        public async Task AddShareAsync(string postId, string userId)
        {
            var share = new Interaction
            {
                InteractionId = Guid.NewGuid().ToString(),
                PostId = postId,
                AppUserId = userId,
                Type = InteractionType.Share,
                CreatedAt = DateTime.UtcNow
            };
            await _interactionRepo.AddInteractionAsync(share);
        }


        public async Task ToggleLikeAsync(string postId, string userId)
        {
            var existing = await _interactionRepo.GetLikeAsync(postId, userId);
            if (existing != null)
            {
                await _interactionRepo.RemoveInteractionAsync(existing);
            }
            else
            {
                var like = new Interaction
                {
                    InteractionId = Guid.NewGuid().ToString(),
                    PostId = postId,
                    AppUserId = userId,
                    Type = InteractionType.Like,
                    CreatedAt = DateTime.UtcNow
                };
                await _interactionRepo.AddInteractionAsync(like);
            }
        }
    }
}
