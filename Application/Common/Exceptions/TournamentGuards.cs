using Ardalis.GuardClauses;
using Domain.Entities.TournamentAggregate;

namespace Application.Common.Exceptions
{
    public static class TournamentGuards
    {
        public static void NullTournaments(this IGuardClause guardClause, int id, Tournament tournament)
        {
            if(tournament == null)
            {
                throw new NotFoundException(id, nameof(tournament));
            }
        }

        public static void NullMatches(this IGuardClause guardClause, int id, Match match)
        {
            if(match == null)
            {
                throw new NotFoundException(id, nameof(match));
            }
        }
    }
}
