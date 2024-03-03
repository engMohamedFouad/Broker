using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ProceduresDetails.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.ProceduresDetails
{
    public partial class ProcedureDetailsProfile
    {
        public void GetProcedureDetailsPaginationQuery()
        {
            CreateMap<ProcedureDetails, GetProcedureDetailsPaginationResult>()
                .ForMember(opt => opt.ProcedureId, des => des.MapFrom(src => src.ProcedureId))
                .ForMember(opt => opt.ProcedureName, des => des.MapFrom(src => src.Localize(src.ProcedureNavigation!.NameAr, src.ProcedureNavigation.NameEn)))
                .ForMember(opt => opt.UserId, des => des.MapFrom(src => src.UserId))
                .ForMember(opt => opt.UserName, des => des.MapFrom(src => src.UserNavigation!.UserName))
                .ForMember(opt => opt.IsUpdated, des => des.MapFrom(src => src.IsUpdated))
                .ForMember(opt => opt.Notes, des => des.MapFrom(src => src.Notes))
                .ForMember(opt => opt.Files, des => des.MapFrom(src => src.ProcedureDetailFileNavigations!.Select(x => x.fileNavigation!.Content)));
        }
    }
}