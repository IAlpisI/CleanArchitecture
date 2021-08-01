using Ardalis.Specification;
using Domain.Entities.TournamentAggregate;

namespace Application.Specification
{
    public class MatchesById : Specification<Match>, ISingleResultSpecification 
    {
        public MatchesById(int matchId)
        {
            Query.Where(x => x.Id == matchId);
        }
    }
}
