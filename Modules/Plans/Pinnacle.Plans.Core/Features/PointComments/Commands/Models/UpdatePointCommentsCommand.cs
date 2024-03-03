using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.PointComments.Commands.Models
{
    public class UpdatePointCommentsCommand : AddPointCommentsCommand, IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
