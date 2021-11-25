using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Meeting;

namespace Application.UseCases.Meeting.Put
{
    public class UseCaseUpdateMeetingSchedule : IWriting<bool, InputDtoUpdateScheduleMeeting>
    {
        private readonly IMeetingRepository _meetingRepository;

        public UseCaseUpdateMeetingSchedule(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public bool Execute(InputDtoUpdateScheduleMeeting data)
        {
            return _meetingRepository.UpdateSchedule(data.Id, data.InternMeeting.Schedule);
        }
    }
}