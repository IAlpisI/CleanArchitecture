using Application.Common.Interface;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Matches.Queries.GetMatch
{
    public class GetMatchQuery : IRequest<MatchDTO>
    {
        public int MatchId { get; set; }
    }

    public class GetMatchQueryHandler : IRequestHandler<GetMatchQuery, MatchDTO>
    {
        private readonly IMapper _mapper;
        private readonly IMatchRepository _matchRepository;

        public GetMatchQueryHandler(IMapper mapper, IMatchRepository matchRepository)
        {
            _mapper = mapper;
            _matchRepository = matchRepository;
        }

        public async Task<MatchDTO> Handle(GetMatchQuery request, CancellationToken cancellationToken)
        {
            var match = await _matchRepository.GetByIdAsync(request.MatchId);
            return _mapper.Map<MatchDTO>(match);
        }
    }
}
