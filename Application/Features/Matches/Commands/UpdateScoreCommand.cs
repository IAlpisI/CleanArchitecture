using Application.Common.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Features.Matches.Commands
{
    public class UpdateScoreCommand : IRequest
    {
        public int PlayerId { get; set; }
        public int MatchId { get; set; }
        public int TournamentId { get; set; }
        public int PlayerOneScore { get; set; }
        public int PlayerTwoScore { get; set; }
    }

    public class UpdateScoreCommandHandler : IRequestHandler<UpdateScoreCommand>
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMatchRepository _matchRepository;

        public UpdateScoreCommandHandler(ITournamentRepository tournamentRepository, IMatchRepository matchRepository)
        {
            _tournamentRepository = tournamentRepository;
            _matchRepository = matchRepository;
        }
        public async Task<Unit> Handle(UpdateScoreCommand request, CancellationToken cancellationToken)
        {
            var match = await _matchRepository.GetByIdAsync(request.MatchId, cancellationToken: cancellationToken);
            var tournament = await _tournamentRepository.GetByIdAsync(request.TournamentId, cancellationToken: cancellationToken);

            match.UpdateScore(request.PlayerId,
                              request.PlayerOneScore,
                              request.PlayerTwoScore);

            if(match.State == MatchState.Finished)
            {
                tournament.ProccedMatch(match.Id);
            }

            return Unit.Value;
        }
    }
}
