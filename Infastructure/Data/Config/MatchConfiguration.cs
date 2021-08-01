using Domain.Entities.TournamentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infastructure.Data.Config
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.Property(m => m.MatchIndex)
                .IsRequired();

            builder.Property(m => m.Round)
                .IsRequired();
        }
    }
}
