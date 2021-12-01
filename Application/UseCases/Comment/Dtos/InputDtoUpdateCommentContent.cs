namespace Application.UseCases.Comment.Dtos
{
    public class InputDtoUpdateCommentContent
    {
        public int Id { get; set; }
        public Comment InternComment { get; set; }

        public class Comment
        {
            public string Content { get; set; }
        }
    }
}