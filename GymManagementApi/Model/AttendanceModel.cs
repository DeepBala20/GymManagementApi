namespace GymManagementApi.Model
{
    public class AttendanceModel
    {
        public int? AttendanceID { get; set; }
        public int MemberID { get; set; }
        public int TrainerID { get; set; }
        public int FilledByAdminID { get; set; }
        public int FilledByTrainerID { get; set; }
        public string AttendanceStatus { get; set; }
        public DateTime AttendanceDate{ get; set; }

        public string? MemberName { get; set; }
        public string? TrainerName { get; set; }
        public string? FilledByAdminName { get; set; }
        public string? FilledByTrainerName { get; set; }
    }

    public class FillAttendanceModel
    {
        public int MemberID { get; set; }
        public int TrainerID { get; set; }
        public string AttendanceStatus { get; set; }
    }
    public class UpdateAttendanceModelForMember
    {
        public int AttendanceID { get; set; }
        public int TrainerID { get; set; }
        public string AttendanceStatus { get; set; }
    }
    public class UpdateAttendanceModelForTrainer
    {
        public int MemberID { get; set; }
        public int AttendanceID { get; set; }
        public string AttendanceStatus { get; set; }
    }
}
