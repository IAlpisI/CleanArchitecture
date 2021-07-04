using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Tournament.Commands.CreateTournament
{
    public class CreateTournamentCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string GameName { get; set; }
        public int PlayerCount { get; set; }
        public bool OpenSignUp { get; set; }
    }

    public class CreateTournamentCommandHandler : IRequestHandler<CreateTournamentCommand, int>
    {
        public async Task<int> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
        {

        }
    }
}
