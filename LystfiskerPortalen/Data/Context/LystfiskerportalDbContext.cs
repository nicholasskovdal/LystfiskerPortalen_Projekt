using LystfiskerPortalen.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalen.Data.Context
{
    public class LystfiskerportalDbContext : IdentityDbContext<AppUser>
    {
        public LystfiskerportalDbContext(DbContextOptions<LystfiskerportalDbContext> options)
            : base(options)
        {
        }

        //DbSet
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<AppUserChannel> AppUserChannels { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Interaction> Interactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // AppUser ↔ Profile (one-to-one)
            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.AppUser)
                .HasForeignKey<Profile>(p => p.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);


            // AppUser ↔ Post (one-to-many)
            modelBuilder.Entity<Post>()
                .HasOne(p => p.AppUser)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser ↔ Interaction (one-to-many)
            modelBuilder.Entity<Interaction>()
                .HasOne(i => i.AppUser)
                .WithMany(u => u.Interactions)
                .HasForeignKey(i => i.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Post ↔ Interaction (one-to-many)
            modelBuilder.Entity<Interaction>()
                .HasOne(i => i.Post)
                .WithMany(p => p.Interactions)
                .HasForeignKey(i => i.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            // Channel ↔ Post (one-to-many)
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Channel)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.ChannelId)
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser ↔ Channel (many-to-many via AppUserChannel)
            modelBuilder.Entity<AppUserChannel>()
                .HasKey(uc => new { uc.AppUserId, uc.ChannelId });

            modelBuilder.Entity<AppUserChannel>()
                .HasOne(uc => uc.AppUser)
                .WithMany(u => u.AppUserChannels)
                .HasForeignKey(uc => uc.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppUserChannel>()
                .HasOne(uc => uc.Channel)
                .WithMany(c => c.AppUserChannels)
                .HasForeignKey(uc => uc.ChannelId)
                .OnDelete(DeleteBehavior.Cascade);

            // Enum conversion for InteractionType
            modelBuilder.Entity<Interaction>()
                .Property(i => i.Type)
                .HasConversion<string>();


            //Seed some data for default Channels :D
            modelBuilder.Entity<Channel>().HasData(
                new Channel { ChannelId = "1", Name = "Nordjylland" },
                new Channel { ChannelId = "2", Name = "Midtjylland" },
                new Channel { ChannelId = "3", Name = "Syddanmark" },
                new Channel { ChannelId = "4", Name = "Sjælland" },
                new Channel { ChannelId = "5", Name = "Hovedstaden" },
                new Channel { ChannelId = "6", Name = "Bornholm" }
                );

        }
    }

}
