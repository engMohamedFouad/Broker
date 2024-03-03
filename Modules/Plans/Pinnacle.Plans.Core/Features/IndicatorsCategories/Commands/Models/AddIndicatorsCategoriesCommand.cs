using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.IndicatorsCategories.Commands.Models
{
    public class AddIndicatorsCategoriesCommand : IRequest<Response<string>>
    {
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
    }
}
