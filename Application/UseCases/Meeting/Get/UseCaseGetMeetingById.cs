using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Meeting;

namespace Application.UseCases.Meeting.Get
{
    public class UseCaseGetMeetingById : IQueryFiltering<OutputDtoMeeting, int>
    {
        private readonly IMeetingRepository _meetingRepository;

        public UseCaseGetMeetingById(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public OutputDtoMeeting Execute(int filter)
        {
            var meeting = _meetingRepository.GetById(filter);

            return Mapper.GetInstance().Map<OutputDtoMeeting>(meeting);
        }
    }
}