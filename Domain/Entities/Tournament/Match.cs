using Domain.Entities.Common;
using Domain.Enums;

namespace Domain.Entities.Tournament
{
    public class Match : ModificationEntity
    {
        public MatchState State { get; private set; } = MatchState.Waitting;
        public string PlayerOneId { get; private set; }
        public string PlayerTwoId { get; private set; }
        public string WinnerId { get; private set; }
        public string LoserId { get; private set; }
        public int Round { get; private set; }
        public int MatchIndex { get; private set; }
        public int PlayerOneScore { get; private set; }
        public int PlayerTwoScore { get; private set; }
        public Tournament Tournament { get; private set; }
        public int? TournamentId { get; private set; }

        public Match() { }

        public Match(int round, int matchIndex)
        {
            Round = round;
            MatchIndex = matchIndex;
        }

    }
}
