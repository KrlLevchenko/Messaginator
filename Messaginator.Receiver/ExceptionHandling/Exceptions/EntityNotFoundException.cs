using System;

namespace Messaginator.Receiver.ExceptionHandling.Exceptions
{
    public class EntityNotFoundException: Exception
    {
        public EntityNotFoundException(string entityName, string searchParams): base($"{entityName} not found by using {searchParams}")
        {
        }
    }
}