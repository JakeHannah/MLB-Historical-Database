using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MLBHistoricalDatabase.Repositories;
using Microsoft.Extensions.Configuration;
using MLBHistoricalDatabase.Pages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<IGameRepository, GameRepository>(provider =>
    new GameRepository(builder.Configuration.GetConnectionString("MyDatabase")));

builder.Services.AddScoped<IPitcherRepository, PitcherRepository>(provider =>
    new PitcherRepository(builder.Configuration.GetConnectionString("MyDatabase")));

builder.Services.AddScoped<ITeamRepository, TeamRepository>(provider =>
    new TeamRepository(builder.Configuration.GetConnectionString("MyDatabase")));

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
