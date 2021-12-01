using System.Collections.Generic;
using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Meeting;

namespace Application.UseCases.Meeting
{
    public class UseCaseGetAllMeetings : IQuery<List<OutputDtoMeeting>>
    {
        private readonly IMeetingRepository _meetingRepository;

        public UseCaseGetAllMeetings(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }
        
        public List<OutputDtoMeeting> Execute()
        {
            var meetingsFromDb = _meetingRepository.GetAll();

            return Mapper.GetInstance().Map<List<OutputDtoMeeting>>(meetingsFromDb);
        }
    }
}