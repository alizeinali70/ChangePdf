using ChangePdf.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PdfSharpCore.Fonts;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Register the custom font resolver
        GlobalFontSettings.FontResolver = new BlazorFontResolver();

        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        await builder.Build().RunAsync();
    }
}
