using System;
using Dodo.Primitives;

namespace Messaginator.Receiver.Api.List
{
    public class MessageDto
    {
        public Uuid Id { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
    }
}