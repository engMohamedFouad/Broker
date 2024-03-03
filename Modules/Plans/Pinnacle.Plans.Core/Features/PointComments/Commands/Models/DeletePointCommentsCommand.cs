using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.PointComments.Commands.Models
{
    public class DeletePointCommentsCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
