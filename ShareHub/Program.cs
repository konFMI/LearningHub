using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShareHub.Data;

namespace ShareHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ShareHubDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                // TODO: Update restrictions when in release state.
                options.SignIn.RequireConfirmedAccount  = false;
                options.Password.RequireDigit           = false;
                options.Password.RequireLowercase       = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase       = false;
            })
                .AddEntityFrameworkStores<ShareHubDbContext>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}