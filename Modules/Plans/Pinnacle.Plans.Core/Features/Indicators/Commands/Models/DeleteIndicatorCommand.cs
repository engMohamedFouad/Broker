using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.Indicators.Commands.Models
{
    public class DeleteIndicatorCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
