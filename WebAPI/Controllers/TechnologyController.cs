using Application.UseCases.Technology.Get;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/technology")]
    public class TechnologyController
    {
        // Use cases 
        private readonly UseCaseGetAllTechnologies _useCaseGetAllTechnologies;
    }
}