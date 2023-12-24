using BlazorSV.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        CreateHostBuilder().Build().Run();
    }

    public static IWebHostBuilder CreateHostBuilder() =>
        new WebHostBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddRazorPages();
                services.AddServerSideBlazor();
                services.AddSingleton<WeatherForecastService>();
            })
            .Configure(app =>
            {
                if (!app.HostingEnvironment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Error");
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseRouting();
                app.MapBlazorHub();
                app.MapFallbackToPage("/_Host");
            });
}
