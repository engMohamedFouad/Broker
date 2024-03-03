using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.Managements.Commands.Models
{
    public class DeleteManagementCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
