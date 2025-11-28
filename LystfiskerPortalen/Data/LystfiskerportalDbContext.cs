using LystfiskerPortalen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalen.Data
{
    public class LystfiskerportalDbContext : IdentityDbContext<User>
    {
        public LystfiskerportalDbContext(DbContextOptions<LystfiskerportalDbContext> options)
            : base(options)
        {
        }

    }

}
