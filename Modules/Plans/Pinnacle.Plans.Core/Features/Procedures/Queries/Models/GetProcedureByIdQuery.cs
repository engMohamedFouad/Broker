using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Core.Features.Procedures.Queries.Results;

namespace Pinnacle.Plans.Core.Features.Procedures.Queries.Models
{
    public class GetProcedureByIdQuery : IRequest<Response<GetProcedureByIdResult>>
    {
        public int Id { get; set; }
    }
}
