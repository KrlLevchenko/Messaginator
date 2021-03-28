using System;
using Dodo.Primitives;
using Messaginator.Contracts;

namespace Messaginator.Sender.Api.Send
{
    public class Message: IMessage
    {
        public Message(MessageDto message)
        {
            Created = DateTime.Now;
            Author = message.Author;
            Text = message.Text;
            Id = Uuid.NewMySqlOptimized();
        }

        public Uuid Id { get; }
        public DateTime Created { get; }
        public string Author { get; }
        public string Text { get; }
    }
}