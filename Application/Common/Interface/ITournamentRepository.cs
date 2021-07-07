using Domain.Entities.Tournament;

namespace Application.Common.Interface
{
    public interface ITournamentRepository : IAsyncRepository<Tournament>
    {
    }
}
