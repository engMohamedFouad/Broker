using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.File.Queries.Models;
using Pinnacle.Plans.Core.Features.File.Queries.Results;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.File.Queries.Handlers
{
    public class FileQueryHandler : ResponseHandler,
        IRequestHandler<GetFilesOfPlanQuery, PaginatedResult<GetFilesOfPlanResult>>,
        IRequestHandler<GetFileByIdQuery, Response<GetFileByIdResult>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IFileService _fileService;
        #endregion
        #region Constructors
        public FileQueryHandler(IMapper mapper,
                                IStringLocalizer<SharedResources> stringLocalizer,
                                IFileService fileService) : base(stringLocalizer)
        {
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _fileService = fileService;
        }


        #endregion
        #region Handle Functions
        public async Task<PaginatedResult<GetFilesOfPlanResult>> Handle(GetFilesOfPlanQuery request, CancellationToken cancellationToken)
        {
            var query = _fileService.GetAllFiles(request.Search, request.YPId);
            var result = await _mapper.ProjectTo<GetFilesOfPlanResult>(query).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }

        public async Task<Response<GetFileByIdResult>> Handle(GetFileByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _fileService.GetById(request.Id);
            if (response == null) return NotFound<GetFileByIdResult>();
            var result = _mapper.Map<GetFileByIdResult>(response);
            return Success(result);
        }
        #endregion
    }
}
