using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.ConcernedParties.Commands.Models
{
    public class DeleteConcernedPartiesCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
