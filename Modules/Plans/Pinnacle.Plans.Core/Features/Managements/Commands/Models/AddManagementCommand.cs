using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.Managements.Commands.Models
{
    public class AddManagementCommand : IRequest<Response<string>>
    {
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public int PartyId { get; set; }
    }
}
