using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.PointComments.Commands.Models
{
    public class AddPointCommentsCommand : IRequest<Response<string>>
    {
        public string? Content { get; set; }
        public int PointId { get; set; }
        public int? ParentId { get; set; }
    }
}
