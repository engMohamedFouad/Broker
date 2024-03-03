using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.Managements.Commands.Models
{
    public class UpdateManagementCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public int PartyId { get; set; }
    }
}
