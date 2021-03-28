using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Dodo.Primitives;
using Messaginator.Contracts;

namespace Messaginator.Receiver.Message
{
    public class MessagesStore
    {
        private readonly ConcurrentBag<IMessage> _messages = new ConcurrentBag<IMessage>();
        
        public IEnumerable<IMessage> Get() => _messages.ToList();

        public void Add(IMessage message) => _messages.Add(message ?? throw new ArgumentNullException(nameof(message)));
    }

}