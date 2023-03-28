using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Movies_API_WS.Models;
using System.Data;

namespace Movies_API_WS.Controllers
{
    public class MoviesController : Controller
    {
        private string connectionString;
        public MoviesController(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }


    }
}
