namespace Application.UseCases.DeveloperProject.Dtos
{
    public class InputDtoUpdateDeveloperProject
    {
        public int IdDeveloper { get; set; }
        public int IdProject { get; set; }
        public IsApply InternIsApply { get; set; }

        public class IsApply
        {
            public bool IsAppliance { get; set; }
        }
    }
}