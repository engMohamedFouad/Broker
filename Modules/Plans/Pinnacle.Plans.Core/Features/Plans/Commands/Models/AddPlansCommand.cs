using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Core.Features.Plans.Commands.Models
{
    public class AddPlansCommand : AddPlansDTO, IRequest<Response<string>>
    {

    }
}
