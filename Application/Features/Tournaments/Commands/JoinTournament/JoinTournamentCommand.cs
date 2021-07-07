using Application.Common.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Tournaments.Commands.JoinTournament
{
    public class JoinTournamentCommand : IRequest
    {
        public int TournamenId { get; set; }
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
            var tournament = await _tournamentRepository.GetByIdAsync(request.TournamenId, cancellationToken: cancellationToken);

            tournament.AddPlayer(user);

            return Unit.Value;
        }
    }
}
