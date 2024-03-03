using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.IndicatorsCategories.Commands.Models
{
    public class DeleteIndicatorsCategoriesCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
