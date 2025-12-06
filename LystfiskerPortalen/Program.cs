using LystfiskerPortalen.UI.Components;
using LystfiskerPortalen.Data.Context;
using Microsoft.EntityFrameworkCore;
using LystfiskerPortalen.Domain.Models;
using Microsoft.AspNetCore.Identity;

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

            app.MapRazorPages(); //Skal måske ikke være her

            app.MapRazorComponents<App>();

            app.Run();
            app.UseStaticFiles();  // this found on chat gpt to run css in wwwroot

        }
    }
}
