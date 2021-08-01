using Application.Common.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Enums;
using Application.Specification;

namespace Application.Features.Tournaments.Commands.JoinTournament
{
    public class JoinTournamentCommand : IRequest
    {
        public int TournamentId { get; set; }
        public int UserId { get; set; }
    }

    public class JoinTournamentCommandHandler : IRequestHandler<JoinTournamentCommand>
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IUserRepository _userRepository;

        public JoinTournamentCommandHandler(ITournamentRepository tournamentRepository,
            IUserRepository userRepository)
        {
            _tournamentRepository = tournamentRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(JoinTournamentCommand request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken: cancellationToken);
            var tournament = await _tournamentRepository.FirstOrDefaultAsync(new TournamentsByIdWithParameters(request.TournamentId), cancellationToken: cancellationToken);

            if(tournament.State == TournamentState.Opened)
            {
                tournament.AddPlayer(user);
            }

            await _tournamentRepository.UpdateAsync(tournament, cancellationToken);

            return Unit.Value;
        }
    }
}
