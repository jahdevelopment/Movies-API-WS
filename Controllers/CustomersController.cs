using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Movies_API_WS.Models;

namespace Movies_API_WS.Controllers
{
    public class CustomersController : Controller
    {
        private string connectionString;
        public CustomersController(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        
    }        
}
