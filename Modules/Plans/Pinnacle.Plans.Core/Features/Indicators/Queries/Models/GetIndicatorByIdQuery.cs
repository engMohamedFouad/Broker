using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Core.Features.Indicators.Queries.Models
{
    public class GetIndicatorByIdQuery : IRequest<Response<GetIndicatorByIdDTO>>
    {
        public int Id { get; set; }
    }
}
