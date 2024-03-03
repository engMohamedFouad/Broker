using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.Procedures.Commands.Models
{
    public class UpdateProcedureCommand : AddProcedureCommand, IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
