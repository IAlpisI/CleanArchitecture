using Domain.Constant;
using Domain.Entities.Common;
using Domain.Entities.Particapant;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities.Tournament
{
    public class Tournament: ModificationEntity
    {
        public string Name { get; private set; }
        public string GameName { get; private set; }
        public int PlayerCount { get; private set; }
        public TournamentState State { get; private set; } = TournamentState.Opened;
        public List<User> Players { get; private set; } = new List<User>();
        public List<Match> Matches { get; private set; } = new List<Match>();

        public Tournament(string name, string gameName, int playerCount)
        {
            Name = name;
            GameName = gameName;
            PlayerCount = playerCount;
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
            Players.Remove(player);
        }

        public void AddMatch(int round, int matchIndex)
        {
            Matches.Add(new Match(round, matchIndex));
        }

        public void SetMatches(List<Match> matches)
        {
            Matches = matches;
        }
    }
}
