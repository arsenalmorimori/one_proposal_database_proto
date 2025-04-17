using one_db_prototype_r2.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using one_db_prototype_r2.Data;
using System;

var builder = WebApplication.CreateBuilder(args);


// Register with DI container
builder.Services.AddDbContextFactory<ClubDBContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 34)),
        o => o.EnableRetryOnFailure()));

builder.Services.AddDbContextFactory<ActivityProfileDBContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 34)),
        o => o.EnableRetryOnFailure()));

// Add scoped versions if needed
builder.Services.AddDbContext<ClubDBContext>(/* same config */);
builder.Services.AddDbContext<ActivityProfileDBContext>(/* same config */);


builder.Services.AddQuickGridEntityFrameworkAdapter();


builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
