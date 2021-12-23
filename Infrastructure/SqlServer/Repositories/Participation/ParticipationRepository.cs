﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Participation
{
    public partial class ParticipationRepository : IParticipationRepository
    {

        private readonly IDomainFactory<Domain.Participation> _participationFactory = new ParticipationFactory();
        
        // Get requests
        public List<Domain.Participation> GetAll()
        {
            var participations = new List<Domain.Participation>();

            var command = Database.GetCommand(ReqGetAll);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) participations.Add(_participationFactory.CreateFromSqlReader(reader));
            
            return participations;
        }

        // Utils for GetByIdUser and GetByIdMeeting
        // Both return a list of participations, the only changing parameters are the request and the column on which 
        // the request base its verification
        private List<Domain.Participation> GetByIdHelper(int id, string column, string request)
        {
            var participations = new List<Domain.Participation>();
            
            var command = Database.GetCommand(request);
            
            // Parametrize the command
            command.Parameters.AddWithValue("@" + column, id);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            while(reader.Read()) participations.Add(_participationFactory.CreateFromSqlReader(reader));
            
            return participations;
        }
        
        public List<Domain.Participation> GetByIdUser(int idUser)
        {
            return GetByIdHelper(idUser, ColIdUser, ReqGetByIdUser);
        }

        public List<Domain.Participation> GetByIdMeeting(int idMeeting)
        {
            return GetByIdHelper(idMeeting, ColIdMeeting, ReqGetByIdMeeting);
        }

        // Post requests
        public Domain.Participation Create(Domain.Participation participation)
        {
            if (Exists(participation)) return null;
            
            var command = Database.GetCommand(ReqCreate);

            command.Parameters.AddWithValue("@" + ColIdUser, participation.IdUser);
            command.Parameters.AddWithValue("@" + ColIdMeeting, participation.IdMeeting);

            command.ExecuteNonQuery();
            
            return new Domain.Participation
            {
                IdMeeting = participation.IdMeeting,
                IdUser = participation.IdUser
            };
        }
        
        // Utils for post request
        private bool Exists(Domain.Participation participation)
        {
            var participations = GetAll();

            return Enumerable.Contains(participations, participation);
        }

        // Delete request
        public bool Delete(int idUser, int idMeeting)
        {
            var command = Database.GetCommand(ReqDelete);

            command.Parameters.AddWithValue("@" + ColIdUser, idUser);
            command.Parameters.AddWithValue("@" + ColIdMeeting, idMeeting);

            return command.ExecuteNonQuery() > 0;
        }
    }
}