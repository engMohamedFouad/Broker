using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.Procedures.Commands.Models
{
    public class AddProcedureCommand : IRequest<Response<string>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool IsGeneral { get; set; } = false;
        public int? IndicatorId { get; set; }
        public int? PlanId { get; set; }
    }
}
