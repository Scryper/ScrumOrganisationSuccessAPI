using Infrastructure.SqlServer.System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WebAPI.Security.Attributes;

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
        [Authorize]
        public IActionResult CreateDatabaseAndTables()
        {
            if (_hostEnvironment.IsProduction()) return BadRequest("Only in development");
            
            _databaseManager.CreateDatabaseAndTables();
            return Ok("Database and tables created successfully");
        }

        [HttpGet]
        [Route("route")]
        [Authorize]
        public IActionResult FillTables()
        {
            if (_hostEnvironment.IsProduction()) return BadRequest("Only in development");
            
            _databaseManager.FillTables();
            return Ok("tables have been filled");
        }
    }
}