using System;

namespace Messaginator.Contracts
{
    public interface IMessage
    {
        DateTime Created { get; }
        
        string Author { get; }

        string Text { get; }
    }
}