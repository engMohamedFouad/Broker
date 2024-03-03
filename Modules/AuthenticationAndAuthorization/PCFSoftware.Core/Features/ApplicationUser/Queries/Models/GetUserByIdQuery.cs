using MediatR;
using Broker.AuthenticationAndAuthorization.Core.Features.ApplicationUser.Queries.Results;
using Broker.Core.Bases;

namespace Broker.AuthenticationAndAuthorization.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
