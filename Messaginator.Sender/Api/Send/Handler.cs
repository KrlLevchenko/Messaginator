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
            await _busControl.Publish<IMessage>(new Message(request.Message), ct);
            return new Response
            {
                Id = Uuid.NewMySqlOptimized()
            }; 
        }
    }
    
    
}