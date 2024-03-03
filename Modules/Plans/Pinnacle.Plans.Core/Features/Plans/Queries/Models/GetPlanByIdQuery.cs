using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Core.Features.Plans.Queries.Results;

namespace Pinnacle.Plans.Core.Features.Plans.Queries.Models
{
    public class GetPlanByIdQuery : IRequest<Response<GetPlanByIdResult>>
    {
        public int Id { get; set; }
    }
}
