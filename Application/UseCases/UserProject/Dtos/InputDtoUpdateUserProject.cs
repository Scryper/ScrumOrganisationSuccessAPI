namespace Application.UseCases.UserProject.Dtos
{
    public class InputDtoUpdateUserProject
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