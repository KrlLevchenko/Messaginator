using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Messaginator.Sender.Api
{
    [Route("api/[controller]")]
    public class MessagesController: Controller
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public Task<Send.Response> SendMessage(Send.Request request) => _mediator.Send(request);
    }
}