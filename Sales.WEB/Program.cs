using Sales.WEB.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CurrieTechnologies.Razor.SweetAlert2;
using Sales.WEB;
using Microsoft.AspNetCore.Components.Authorization;
using Sales.WEB.Auth;
using Blazored.Modal;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//para meter el token 
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5239/") }); 

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredModal();
builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();

//builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderTest>();

builder.Services.AddScoped<AuthenticationProviderJWT>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());
builder.Services.AddScoped<ILoginService, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());



await builder.Build().RunAsync();