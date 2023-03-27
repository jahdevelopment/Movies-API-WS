using Microsoft.EntityFrameworkCore;
using Movies_API_WS.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MoviesApiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesApiContext")));

var app = builder.Build();

app.MapGet("/", () => "Movies Database API - Work Simulation");

app.MapGet("/Movie", (MoviesApiContext context) =>
{
    return context.Movies.Take(100).ToHashSet<Movie>();
});

app.MapGet("/Customer", (MoviesApiContext context) =>
{
    return context.Customers.Take(100).ToHashSet<Customer>();
});

app.MapGet("/Rating", (MoviesApiContext context) =>
{
    return context.Ratings.Take(100).ToHashSet<Rating>();
});

app.Run();
