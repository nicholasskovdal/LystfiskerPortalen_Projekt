using System.Threading.Tasks;
using LystfiskerPortalen.Application.Models;


namespace LystfiskerPortalen.Application.Interfaces
{
    public interface IChannelRepository
    {
        Task<Channel> GetChannelByIdAsync(int channelId);
        Task<IEnumerable<Channel>> GetAllChannelsAsync();
        Task<IEnumerable<Post>> GetAllPostsInChannelAsync(int channelId);
        Task<IEnumerable<AppUser>> GetAllUsersInChannelAsync(int userId);
    }
}
