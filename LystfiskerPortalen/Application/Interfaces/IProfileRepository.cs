using LystfiskerPortalen.Application.Models;

namespace LystfiskerPortalen.Application.Interfaces
{
    public interface IProfileRepository
    {
        // PROFILE
        Task<Profile?> GetProfileByIdAsync(string profileId);
        Task<IEnumerable<Profile>> SearchProfilesAsync(string searchText);
        Task UpdateProfileAsync(Profile profile);
        Task CreateProfileAsync(Profile profile);

        // BIO
        Task<string?> GetBioAsync(string profileId);
        Task UpdateBioAsync(int profileId, string bio);

        // PROFILE PICTURE
        Task<string?> GetProfilePictureAsync(int profileId);
        Task UpdateProfilePictureAsync(int profileId, string imageUrl);

        // POSTS
        Task<IEnumerable<Post>> GetPostsByProfileAsync(string profileId);
        Task<Post?> GetPostByIdAsync(string postId);
        Task CreatePostAsync(Post post);
        Task DeletePostAsync(int postId);

        // FOLLOWERS / FOLLOWING
        Task<IEnumerable<Profile>> GetFollowersAsync(string profileId);
        Task<IEnumerable<Profile>> GetFollowingAsync(string profileId);
        Task FollowAsync(string followerId, string targetId);
        Task UnfollowAsync(string followerId, string targetId);

        // INTERACTIONS (Likes / Comments)
        Task<IEnumerable<Interaction>> GetInteractionsForPostAsync(string postId);
        Task LikePostAsync(string profileId, string postId);
        Task UnlikePostAsync(string profileId, string postId);
        Task AddCommentAsync(string profileId, string postId, string content);
        Task<IEnumerable<Interaction>> GetCommentsForPostAsync(string postId);

        //// PRIVACY / SETTINGS
        //Task<ProfileSettings> GetSettingsAsync(int profileId);
        //Task UpdateSettingsAsync(int profileId, ProfileSettings settings);
    }
}
//public string ProfileId { get; set; }
//public string? ProfilePictureUrl { get; set; }
//public string? Biography { get; set; }

///*Navigation Properties*/
//public required string AppUserId { get; set; } //1-1, SKAL være bruger til profilen
//public AppUser AppUser { get; set; }
