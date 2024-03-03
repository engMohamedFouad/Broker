using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.Plans.Commands.Models
{
    public class DeletePlanCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
