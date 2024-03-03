using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.ProceduresDetails.Commands.Models
{
    public class DeleteProcedureDetailsCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
