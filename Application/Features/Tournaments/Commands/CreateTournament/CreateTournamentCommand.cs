using MediatR;
using Domain.Entities.TournamentAggregate;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interface;

namespace Application.Features.Tournaments.Commands.CreateTournament
{
    public class CreateTournamentCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string GameName { get; set; }
        public int PlayerCount { get; set; }
    }

    public class CreateTournamentCommandHandler : IRequestHandler<CreateTournamentCommand, int>
    {
        private readonly ITournamentRepository _tournamentRepository;

        public CreateTournamentCommandHandler(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public async Task<int> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Tournament(request.Name,
                                        request.GameName,
                                        request.PlayerCount);

            await _tournamentRepository.AddAsync(entity, cancellationToken);

            return entity.Id;
        }
    }
}
