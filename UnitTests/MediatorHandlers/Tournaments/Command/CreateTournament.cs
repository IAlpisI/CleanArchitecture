using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Application.Common.Interface;
using Domain.Entities.TournamentAggregate;
using Application.Features.Tournaments.Commands.CreateTournament;

namespace UnitTests.MediatorHandlers.Tournaments.Command
{
    public class CreateTournament
    {
        private readonly Mock<ITournamentRepository> _mockTournamentRepository;

        public CreateTournament()
        {
            _mockTournamentRepository = new Mock<ITournamentRepository>();
            _mockTournamentRepository.Setup(x => x.AddAsync(It.IsAny<Tournament>(), default)).ReturnsAsync(new Tournament());
        }

        [Fact]
        public void CheckIfPlayerCountFieldIsValid()
        {
            var command = new CreateTournamentCommand
            {
                GameName = "Test",
                Name = "Test",
                PlayerCount = 1,
            };

            var handler = new CreateTournamentCommandHandler(_mockTournamentRepository.Object);

            FluentActions.Invoking(() =>
                handler.Handle(command, default)).Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task CreateTournamentIfFeildsAreCorrectAsync()
        {
            var command = new CreateTournamentCommand
            {
                GameName = "Test",
                Name = "Test",
                PlayerCount = 4,
            };

            var handler = new CreateTournamentCommandHandler(_mockTournamentRepository.Object);

            var result = await handler.Handle(command, default);

            Assert.NotNull(result.ToString());
        }
    }
}
