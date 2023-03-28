using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Movies_API_WS.Models;
using System.Data;

namespace Movies_API_WS.Controllers
{
    public class RatingsController : Controller
    {
        private string connectionString;

        public RatingsController(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }



    }
}

