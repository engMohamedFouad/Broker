using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ReviewPoint.Queries.Results;
using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Core.Mappings.ReviewPoint
{
    public partial class ReviewPointsProfile
    {
        public void GetReviewPointByIdMapping()
        {
            CreateMap<ReviewPoints, GetReviewPointByIdResult>()
                .ForMember(opt => opt.UserName, des => des.MapFrom(src => src.UserNavigation.UserName))
                .ForMember(opt => opt.IndicatorCode, des => des.MapFrom(src => src.IndicatorNavigation.Code))
                 .ForMember(opt => opt.Comments, des => des.MapFrom(src => src.PointsCommentsNavigations))
                 .ForMember(opt => opt.Files, des => des.MapFrom(src => src.FilesNavigations))
                 .ForMember(opt => opt.AssignedUsers, des => des.MapFrom(src => src.AssignedUserPointNavigation));

            CreateMap<PointsComments, PointsCommentDTO>()
                .ForMember(opt => opt.Id, des => des.MapFrom(src => src.Id))
                .ForMember(opt => opt.Content, des => des.MapFrom(src => src.Content))
                .ForMember(opt => opt.UserId, des => des.MapFrom(src => src.UserId))
                .ForMember(opt => opt.UserName, des => des.MapFrom(src => src.UserNavigation))
                .ForMember(opt => opt.Created, des => des.MapFrom(src => src.CreatedAt));

            CreateMap<PointsFiles, PointFilesDTO>()
                    .ForMember(opt => opt.Id, des => des.MapFrom(src => src.Id))
                    .ForMember(opt => opt.Content, des => des.MapFrom(src => src.Content));

            CreateMap<UserPoint, AssignedUsers>()
                .ForMember(opt => opt.Id, des => des.MapFrom(src => src.UId))
                .ForMember(opt => opt.UserName, des => des.MapFrom(src => src.UserNavigation.UserName));




        }
    }
}