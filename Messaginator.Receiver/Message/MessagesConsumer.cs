using System.Threading.Tasks;
using MassTransit;
using Messaginator.Contracts;

namespace Messaginator.Receiver.Message
{
    public class MessagesConsumer: IConsumer<IMessage>
    {
        private readonly MessagesStore _messagesStore;

        public MessagesConsumer(MessagesStore messagesStore)
        {
            _messagesStore = messagesStore;
        }
        public Task Consume(ConsumeContext<IMessage> context)
        {
            _messagesStore.Add(context.Message);
            return Task.CompletedTask;
        }
    }
}