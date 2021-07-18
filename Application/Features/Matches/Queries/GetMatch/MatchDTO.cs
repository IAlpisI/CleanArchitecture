namespace Application.Features.Matches.Queries.GetMatch
{
    public class MatchDTO
    {
        public string State { get; set; }
        public int WinnerId { get; set; }
        public int Round { get; set; }
        public int MatchIndex { get; set; }
        public int PlayerOneScore { get; set; }
        public int PlayerTwoScore { get; set; }
        public int PlayerOneId { get; set; }
        public int PlayerTwoId { get; set; }
        public int MaxScore { get; set; }
    }
}
