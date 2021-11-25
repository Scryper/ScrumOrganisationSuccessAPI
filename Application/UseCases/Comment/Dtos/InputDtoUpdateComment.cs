namespace Application.UseCases.Comment.Dtos
{
    public class InputDtoUpdateComment
    {
        public int Id { get; set; }
        public Comment InternComment { get; set; }

        public class Comment
        {
            public string Content { get; set; }
        }
    }
}