using MediatR;
using Microsoft.AspNetCore.Http;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.File.Commands.Models
{
    public class UpdateFilesToPlanCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? Serial { get; set; }
        public IFormFile? File { get; set; }
        public int? YPId { get; set; }
    }
}
