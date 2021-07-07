using MediatR;
using Domain.Entities.Tournament;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interface;
using System;

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
            var totalRounds = (int)Math.Ceiling(Math.Log2(request.PlayerCount));

            var entity = new Tournament(request.Name,
                                        request.GameName,
                                        request.PlayerCount,
                                        totalRounds);

            entity.AddMatch(1, 1);

            for (var x=1; x <= totalRounds; x++)
            {
                for(var y = 1; y <= (int)(Math.Pow(x, 2) / 2); y++)
                {
                    entity.AddMatch(x, y);
                }
            }

            await _tournamentRepository.AddAsync(entity, cancellationToken);

            return entity.Id;
        }
    }
}
