using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Comment
{
    public class CommentFactory : IDomainFactory<Domain.Comment>
    {
        public Domain.Comment CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Comment
            {
                Id = reader.GetInt32(reader.GetOrdinal(CommentRepository.ColId)),
                IdUserStory = reader.GetInt32(reader.GetOrdinal(CommentRepository.ColIdUserStory)),
                IdUser = reader.GetInt32(reader.GetOrdinal(CommentRepository.ColIdUser)),
                PostedAt = reader.GetDateTime(reader.GetOrdinal(CommentRepository.ColPostedAt)),
                Content = reader.GetString(reader.GetOrdinal(CommentRepository.ColContent))
            };
        }
    }
}