using Domain.Entities.TournamentAggregate;
using Domain.Enums;
using System;
using Xunit;

namespace UnitTests.Application.Entities.MatchTests
{
    public class MatchTest
    {
        private readonly int matchRound = 1;
        private readonly int matchIndex = 1;
        private readonly int maxScore = 3;

        [Fact]
        public void UpdateMatchAttributes()
        {
            var match = GetMatch();

            match.UpdateScore(1, maxScore, 1, MatchState.Started);

            Assert.Equal(maxScore, match.MaxScore);
        }

        [Fact]
        public void CantModifyAttributesWithNegeativeNumbers()
        {
            var match = GetMatch();

            Assert.Throws<ArgumentOutOfRangeException>(() => match.UpdateScore(-1, maxScore, 1, MatchState.Started));
        }

        [Fact]
        public void PlayerIsAddedToTheMatch()
        {
            var match = GetMatch();

            match.AddPalyer(1, 1);

            Assert.Equal(1, match.PlayerOneId);
        }

        [Fact]
        public void RemovePlayerFromMatch()
        {
            var match = GetMatch();

            match.AddPalyer(1, 1);
            match.RemovePlayer(1);

            Assert.Equal(0, match.PlayerOneId);
        }

        public Match GetMatch()
        {
            return new Match(
                matchRound,
                matchIndex);
        }
    }
}
