using Application.Common.Interface;
using Application.Specification;
using AutoMapper;
using Domain.Entities.TournamentAggregate;
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Tournament, TournamentDTO>());
            var mapper = new Mapper(config);

            var tournament = await _tournamenRepository.FirstOrDefaultAsync(new TournamentsByIdWithParameters(request.TournamentId), cancellationToken: cancellationToken);

            return _mapper.Map<TournamentDTO>(tournament);
        }
    }
}
