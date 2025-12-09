using LystfiskerPortalen.Application.Interfaces;
using LystfiskerPortalen.Application.Models;
using LystfiskerPortalen.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalen.Data.Persistence
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly LystfiskerportalDbContext _context;
        public ChannelRepository(LystfiskerportalDbContext context)
        {
            _context = context;   
        }


        public async Task<IEnumerable<Channel>> GetAllChannelsAsync()
        {
            return await _context.Channels.ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllPostsInChannelAsync(int channelId)
        {
            return await _context.Posts
                .Where(p => p.ChannelId == channelId.ToString())
                .ToListAsync();
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersInChannelAsync(int userId)
        {
            var appUsers = new List<AppUser>();
            await foreach(var user in _context.AppUserChannels)
            {
                appUsers.Add(user.AppUser);
            }
            return appUsers;
        }

        public async Task<Channel> GetChannelByIdAsync(int channelId)
        {
            return await _context.Channels
                .Include(c => c.Posts)
                .FirstOrDefaultAsync(c => c.ChannelId == channelId.ToString());
        }
    }
}
