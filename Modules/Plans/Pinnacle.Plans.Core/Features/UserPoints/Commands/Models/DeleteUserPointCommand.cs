using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.UserPoints.Commands.Models
{
    public class DeleteUserPointCommand : IRequest<Response<string>>
    {
        public int PointId { get; set; }
        public int UserId { get; set; }
    }
}

