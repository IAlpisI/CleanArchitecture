using Domain.Entities.TournamentAggregate;

namespace Application.Common.Interface
{
    public interface IMatchRepository : IAsyncRepository<Match>
    {
    }
}
