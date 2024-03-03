using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.File.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.File.Commands.Handlers
{
    public class FileCommandHandler : ResponseHandler,
        IRequestHandler<AddFilesToPlanCommand, Response<string>>,
        IRequestHandler<UpdateFilesToPlanCommand, Response<string>>,
        IRequestHandler<DeleteFilesToPlanCommand, Response<string>>
    {
        #region Fields
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public FileCommandHandler(IFileService fileService,
                                  IMapper mapper,
                                  IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _fileService = fileService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddFilesToPlanCommand request, CancellationToken cancellationToken)
        {
            var file = _mapper.Map<Files>(request);
            var result = await _fileService.AddFileAsync(file, request.File);
            switch (result)
            {
                case "FailedToUploadFiles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToUploadFiles]);
                case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(UpdateFilesToPlanCommand request, CancellationToken cancellationToken)
        {
            var file = await _fileService.GetById(request.Id);
            if (file == null) return NotFound<string>();
            var mapper = _mapper.Map(request, file);
            var result = await _fileService.UpdateFileAsync(mapper, request.File);
            switch (result)
            {
                case "FailedToUploadFiles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToUploadFiles]);
                case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UpdateFailed]);
                case "FaliedToDeletePhysialFiles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FaliedToDeletePhysialFiles]);
            }
            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteFilesToPlanCommand request, CancellationToken cancellationToken)
        {
            var file = await _fileService.GetById(request.Id);
            if (file == null) return NotFound<string>();
            var result = await _fileService.DeleteFileAsync(file);
            switch (result)
            {
                case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);
                case "FaliedToDeletePhysialFiles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FaliedToDeletePhysialFiles]);
            }
            return Success("");
        }
        #endregion
    }
}
