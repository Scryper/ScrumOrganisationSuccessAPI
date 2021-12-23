using System.Collections.Generic;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Technology
{
    public partial class TechnologyRepository : ITechnologyRepository
    {
        private readonly IDomainFactory<Domain.Technology> _technologyFactory = new TechnologyFactory();
        private readonly RequestHelper<Domain.Technology> _requestHelper = new RequestHelper<Domain.Technology>();

        // Get requests
        public List<Domain.Technology> GetAll()
        {
            return _requestHelper.GetAll(ReqGetAll, _technologyFactory);
        }

        public Domain.Technology GetByName(string name)
        {
            return _requestHelper.GetByName(name, ColName, ReqGetByName, _technologyFactory);
        }
    }
}