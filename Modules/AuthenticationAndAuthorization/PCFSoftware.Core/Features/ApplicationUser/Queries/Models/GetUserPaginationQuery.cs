using MediatR;
using Broker.AuthenticationAndAuthorization.Core.Features.ApplicationUser.Queries.Results;
using Broker.Core.Wrappers;

namespace Broker.AuthenticationAndAuthorization.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserPaginationQuery : IRequest<PaginatedResult<GetUserPaginationReponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
