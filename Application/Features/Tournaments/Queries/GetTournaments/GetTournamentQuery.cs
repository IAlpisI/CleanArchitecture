using Application.Common.Interface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Tournaments.Queries.GetTournaments
{
    public class GetTournamentQuery : IRequest<TournamentDTO>
    {
        public int TournamentId { get; set; }
    }

    public class GetTournamentQueryHandler : IRequestHandler<GetTournamentQuery, TournamentDTO>
    {
        private readonly IMapper _mapper;
        private readonly ITournamentRepository _tournamenRepository;

        public GetTournamentQueryHandler(IMapper mapper, ITournamentRepository tournamentRepository)
        {
            _mapper = mapper;
            _tournamenRepository = tournamentRepository;
        }

        public async Task<TournamentDTO> Handle(GetTournamentQuery request, CancellationToken cancellationToken)
        {
            var tournament = await _tournamenRepository.GetByIdAsync(request.TournamentId, cancellationToken: cancellationToken);
            return _mapper.Map<TournamentDTO>(tournament);
        }
    }
}
