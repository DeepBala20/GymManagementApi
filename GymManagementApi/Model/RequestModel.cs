namespace GymManagementApi.Model
{
    public class RequestModel
    {
        public int? RequestID {  get; set; }
        public DateTime? RequestDate {  get; set; }
        public string? RequestDescription { get; set; }

        public int? MemberID { get; set; }

        public string? MemberName { get; set; }
        public int? TrainerID { get; set; }
        public string? TrainerName { get;set; }
        public string? RequestStatus { get;set; }

    }
}
