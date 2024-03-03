using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Core.Features.Indicators.Commands.Models
{
    public class UpdateIndicatorCommand : AddIndicatorDTO, IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
