using System;
using Dodo.Primitives;

namespace Messaginator.Contracts
{
    public interface IMessage
    {
        Uuid Id { get; }
        
        DateTime Created { get; }
        
        string Author { get; }

        string Text { get; }
    }
}