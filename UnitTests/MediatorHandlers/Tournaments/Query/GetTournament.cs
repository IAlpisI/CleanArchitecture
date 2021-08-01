using Application.Common.Interface;
using Application.Common.Mappings;
using Application.Features.Tournaments.Queries.GetTournaments;
using Ardalis.Specification;
using AutoMapper;
using Domain.Entities.TournamentAggregate;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.MediatorHandlers.Tournaments
{
    public class GetTournament
    {
        private readonly Mock<ITournamentRepository> _mockTournamentRepository;
        private readonly IMapper _mapper;
        public GetTournament()
        {
            var profile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            _mapper = new Mapper(configuration);
            _mockTournamentRepository = new Mock<ITournamentRepository>();

            _mockTournamentRepository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<ISpecification<Tournament>>(), default)).ReturnsAsync(new Tournament(1));
        }


        [Fact]
        public async Task ReturnTournamentIfItIsFoundAsync()
        {
            var query = new GetTournamentQuery
            {
                TournamentId = 1,
            };

            var handler = new GetTournamentQueryHandler(_mapper, _mockTournamentRepository.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
        }
    }
}
