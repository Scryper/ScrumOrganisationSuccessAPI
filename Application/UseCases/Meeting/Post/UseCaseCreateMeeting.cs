using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Meeting;

namespace Application.UseCases.Meeting.Post
{
    public class UseCaseCreateMeeting : IWriting<OutputDtoMeeting, InputDtoMeeting>
    {
        private readonly IMeetingRepository _meetingRepository;

        public UseCaseCreateMeeting(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public OutputDtoMeeting Execute(InputDtoMeeting dto)
        {
            var meetingFromDto = Mapper.GetInstance().Map<Domain.Meeting>(dto);
            
            var meeting = _meetingRepository.Create(meetingFromDto);
            
            return meeting == null ? null : Mapper.GetInstance().Map<OutputDtoMeeting>(meeting);
        }
    }
}