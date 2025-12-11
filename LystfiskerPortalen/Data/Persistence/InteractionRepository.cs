
using LystfiskerPortalen.Application.Enums;
using LystfiskerPortalen.Application.Interfaces;
using LystfiskerPortalen.Application.Models;
using LystfiskerPortalen.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace LystfiskerPortalen.Data.Persistence
{
    public class InteractionRepository : IInteractionRepository
    {
        private readonly LystfiskerportalDbContext _context;
        public InteractionRepository(LystfiskerportalDbContext context)
        {
            _context = context;
        }


        public async Task<Interaction?> GetLikeAsync(string postId, string userId)
        {
            
            return await _context.Interactions
                .FirstOrDefaultAsync(i => i.PostId == postId && i.AppUserId == userId && i.Type == InteractionType.Like);
        }

        public async Task AddInteractionAsync(Interaction interaction)
        {
            _context.Interactions.Add(interaction);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveInteractionAsync(Interaction interaction)
        {
            _context.Interactions.Remove(interaction);
            await _context.SaveChangesAsync();
        }
    }
}
