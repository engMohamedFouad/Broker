using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.FirstlyInformation.Commands.Models
{
    public class AddFirstlyDataCommand : IRequest<Response<string>>
    {
        public string? DescriptionAr { get; set; }
        public string? DescriptionEn { get; set; }
        public int ReviewId { get; set; }
    }
}
