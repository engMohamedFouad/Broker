using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.Plans.Commands.Models
{
    public class UpdatePlansCommand : AddPlansCommand, IRequest<Response<string>>
    {

    }
}
