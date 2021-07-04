using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Match: ModificationEntity
    {
        public string State { get; private set; }
        public string PlayerOneId { get; private set; }
        public string PlayerTwoId { get; private set; }
        public string Name { get; private set; }
        public string WinnerId { get; private set; }
        public string LoserId { get; private set; }
        public int Round { get; private set; }
        public int PlayerOneScore { get; private set; }
        public int PlayerTwoScore { get; private set; }
        public Tournament Tournament { get; private set; }
        public int? TournamentId { get; private set; }

    }
}
