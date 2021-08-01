
using Ardalis.GuardClauses;
using Domain.Constant;
using Domain.Entities.Common;
using Domain.Entities.Particapant;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities.TournamentAggregate
{
    public class Tournament: ModificationEntity
    {
        public string Name { get; private set; }
        public string GameName { get; private set; }
        public int PlayerCount { get; private set; }
        public TournamentState State { get; private set; } = TournamentState.Opened;

        public IEnumerable<User> Users => _users.AsEnumerable();
        private readonly List<User> _users = new List<User>();
        public IEnumerable<Match> Matches => _matches.AsEnumerable();
        private readonly List<Match> _matches = new List<Match>();

        public Tournament(string name, string gameName, int playerCount)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(gameName, nameof(gameName));
            Guard.Against.OutOfRange(playerCount, nameof(playerCount), 2, TournamentSettings.MaxPlayers);

            Name = name;
            GameName = gameName;
            PlayerCount = playerCount;
        }

        public Tournament() { }

        public void AddPlayer(User player)
        {
            if(State != TournamentState.Opened ||
                Users.Any(p => p.Id == player.Id) ||
                _users.Count+1 > PlayerCount)
            {
                return;
            }
            _users.Add(player);
        }

        public void ProccedMatch(int matchId)
        {
            var currentMatch = Matches.First(x => x.Id == matchId);

            if(currentMatch.Round == 1)
            {
                State = TournamentState.Finished;
                return;
            }

            var nexMatch = Matches.First(x => x.Round == currentMatch.Round - 1 &&
                                              x.MatchIndex == Math.Round((double)currentMatch.MatchIndex/2));

            if(nexMatch != null)
            {
                if(currentMatch.MatchIndex % 2 == 0)
                {
                    nexMatch.AddPalyer(currentMatch.WinnerId, 1);
                } else
                {
                    nexMatch.AddPalyer(currentMatch.WinnerId, 0);
                }
            }
        }

        public void SetTournamentState(TournamentState state)
        {
            if(state != TournamentState.Opened)
            {
                State = state;
            }           
        }

        public void RemovePlayer(User player)
        {
            _users.Remove(player);
        }

        public void AddMatch(int round, int matchIndex)
        {
            _matches.Add(new Match(round, matchIndex));
        }

        public void AddMatch(Match match)
        {
            _matches.Add(match);
        }

        public Tournament(int id) => (Id) = (id);
    }
}
