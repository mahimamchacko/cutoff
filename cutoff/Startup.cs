using System;
using cutoff.Helpers;

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

		services.AddScoped<DataContext>();
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

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );

        app.Run();
    }
}