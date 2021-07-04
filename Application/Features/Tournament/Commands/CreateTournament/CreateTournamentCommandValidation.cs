using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tournament.Commands.CreateTournament
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
