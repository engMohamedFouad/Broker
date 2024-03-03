using Pinnacle.Plans.Data.Enums;

namespace Pinnacle.Plans.Data.DTOs
{
    public class AddPlansDTO
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public Period Period { get; set; } = Period.Mounthly;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Year { get; set; }
        public int? ReviewYearPeriod { get; set; }
        public Status ProcedureDanger { get; set; } = Status.High;
        public string? ProcedureDangerReason { get; set; }
        public Status DangerStatus { get; set; } = Status.High;
        public List<AddBranchDTO>? Branches { get; set; }
        public List<AddManagementDTO>? Managements { get; set; }
        public List<AddUserDTO>? Users { get; set; }
        public List<AddUserManagersDTO>? UsersManagers { get; set; }
        public List<AddReviewTopicsDTO>? ReviewTopics { get; set; }
        public List<AddReviewDTO>? Reviews { get; set; }
        public List<AddFirstlyDataDTO>? firstlyInformations { get; set; }
    }
    public class AddManagementDTO
    {
        public int Id { get; set; }
    }
    public class AddUserDTO
    {
        public int Id { get; set; }
    }
    public class AddUserManagersDTO
    {
        public int Id { get; set; }
    }

    public class AddReviewTopicsDTO
    {
        public int Id { get; set; }
    }
    public class AddReviewDTO
    {
        public int Id { get; set; }
    }
    public class AddFirstlyDataDTO
    {
        public int Id { get; set; }
    }
    public class AddBranchDTO
    {
        public int Id { get; set; }
    }
}
