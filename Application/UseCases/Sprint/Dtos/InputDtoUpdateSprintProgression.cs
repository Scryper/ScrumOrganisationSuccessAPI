namespace Application.UseCases.Sprint.Dtos
{
    public class InputDtoUpdateSprintProgression
    {
        public int Id { get; set; }
        public Sprint InternSprint { get; set; }

        public class Sprint
        {
            public int Progression { get; set; }
        }
    }
}