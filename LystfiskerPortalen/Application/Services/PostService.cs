using LystfiskerPortalen.Application.Interfaces;
using LystfiskerPortalen.Application.Models;
using LystfiskerPortalen.UI.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace LystfiskerPortalen.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepo;
        private readonly UserManager<AppUser> _userManager;
        public PostService(IPostRepository postRepo, UserManager<AppUser> userManager)
        {
            _postRepo = postRepo;
            _userManager = userManager;
        }




        public async Task CreatePostAsync(PostFormViewModel viewModel, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) { throw new Exception("User not found"); }

            var post = new Post
            {
                PostId = Guid.NewGuid().ToString(),
                Description = viewModel.Description,
                Date = viewModel.Date ?? DateTime.Today,
                Bait = viewModel.Bait,
                Location = viewModel.Location,
                Technique = viewModel.Technique,
                ImageUrl = viewModel.ImageUrl,
                Inspiration = viewModel.Inspiration,
                CreatedAt = DateTime.UtcNow,
                ChannelId = viewModel.ChannelId,
                AppUserId = userId
            };
            await _postRepo.AddPostAsync(post);
        }




        public async Task<List<PostViewModel>> GetPostsForChannelAsync(string channelId)
        {
            var posts = await _postRepo.GetPostsByChannelAsync(channelId);

            return posts.Select(p => new PostViewModel
            {
                PostId = p.PostId,
                Description = p.Description,
                Date = p.Date,
                Bait = p.Bait,
                Location = p.Location,
                Technique = p.Technique,
                ImageUrl = p.ImageUrl,
                Inspiration = p.Inspiration,
                CreatedAt = p.CreatedAt,
                AuthorName = p.AppUser?.Profile.ProfileName ?? "Ukendt",
                Interactions = p.Interactions.Select(i => new InteractionViewModel
                {
                    InteractionId = i.InteractionId,
                    Type = i.Type,
                    Content = i.Content,
                    CreatedAt = i.CreatedAt,
                    AuthorName = i.AppUser?.Profile.ProfileName ?? "Ukendt"

                }).ToList()

            }).ToList();
        }



    }
}
