using Application.Common.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Enums;
using Application.Specification;

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
            var matchSpec = new MatchesById(request.MatchId);
            var tournamentSpec = new TournamentsByIdWithParameters(request.TournamentId);
            var match = await _matchRepository.FirstOrDefaultAsync(matchSpec , cancellationToken: cancellationToken);
            var tournament = await _tournamentRepository.FirstOrDefaultAsync(tournamentSpec, cancellationToken: cancellationToken);

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
