using Application.Common.Mappings;
using Domain.Entities.Particapant;
using Domain.Entities.TournamentAggregate;
using System.Collections.Generic;
using AutoMapper;
using System;
using Domain.Enums;

namespace Application.Features.Tournaments.Queries.GetTournaments
{

    public class CurrencyFormatter : IValueConverter<TournamentState, string>
    {
        public string Convert(TournamentState source, ResolutionContext context)
            => Enum.GetName(typeof(TournamentState), source);
    }
    public class TournamentDTO : IMapFrom<Tournament>
    {
        public string Name { get; set; }
        public string GameName { get; set; }
        public string State { get; set; }
        public int PlayerCount { get; set; }
        public List<User> Users { get; set; }
        public List<Match> Matches { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tournament, TournamentDTO>()
                .ForMember(x => x.State, opt => opt.ConvertUsing(new CurrencyFormatter()));
        }
    }
}
