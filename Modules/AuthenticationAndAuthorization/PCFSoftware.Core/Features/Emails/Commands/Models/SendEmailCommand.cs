using MediatR;
using Broker.Core.Bases;

namespace Broker.AuthenticationAndAuthorization.Core.Features.Emails.Commands.Models
{
    public class SendEmailCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
