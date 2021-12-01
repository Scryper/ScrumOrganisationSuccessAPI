using System.Collections.Generic;
using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Meeting;

namespace Application.UseCases.Meeting.Get
{
    public class UseCaseGetMeetingsByIdSprint : IQueryFiltering<List<OutputDtoMeeting>, int>
    {
        private readonly IMeetingRepository _meetingRepository;

        public UseCaseGetMeetingsByIdSprint(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public List<OutputDtoMeeting> Execute(int filter)
        {
            var meetings = _meetingRepository.GetByIdSprint(filter);

            return Mapper.GetInstance().Map<List<OutputDtoMeeting>>(meetings);
        }
    }
}