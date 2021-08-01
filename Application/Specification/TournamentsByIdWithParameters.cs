using Ardalis.Specification;
using Domain.Entities.TournamentAggregate;

namespace Application.Specification
{
    public class TournamentsByIdWithParameters: Specification<Tournament>, ISingleResultSpecification
    {
        public TournamentsByIdWithParameters(int tournamentId)
        {
            Query.Where(x => x.Id == tournamentId)
                .Include(x => x.Users)
                .Include(x => x.Matches);
        }
    }
}
