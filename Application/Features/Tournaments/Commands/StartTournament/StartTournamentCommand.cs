using Application.Common.Interface;
using MediatR;
using Domain.Enums;
using System.Threading;
using System.Threading.Tasks;
using System;
using Application.Extensions;
using Domain.Entities.Tournament;

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
            int index = 0;
            var tournament = await _tournamentRepository.GetByIdAsync(request.TournamentId, cancellationToken: cancellationToken);
            var totalRounds = (int)Math.Ceiling(Math.Log2(tournament.Players.Count));
            var firstRoundMatches = (int)Math.Pow(2, (totalRounds - 1));
            var players = tournament.Players;
            var totalPlayer = players.Count;
            var matches = tournament.Matches;

            players.Shuffle();
            tournament.AddMatch(1, 1);

            for (var x = 1; x < totalRounds; x++)
            {
                for (var y = 1; y <= (int)(Math.Pow(x, 2) / 2); y++)
                {
                    tournament.AddMatch(x, y);
                }
            }

            for(int x = 1; x <= firstRoundMatches; x++)
            {
                var match = new Match(firstRoundMatches, index);
                match.AddPalyer(players[x].Id, 0);

                if(firstRoundMatches + x <= totalPlayer)
                {
                    match.AddPalyer(players[firstRoundMatches+x].Id, 1);
                }

                matches.Add(match);
            }          

            for(int x = 0; x < matches.Count; x++)
            {
                if(matches[x].PlayerTwoId == 0)
                {
                    tournament.ProccedMatch(matches[x].Id);
                }
            }

            tournament.SetMatches(matches);
            tournament.SetTournamentState(TournamentState.Started);

            //await _tournamentRepository.UpdateAsync(tournament, cancellationToken);

            return Unit.Value;
        }
    }
}
