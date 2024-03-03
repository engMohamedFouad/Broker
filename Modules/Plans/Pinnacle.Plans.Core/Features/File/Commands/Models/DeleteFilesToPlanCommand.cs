using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.File.Commands.Models
{
    public class DeleteFilesToPlanCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
