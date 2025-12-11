using LystfiskerPortalen.Application.Interfaces;
using LystfiskerPortalen.Application.Models;
using LystfiskerPortalen.Data.Context;
using LystfiskerPortalen.Data.Persistence;
using LystfiskerPortalen.UI.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents();
            builder.Services.AddDbContext<LystfiskerportalDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("LystfiskerPortalenConnection"));
                });
            builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<LystfiskerportalDbContext>();

            builder.Services.AddScoped<IChannelRepository, ChannelRepository>();

            builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

            //builder.Build();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorPages(); //Skal m�ske ikke v�re her

            app.MapRazorComponents<App>();

            app.Run();
            app.UseStaticFiles();  // this found on chat gpt to run css in wwwroot

        }
    }
}
