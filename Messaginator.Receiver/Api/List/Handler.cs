using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Messaginator.Receiver.Message;

namespace Messaginator.Receiver.Api.List
{
    public class Handler: IRequestHandler<Request, Response>
    {
        private readonly MessagesStore _messagesStore;

        public Handler(MessagesStore messagesStore)
        {
            _messagesStore = messagesStore;
        }
        public Task<Response> Handle(Request request, CancellationToken ct) =>
            Task.FromResult(new Response
            {
                Messages = _messagesStore.Get().Select(x => new MessageDto
                {
                    Author = x.Author,
                    Date = x.Created,
                    Id = x.Id,
                    Text = x.Text
                })
            });
    }
    
    
}