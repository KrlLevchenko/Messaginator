using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Messaginator.Sender.Api.Send
{
    public class Request: IRequest<Response>
    {
        [FromBody] public MessageDto Message { get; set; }
    }
}