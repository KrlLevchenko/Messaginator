using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Messaginator.Receiver.Api.List
{
    public class Request: IRequest<Response>
    {
    }
}