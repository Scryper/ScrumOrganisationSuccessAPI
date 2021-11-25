namespace Application.UseCases.Meeting.Dtos
{
    public class InputDtoUpdateMeeting<T>
    {
        public int Id { get; set; }
        public T Value { get; set; }
    }
}