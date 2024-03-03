using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Core.Features.File.Queries.Results;

namespace Pinnacle.Plans.Core.Features.File.Queries.Models
{
    public class GetFileByIdQuery : IRequest<Response<GetFileByIdResult>>
    {
        public int Id { get; set; }
    }
}
