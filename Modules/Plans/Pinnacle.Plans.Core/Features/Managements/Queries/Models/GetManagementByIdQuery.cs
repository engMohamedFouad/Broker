using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Core.Features.Managements.Queries.Results;

namespace Pinnacle.Plans.Core.Features.Managements.Queries.Models
{
    public class GetManagementByIdQuery : IRequest<Response<GetManagementByIdResult>>
    {
        public int Id { get; set; }
    }
}
