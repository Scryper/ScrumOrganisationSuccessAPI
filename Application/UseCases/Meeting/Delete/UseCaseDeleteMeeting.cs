using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Meeting;

namespace Application.UseCases.Meeting.Delete
{
    public class UseCaseDeleteMeeting : IWriting<bool, int>
    {
        private readonly IMeetingRepository _meetingRepository;

        public UseCaseDeleteMeeting(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public bool Execute(int data)
        {
            return _meetingRepository.Delete(data);
        }
    }
}