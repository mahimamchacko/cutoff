using cutoff.Helpers;
using cutoff.Services;
using Microsoft.AspNetCore.Session;

namespace cutoff;

public class Startup
{
	public IConfiguration Configuration { get; set; }

	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
        services.AddControllersWithViews();

        services.AddRazorPages();

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        services.AddScoped<DataAccessor>();
        services.AddScoped<ShowService>();
        services.AddScoped<NetworkService>();
        services.AddScoped<GenreService>();
        services.AddScoped<LanguageService>();
    }

	public void Configure(WebApplication app, IWebHostEnvironment env)
	{
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseSession();

        app.UseRouting();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Authorization}/{action=Index}/{id?}"
        );

        app.Run();
    }
}