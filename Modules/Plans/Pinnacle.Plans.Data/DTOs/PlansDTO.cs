namespace Pinnacle.Plans.Data.DTOs
{
    public class PlansDTO
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public string? PartyName { get; set; }
        public int Period { get; set; } = 0;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Year { get; set; }
        public int? ReviewYearPeriod { get; set; }
        public int ProcedureDanger { get; set; }
        public string? ProcedureDangerReason { get; set; }
        public int DangerStatus { get; set; }
        public List<ManagementDTO>? Managements { get; set; }
        public List<UserDTO>? Users { get; set; }
        public List<UserManagersDTO>? UsersManagers { get; set; }
        public List<ReviewTopicsDTO>? ReviewTopics { get; set; }
        public List<ReviewDTO>? Reviews { get; set; }
        public List<FirstlyDataDTO>? firstlyInformations { get; set; }
        public List<BranchesDTO>? Branches { get; set; }
    }
    public class ManagementDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class UserManagersDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class ReviewTopicsDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class FirstlyDataDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class BranchesDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
