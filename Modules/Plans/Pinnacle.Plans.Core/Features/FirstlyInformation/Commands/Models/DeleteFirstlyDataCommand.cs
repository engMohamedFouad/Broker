using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.FirstlyInformation.Commands.Models
{
    public class DeleteFirstlyDataCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
