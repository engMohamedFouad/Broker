using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Core.Features.ProceduresDetails.Queries.Results;

namespace Pinnacle.Plans.Core.Features.ProceduresDetails.Queries.Models
{
    public class GetProcedureDetailsByIdQuery : IRequest<Response<GetProcedureDetailsByIdResult>>
    {
        public int Id { get; set; }
    }
}
