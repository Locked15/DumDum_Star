using DumDum_Star.Models;
using DumDum_Star.Models.Entities;

namespace DumDum_Star
{
    public class Program
    {
        public static StartType Type { get; } = StartType.IIS;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);

            var app = builder.Build();
            SetRoutings(app);
            ConfigureSettings(app);

            app.Run();
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddMvc();
            builder.Services.AddDbContext<DDSDataContext>();

            builder.Services.AddControllers();
            builder.Services.AddControllersWithViews();
        }

        private static void SetRoutings(WebApplication app)
        {
            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}"
            );
        }

        private static void ConfigureSettings(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
                app.UseHsts();

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseExceptionHandler("/Home/Error");
            app.UseStatusCodePagesWithReExecute("/Home/Status", "?code={0}");
        }
    }
}
