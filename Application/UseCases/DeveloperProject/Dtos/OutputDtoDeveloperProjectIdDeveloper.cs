using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.DeveloperProject.Dtos
{
    public class OutputDtoDeveloperProjectIdDeveloper
    {
        public int IdDeveloper { get; set; }
        public int IdProject { get; set; }
        public bool isAppliance { get; set; }
    }
}