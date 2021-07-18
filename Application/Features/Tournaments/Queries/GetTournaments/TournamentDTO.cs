using Application.Common.Mappings;
using Domain.Entities.Particapant;
using Domain.Entities.Tournament;
using System.Collections.Generic;

namespace Application.Features.Tournaments.Queries.GetTournaments
{
    public class TournamentDTO : IMapFrom<Tournament>
    {
        public string Name { get; set; }
        public string GameName { get; set; }
        public string State { get; set; }
        public int PalyerCount { get; set; }
        public List<User> Players { get; set; }
        public List<Match> Matches { get; set; }
    }
}
