using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Services1.Client;
using Services1.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<IDataConvertService, DataConvertService>();
builder.Services.AddScoped<IUserAboutService, UserAboutService>();
builder.Services.AddScoped<IUserContactService, UserContactService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ICalculations, Calculations>();

await builder.Build().RunAsync();
