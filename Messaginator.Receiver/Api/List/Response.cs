using System.Collections.Generic;

namespace Messaginator.Receiver.Api.List
{
    public class Response
    {
        public IEnumerable<MessageDto> Messages { get; set; }
    }
}