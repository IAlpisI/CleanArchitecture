using Domain.Entities;
using Infastructure.Data.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Data.Repositories.TournamentRepository
{
    public class TournamentRepository : EfRepository<Tournament>
    {
        public TournamentRepository(ApplicationDbContext dbContext) : base (dbContext)
        {

        }
    }
}
