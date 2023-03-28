using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Movies_API_WS.Models;
using System.Data;
using System.Reflection;


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

string connectionString = "Data Source = localhost\\SQLEXPRESS; Database = MoviesAPI; Integrated Security = True; TrustServerCertificate = True;";

// Call InsertUsers function
InsertCustomers(connectionString);

// Call InsertMovies function
InsertMovies(connectionString);

// Call InsertRatings function
InsertRatings(connectionString);

// InsertUsers function
static void InsertCustomers(string connectionString)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (StreamReader reader = new StreamReader("StoredProcedures/Customers.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split('|');
                int customerId = int.Parse(values[0]);
                int age = int.Parse(values[1]);
                string gender = values[2];
                string occupation = values[3];

                using (SqlCommand command = new SqlCommand("InsertCustomer", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    command.Parameters.AddWithValue("@Age", age);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Occupation", occupation);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

// InsertMovies function
static void InsertMovies(string connectionString)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (StreamReader reader = new StreamReader("StoredProcedures/Movies.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split('|');
                int movieId = int.Parse(values[0]);
                string name = values[1];

                using (SqlCommand command = new SqlCommand("InsertMovie", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MovieId", movieId);
                    command.Parameters.AddWithValue("@Name", name);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

// InsertRatings function
static void InsertRatings(string connectionString)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (StreamReader reader = new StreamReader("StoredProcedures/Ratings.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split('\t');
                int customerId = int.Parse(values[0]);
                int movieId = int.Parse(values[1]);
                int rating = int.Parse(values[2]);

                using (SqlCommand command = new SqlCommand("InsertRating", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    command.Parameters.AddWithValue("@MovieId", movieId);
                    command.Parameters.AddWithValue("@Rating1", rating);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

app.Run();