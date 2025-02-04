namespace GymManagementApi.Model
{
    public class MemberModel
    {
        public int? MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberMobile { get; set; }
        public string MemberEmail { get; set; }
        public int MemberAge { get; set; }
        public double MemberWeight { get; set; }
        public double MemberHeight { get; set; }
        public double MemberBMI { get; set; }
        public DateTime JoiningDate { get; set; }
        public int JoiningReasonID { get; set; }
        public string GymShift { get; set; }
        public int MemberShipID { get; set; }
        public int TrainerID { get; set; }
        public int IsAdmin { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string? MemberShipName { get; set; }
        public string? TrainerName { get; set; }
        public DateTime MemberShipEndDate { get; set; }
    }

    public class MemberDropDoown
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberShipPrice { get; set; }
    }

 }
