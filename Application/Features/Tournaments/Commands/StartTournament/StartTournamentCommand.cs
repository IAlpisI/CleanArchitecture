using Application.Common.Interface;
using MediatR;
using Domain.Enums;
using System.Threading;
using System.Threading.Tasks;
using System;
using Application.Extensions;
using Domain.Entities.TournamentAggregate;
using System.Linq;
using System.Collections.Generic;
using Application.Specification;

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
            var tournament = await _tournamentRepository.FirstOrDefaultAsync(new TournamentsByIdWithParameters(request.TournamentId), cancellationToken: cancellationToken);
            var players = tournament.Users.ToList();
            var matches = new List<Match>();
            var totalPlayer = players.Count;

            var totalRounds = (int)Math.Ceiling(Math.Log2(totalPlayer));
            var firstRoundMatches = (int)Math.Pow(2, (totalRounds - 1));

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
                var playerIndex = firstRoundMatches + x;
                var match = new Match(firstRoundMatches, x);
                match.AddPalyer(players[x - 1].Id, 0);

                if(playerIndex <= totalPlayer)
                {
                    match.AddPalyer(players[playerIndex - 1].Id, 1);
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

            foreach(var match in matches)
            {
                tournament.AddMatch(match);
            }

            tournament.SetTournamentState(TournamentState.Started);

            await _tournamentRepository.UpdateAsync(tournament, cancellationToken);

            return Unit.Value;
        }
    }
}
