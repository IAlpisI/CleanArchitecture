using Application.Common.Interface;
using Domain.Entities.Tournament;
using Infastructure.Data.Repositories.Generic;

namespace Infastructure.Data.Repositories.MatchRepository
{
    public class MatchRepository : EfRepository<Match>, IMatchRepository
    {
        public MatchRepository(ApplicationDbContext dbContext) : base (dbContext)
        {

        }
    }
}
