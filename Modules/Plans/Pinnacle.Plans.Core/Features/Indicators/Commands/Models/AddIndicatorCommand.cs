using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Core.Features.Indicators.Commands.Models
{
    public class AddIndicatorCommand : AddIndicatorDTO, IRequest<Response<string>>
    {
    }
}
