using Domain.Constant;
using Domain.Entities.Common;
using Domain.Entities.Particapant;
using Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities.Tournament
{
    public class Tournament: ModificationEntity
    {
        public string Name { get; private set; }
        public string GameName { get; private set; }
        public int Rounds { get; private set; }
        public int PlayerCount { get; private set; }
        public TournamentState State { get; private set; } = TournamentState.Opened;
        public List<User> Players { get; private set; } = new List<User>();
        public List<Match> Matches { get; private set; } = new List<Match>();

        public Tournament(string name, string gameName, int playerCount, int rounds)
        {
            Name = name;
            GameName = gameName;
            PlayerCount = playerCount;
            Rounds = rounds;
        }

        public Tournament() { }

        public void AddPlayer(User player)
        {
            if(State != TournamentState.Opened ||
                Players.Any(p => p.Id == player.Id &&
                PlayerCount+1 <= TournamentSettings.MaxPlayer))
            {
                return;
            }
            Players.Add(player);
        }

        public void RemovePlayer(User player)
        {
            Players.Remove(player);
        }

        public void AddMatch(int round, int matchIndex)
        {
            Matches.Add(new Match(round, matchIndex));
        }
    }
}
