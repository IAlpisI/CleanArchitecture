using Domain.Entities.Particapant;
using Domain.Entities.TournamentAggregate;
using Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests.Application.Entities.TournamentTests
{
    public class TournamentTest
    {
        private readonly string tournamentName = "test";
        private readonly string tournamentGameName = "gameTest";
        private readonly int matchFirstRound = 1;
        private readonly int playerCount = 2;
        private readonly int matchIndex = 1;

        [Fact]
        public void AddPlayerToTheTournamentIfThereIsSpace()
        {
            var user = new User();
            var tournament = GetTournament();

            tournament.AddPlayer(user);

            Assert.Single(tournament.Users);
        }

        [Fact]
        public void RemovePlayerFromTheTournament()
        {
            var user = new User();
            var tournament = GetTournament();

            tournament.AddPlayer(user);

            Assert.Single(tournament.Users);
        }

        [Fact]
        public void CantAddPlayerIfTournamentIsFull()
        {
            var users = new List<User>();
            var tournament = GetTournament();

            for (int x = 0; x < 3; x++)
            {
                users.Add(new User(x));
            }

            foreach(var user in users)
            {
                tournament.AddPlayer(user);
            }

            Assert.Equal(tournament.PlayerCount, tournament.Users.Count());
        }

        [Fact]
        public void AddMatchToTheTournament()
        {
            var match = new Match();
            var tournament = GetTournament();

            tournament.AddMatch(match);

            Assert.Single(tournament.Matches);
        }

        [Fact]
        public void FinishTournamentThenLastMatchHasEnded()
        {
            var match = new Match(1, matchFirstRound, matchIndex);
            var tournament = GetTournament();

            tournament.AddMatch(match);
            tournament.ProccedMatch(match.Id);

            Assert.Equal(TournamentState.Finished, tournament.State);
        }

        public Tournament GetTournament()
        {
            return new Tournament(
                tournamentName,
                tournamentGameName,
                playerCount);
        }
    }
}
