using Amare.Data;
using DataLayer;
using LogicLayer;
using Microsoft.AspNetCore.Http;
using Models;
using Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(45);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

}
        
    );

builder.Services.AddAuthentication("Cookies").AddCookie("Cookies", options =>
{
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/Login";
    options.ExpireTimeSpan = TimeSpan.FromHours(1);

    options.Events.OnRedirectToLogin = context =>
    {
        if (context.Request.Path.StartsWithSegments("/Auth"))
        {
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        }

        context.Response.Redirect(context.RedirectUri);
        return Task.CompletedTask;
    };

    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = 403;
        return Task.CompletedTask;
    };
});

builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AppDb>();
builder.Services.AddScoped<DbUserProfile>();
builder.Services.AddScoped<Auth>();
builder.Services.AddScoped<Home>();
builder.Services.AddScoped<AddGuests>();
builder.Services.AddScoped<Budget>();
builder.Services.AddScoped<Challenges>();
builder.Services.AddScoped<Expenses>();
builder.Services.AddScoped<Leaderboard>();
builder.Services.AddScoped<LiveFeed>();
builder.Services.AddScoped<ProfileImage>();
builder.Services.AddScoped<Tables>();
builder.Services.AddScoped<Tasks>();
builder.Services.AddScoped<Vendors>();
builder.Services.AddScoped<WeddingDateLoaction>();
builder.Services.AddScoped<WeddingEvents>();
builder.Services.AddScoped<IAuth, AuthRepository>();
builder.Services.AddScoped<IHome, HomeRepository>();
builder.Services.AddScoped<IAddGuest, AddGuestsRepository>();
builder.Services.AddScoped<IBudget, BudgetRepository>();
builder.Services.AddScoped<IChallenges, ChallengesRepository>();
builder.Services.AddScoped<IExpenses, ExpensesRepository>();
builder.Services.AddScoped<ILeaderboard, LeaderboardRepository>();
builder.Services.AddScoped<ILiveFeed, LiveFeedRepository>();
builder.Services.AddScoped<IProfileImage, ProfileImageRepository>();
builder.Services.AddScoped<ITables, TablesRepository>();
builder.Services.AddScoped<ITasks, TasksRepository>();
builder.Services.AddScoped<IVendors, VendorsRepository>();
builder.Services.AddScoped<IWeddingDateLocation, WeddingDateLocationRepository>();
builder.Services.AddScoped<IWeddingEvents, WeddingEventsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}")
    .WithStaticAssets();

app.MapControllers();

app.Run();
