using FluentValidation;

namespace Application.Features.Tournaments.Commands.CreateTournament
{
    public class CreateTournamentCommandValidation : AbstractValidator<CreateTournamentCommand>
    {
        public CreateTournamentCommandValidation()
        {
            RuleFor(v => v.PlayerCount)
                .GreaterThanOrEqualTo(2)
                .LessThanOrEqualTo(512).WithMessage("PlayerCount at least greater than or equal to 2 but less than or equal to 512.");
        }
    }
}
