using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shoppi.Client;
using Shoppi.Client.Services;
using Shoppi.Client.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// 🔴 THIS PART WAS MISSING
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HttpClient pointing to API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:5001/")
});

// Your service
builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();