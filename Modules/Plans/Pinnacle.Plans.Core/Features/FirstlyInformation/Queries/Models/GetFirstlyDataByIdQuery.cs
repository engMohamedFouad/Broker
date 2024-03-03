using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Core.Features.FirstlyInformation.Queries.Results;

namespace Pinnacle.Plans.Core.Features.FirstlyInformation.Queries.Models
{
    public class GetFirstlyDataByIdQuery : IRequest<Response<GetFirstlyDataByIdResult>>
    {
        public int Id { get; set; }
    }
}
