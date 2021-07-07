using Application.Features.Tournaments.Commands.CreateTournament;
using Application.Features.Tournaments.Commands.JoinTournament;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("[controller]")]
    public class TournamentController : Controller
    {
        private readonly ISender _mediator;
        public TournamentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return null;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTournamentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [Route("join")]
        [HttpPost]
        public async Task<ActionResult> Join(JoinTournamentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
