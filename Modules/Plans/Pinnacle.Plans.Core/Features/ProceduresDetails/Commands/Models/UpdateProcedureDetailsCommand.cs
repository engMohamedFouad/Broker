using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.ProceduresDetails.Commands.Models
{
    public class UpdateProcedureDetailsCommand : AddProcedureDetailsCommand, IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
