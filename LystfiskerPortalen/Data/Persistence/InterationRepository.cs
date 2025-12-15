using LystfiskerPortalen.Application.Enums;
using LystfiskerPortalen.Application.Interfaces;
using LystfiskerPortalen.Application.Models;
using LystfiskerPortalen.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalen.Data.Persistence
{
    public class InterationRepository : IInteractionRepository
    {
        private readonly LystfiskerportalDbContext? _context;
        public InterationRepository(LystfiskerportalDbContext? context)
        {
            _context = context;
        }

        public async Task AddCommentAsync(string profileId, string postId, string content)
        {
            var comment = new Interaction
            {
                InteractionId = Guid.NewGuid().ToString(),
                AppUserId = profileId,
                PostId = postId,
                Type = InteractionType.Comment,
                Content = content,
                CreatedAt = DateTime.UtcNow
            };
            _context.Interactions.Add(comment);
            await _context.SaveChangesAsync();
        }

        // Add Like
        public async Task LikePostAsync(string profileId, string postId)
        {
            bool exists = await _context.Interactions.AnyAsync(i =>
                i.PostId == postId && i.AppUserId == profileId && i.Type == InteractionType.Like);
            if (exists) return;

            var like = new Interaction
            {
                InteractionId = Guid.NewGuid().ToString(),
                AppUserId = profileId,
                PostId = postId,
                Type = InteractionType.Like,
                CreatedAt = DateTime.UtcNow
            };
            _context.Interactions.Add(like);
            await _context.SaveChangesAsync();
        }

        // Remove Like
        public async Task UnlikePostAsync(string profileId, string postId)
        {
            var like = await _context.Interactions.FirstOrDefaultAsync(i =>
                i.PostId == postId && i.AppUserId == profileId && i.Type == InteractionType.Like);
            if (like == null) return;

            _context.Interactions.Remove(like);
            await _context.SaveChangesAsync();
        }

        // Add Share
        public async Task AddShareAsync(string profileId, string postId)
        {
            var share = new Interaction
            {
                InteractionId = Guid.NewGuid().ToString(),
                AppUserId = profileId,
                PostId = postId,
                Type = InteractionType.Share,
                CreatedAt = DateTime.UtcNow
            };
            _context.Interactions.Add(share);
            await _context.SaveChangesAsync();
            // need more to get it the shared profile 
        }

        //Get all shares for a post
        public async Task<IEnumerable<Interaction>> GetSharesForPostAsync(string postId)
        {
            return await _context.Interactions
                .Where(i => i.PostId == postId && i.Type == InteractionType.Share)
                .OrderByDescending(i => i.CreatedAt)
                .ToListAsync();
        }
    }
}