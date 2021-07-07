using Application.Common.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Tournaments.Commands.StartTournament
{
    public class StartTournamentCommand : IRequest
    {
        public int TournamentId { get; set; }
    }

    public class StartTournamentCommandHandler : IRequestHandler<StartTournamentCommand>
    {
        private readonly ITournamentRepository _tournamentRepository;

        public StartTournamentCommandHandler(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public async Task<Unit> Handle(StartTournamentCommand request, CancellationToken cancellationToken)
        {

            return Unit.Value;
        }
    }
}
