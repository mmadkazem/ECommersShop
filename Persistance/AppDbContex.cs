using ECommersShop.Entity;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Persistance
{
    public class AppDbContex : DbContext
    {
        public AppDbContex(DbContextOptions<AppDbContex> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
    }
}