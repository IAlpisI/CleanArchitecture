using Application.Common.Interface;
using Domain.Entities.TournamentAggregate;
using Infastructure.Data.Repositories.Generic;

namespace Infastructure.Data.Repositories.TournamentRepository
{
    public class TournamentRepository : EfRepository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(ApplicationDbContext dbContext) : base (dbContext)
        {

        }
    }
}
