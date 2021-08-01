using Application.Common.Interface;
using Application.Features.Tournaments.Commands.JoinTournament;
using Ardalis.Specification;
using Domain.Entities.Particapant;
using Domain.Entities.TournamentAggregate;
using MediatR;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.MediatorHandlers.Tournaments.Command
{
    public class JoinTournament
    {
        private readonly Mock<ITournamentRepository> _mockTournamentRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;

        public JoinTournament()
        {
            _mockTournamentRepository = new Mock<ITournamentRepository>();
            _mockUserRepository = new Mock<IUserRepository>();

            _mockUserRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>(), default)).ReturnsAsync(new User(1));
            _mockTournamentRepository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<ISpecification<Tournament>>(), default)).ReturnsAsync(new Tournament());
            _mockTournamentRepository.Setup(x => x.UpdateAsync(It.IsAny<Tournament>(), default)).Returns(Task.CompletedTask);
        }

        [Fact]
        public async Task UserJoinedTheTournamentAsync()
        {
            var command = new JoinTournamentCommand
            {
                TournamentId = 1,
                UserId = 1,
            };

            var handler = new JoinTournamentCommandHandler(_mockTournamentRepository.Object, _mockUserRepository.Object);

            var result = await handler.Handle(command, default);

            Assert.Equal(result, Unit.Value);
        }
    }
}
