using LystfiskerPortalen.Application.Interfaces;
using LystfiskerPortalen.Application.Models;
using LystfiskerPortalen.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

namespace LystfiskerPortalen.Data.Persistence
{
    public class PostRepository : IPostRepository
    {
        private readonly LystfiskerportalDbContext _context;
        public PostRepository(LystfiskerportalDbContext context)
        {
            _context = context;
        }

        public async Task AddPostAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Post?> GetPostByIdAsync(string postId)
        {
            return await _context.Posts
                .Include(p => p.Interactions)
                .FirstOrDefaultAsync(p => p.PostId == postId);
        }

        public async Task<IEnumerable<Post>> GetPostsByChannelAsync(string channelId)
        {
            return await _context.Posts
                .Include(p => p.AppUser)
                .Include(p => p.Interactions)
                .Where(p => p.ChannelId == channelId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }
    }
}
