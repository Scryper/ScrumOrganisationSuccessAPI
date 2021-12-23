using Infrastructure.SqlServer.System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/database")]
    public class DatabaseController : Controller
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IDatabaseManager _databaseManager;

        public DatabaseController(IHostEnvironment hostEnvironment, IDatabaseManager databaseManager)
        {
            _hostEnvironment = hostEnvironment;
            _databaseManager = databaseManager;
        }

        [HttpGet]
        [Route("init")]
        public IActionResult CreateDatabaseAndTables()
        {
            if (_hostEnvironment.IsProduction()) return BadRequest("Only in development");
            
            _databaseManager.CreateDatabaseAndTables();
            return Ok("Database and tables created successfully.");
        }

        [HttpGet]
        [Route("fill")]
        public IActionResult FillTables()
        {
            if (_hostEnvironment.IsProduction()) return BadRequest("Only in development");
            
            _databaseManager.FillTables();
            return Ok("Tables have been filled.");
        }
    }
}