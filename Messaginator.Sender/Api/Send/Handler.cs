using System.Threading;
using System.Threading.Tasks;
using Dodo.Primitives;
using MassTransit;
using MediatR;
using Messaginator.Contracts;

namespace Messaginator.Sender.Api.Send
{
    public class Handler: IRequestHandler<Request, Response>
    {
        private readonly IBusControl _busControl;

        public Handler(IBusControl busControl)
        {
            _busControl = busControl;
        }
        public async Task<Response> Handle(Request request, CancellationToken ct)
        {
            var message = new Message(request.Message);
            await _busControl.Publish<IMessage>(message, ct);
            return new Response
            {
                Id = message.Id
            }; 
        }
    }
    
    
}