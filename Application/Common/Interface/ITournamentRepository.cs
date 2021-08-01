using Domain.Entities.TournamentAggregate;

namespace Application.Common.Interface
{
    public interface ITournamentRepository : IAsyncRepository<Tournament>
    {
    }
}
