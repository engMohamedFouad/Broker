using MediatR;
using Microsoft.AspNetCore.Http;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.ProceduresDetails.Commands.Models
{
    public class AddProcedureDetailsCommand : IRequest<Response<string>>
    {
        //procedure
        public int? ProcedureId { get; set; }
        //List of files that added in files table and Ids added to ProcedureDetails
        public List<IFormFile>? Files { get; set; }
        //in which plan
        public int PlanId { get; set; }
        //who create it
        public int UserId { get; set; }
        public string? Notes { get; set; }
        public bool? IsUpdated { get; set; }
    }
}
