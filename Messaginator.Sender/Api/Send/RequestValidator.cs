using FluentValidation;

namespace Messaginator.Sender.Api.Send
{
    public class RequestValidator: AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(x => x.Message).NotNull();
            RuleFor(x => x.Message).SetValidator(new MessageValidator());
        }
    }

    public class MessageValidator : AbstractValidator<MessageDto>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Author).NotNull();
            RuleFor(x => x.Text).NotNull();
        }
    }
}