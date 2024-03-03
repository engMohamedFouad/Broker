using Pinnacle.Plans.Data.Enums;

namespace Pinnacle.Plans.Data.DTOs
{
    public class UpdatePlansDTO
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public Period Period { get; set; } = Period.Mounthly;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public List<UpdateManagementDTO>? Managements { get; set; }
        public List<UpdateUserDTO>? Users { get; set; }
        public List<UpdateUserManagersDTO>? UsersManagers { get; set; }
        public List<UpdateReviewTopicsDTO>? ReviewTopics { get; set; }
        public List<UpdateReviewDTO>? Reviews { get; set; }
        public List<UpdateFirstlyDataDTO>? firstlyInformations { get; set; }
    }
    public class UpdateManagementDTO
    {
        public int Id { get; set; }
    }
    public class UpdateUserDTO
    {
        public int Id { get; set; }
    }
    public class UpdateUserManagersDTO
    {
        public int Id { get; set; }
    }

    public class UpdateReviewTopicsDTO
    {
        public int Id { get; set; }
    }
    public class UpdateReviewDTO
    {
        public int Id { get; set; }
    }
    public class UpdateFirstlyDataDTO
    {
        public int Id { get; set; }
    }
}
