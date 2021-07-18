using Domain.Entities.Common;
using Domain.Enums;

namespace Domain.Entities.Tournament
{
    public class Match : ModificationEntity
    {
        public MatchState State { get; private set; } = MatchState.Waitting;
        public int WinnerId { get; private set; }
        public int Round { get; private set; }
        public int MatchIndex { get; private set; }
        public int PlayerOneScore { get; private set; }
        public int PlayerTwoScore { get; private set; }
        public int PlayerOneId { get; private set; }
        public int PlayerTwoId { get; private set; }
        public int MaxScore { get; private set; }
        public Tournament Tournament { get; private set; }
        public int? TournamentId { get; private set; }

        public Match() { }

        public Match(int round, int matchIndex)
        {
            Round = round;
            MatchIndex = matchIndex;
        }
        public void UpdateScore(int scoreOne, int scoreTwo, MatchState state)
        {
            PlayerOneScore = scoreOne;
            PlayerTwoScore = scoreTwo;

            UpdateState(state);
        }

        public void UpdateState(MatchState state)
        {
            State = state;
        }

        public void AddPalyer(int playerId, int playerPosition)
        {
            switch (playerPosition)
            {
                case 1:
                    PlayerOneId = playerId;
                    break;
                case 0:
                    PlayerTwoId = playerId;
                    break;
                default: break;
            }
            
            if(PlayerOneId !=0 && PlayerTwoId != 0)
            {
                State = MatchState.Started;
            }
        }

        public void RemovePlayer(int playerPosition)
        {
            switch (playerPosition)
            {
                case 1:
                    PlayerOneId = 0;
                    break;
                case 0:
                    PlayerTwoId = 0;
                    break;
                default: break;
            }
        }

        public void UpdateScore(int playerId, int scoreOne, int scoreTwo)
        {
            if(scoreOne == MaxScore)
            {
                WinnerId = playerId;
                State = MatchState.Finished;
            }

            PlayerOneScore = scoreOne;
            PlayerTwoScore = scoreTwo;
        }
    }
}
