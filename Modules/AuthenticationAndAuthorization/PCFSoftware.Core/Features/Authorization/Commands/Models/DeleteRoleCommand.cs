using MediatR;
using Broker.Core.Bases;

namespace Broker.AuthenticationAndAuthorization.Core.Features.Authorization.Commands.Models
{
    public class DeleteRoleCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteRoleCommand(int id)
        {
            Id = id;
        }
    }
}
