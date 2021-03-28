using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Messaginator.Receiver.Api
{
    [Route("api/[controller]")]
    public class MessagesController: Controller
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public Task<List.Response> List(List.Request request, CancellationToken ct) => _mediator.Send(request, ct);
    }
}