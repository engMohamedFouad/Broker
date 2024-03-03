using AutoMapper;

namespace Pinnacle.Plans.Core.Mappings.PointComments
{
    public partial class PointsCommentsProfile : Profile
    {
        public PointsCommentsProfile()
        {
            GetPointsCommentsPaginationMapping();
            GetPointsCommentsByIdMapping();
            AddPointsCommentsMapping();
            UpdatePointsCommentsMapping();
        }
    }
}
