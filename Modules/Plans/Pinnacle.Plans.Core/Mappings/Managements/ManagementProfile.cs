using AutoMapper;

namespace Pinnacle.Plans.Core.Mappings.Managements
{
    public partial class ManagementProfile : Profile
    {
        public ManagementProfile()
        {
            GetManagementPaginationMapping();
            GetManagementByIdMapping();
            AddManagementMapping();
            UpdateManagementMapping();
        }
    }
}
