using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.IndicatorsCategories.Commands.Models
{
    public class UpdateIndicatorsCategoriesCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
    }
}
