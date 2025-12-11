using LystfiskerPortalen.Application.Enums;
using LystfiskerPortalen.Application.Interfaces;
using LystfiskerPortalen.Application.Models;
using LystfiskerPortalen.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalen.Data.Persistence
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly LystfiskerportalDbContext? _context;
        public ProfileRepository(LystfiskerportalDbContext? context)
        {
            _context = context;
        }
        public async Task AddCommentAsync(string profileId, string postId, string content)
        {
            var interaction = new Interaction
            {
                AppUserId = profileId,   // profile contains AppUserId FK
                PostId = postId,
                Type = InteractionType.Comment,
                Content = content,
                CreatedAt = DateTime.UtcNow
            };

            _context.Interactions.Add(interaction);
            await _context.SaveChangesAsync();
        }

        public async Task CreatePostAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task CreateProfileAsync(Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null) return;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task FollowAsync(string followerId, string targetId)
        {
            if (_context == null) throw new InvalidOperationException("DbContext is not available");

            var follower = await _context.Profiles
                                         .Include(p => p.Following)
                                         .FirstOrDefaultAsync(p => p.ProfileId == followerId);
            var target = await _context.Profiles
                                       .Include(p => p.Followers)
                                       .FirstOrDefaultAsync(p => p.ProfileId == targetId);

            if (follower == null || target == null)
                throw new InvalidOperationException("Follower or target profile not found");

            if (!follower.Following.Contains(target))
            {
                follower.Following.Add(target);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string?> GetBioAsync(string profileId)
        {
            return await _context.Profiles
                .Where(p => p.AppUserId == profileId)  // Compare actual id values
                .Select(p => p.Biography)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Interaction>> GetCommentsForPostAsync(string postId)
        {
            return await _context.Interactions
        .Where(i => i.PostId == postId && i.Type == InteractionType.Comment)
        .OrderByDescending(i => i.CreatedAt)
        .ToListAsync();
        }

        public async Task<IEnumerable<Profile>> GetFollowersAsync(string profileId)
        {
            if (_context == null) throw new InvalidOperationException("DbContext is not available");

            var profile = await _context.Profiles
                                        .Include(p => p.Followers)
                                        .FirstOrDefaultAsync(p => p.ProfileId == profileId);

            return profile?.Followers ?? Enumerable.Empty<Profile>();
        }

        public async Task<IEnumerable<Profile>> GetFollowingAsync(string profileId)
        {
            if (_context == null) throw new InvalidOperationException("DbContext is not available");

            var profile = await _context.Profiles
                                        .Include(p => p.Following)
                                        .FirstOrDefaultAsync(p => p.ProfileId == profileId);

            return profile?.Following ?? Enumerable.Empty<Profile>();
        }

        public async Task<IEnumerable<Interaction>> GetInteractionsForPostAsync(string postId)
        {
            return await _context.Interactions
         .Where(i => i.PostId == postId)
         .OrderByDescending(i => i.CreatedAt)
         .ToListAsync();
        }

        public async Task<Post?> GetPostByIdAsync(string postId)
        {
            return await _context.Posts
       .Include(p => p.Interactions)
       .FirstOrDefaultAsync(p => p.PostId == postId);
        }


        public async Task<IEnumerable<Post>> GetPostsByProfileAsync(string profileId)
        {
            return await _context.Posts
                .Where(p => p.AppUserId == profileId)  // Use AppUserId FK on post directly
                .Include(p => p.Interactions)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<Profile?> GetProfileByIdAsync(string profileId)
        {
            return await _context.Profiles
        .Include(p => p.AppUser)
        .FirstOrDefaultAsync(p => p.ProfileId == profileId);

        }

        public Task<string?> GetProfilePictureAsync(int profileId)
        {
            throw new NotImplementedException();
        }

        public async Task LikePostAsync(string profileId, string postId)
        {
            bool exists = await _context.Interactions
         .AnyAsync(i => i.PostId == postId
                        && i.AppUserId == profileId
                        && i.Type == InteractionType.Like);

            if (exists) return;

            var interaction = new Interaction
            {
                AppUserId = profileId,
                PostId = postId,
                Type = InteractionType.Like,
                CreatedAt = DateTime.UtcNow
            };

            _context.Interactions.Add(interaction);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Profile>> SearchProfilesAsync(string searchText)
        {
            throw new NotImplementedException();
        }

        public async Task UnfollowAsync(string followerId, string targetId)
        {
            if (_context == null) throw new InvalidOperationException("DbContext is not available");

            var follower = await _context.Profiles
                                         .Include(p => p.Following)
                                         .FirstOrDefaultAsync(p => p.ProfileId == followerId);
            var target = await _context.Profiles
                                       .Include(p => p.Followers)
                                       .FirstOrDefaultAsync(p => p.ProfileId == targetId);

            if (follower == null || target == null)
                throw new InvalidOperationException("Follower or target profile not found");

            if (follower.Following.Contains(target))
            {
                follower.Following.Remove(target);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UnlikePostAsync(string profileId, string postId)
        {
            var like = await _context.Interactions
                .FirstOrDefaultAsync(i => i.PostId == postId
                                       && i.AppUserId == profileId
                                       && i.Type == InteractionType.Like);

            if (like == null) return;

            _context.Interactions.Remove(like);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBioAsync(int profileId, string bio)
        {
            var profile = await _context.Profiles.FindAsync(profileId);
            if (profile == null) return;

            profile.Biography = bio;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfileAsync(Profile profile)
        {
            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();
        }

        public Task UpdateProfilePictureAsync(int profileId, string imageUrl)
        {
            throw new NotImplementedException();
        }

    }
}
