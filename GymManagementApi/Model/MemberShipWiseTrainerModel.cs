namespace GymManagementApi.Model
{
    public class MemberShipWiseTrainerModel
    {
        public int? MemberShipWiseTrainerID { get; set; }
        public int MemberShipID { get; set; }
        public string? MemberShipName { get; set; }
        public int TrainerID { get; set; }        
        public string? TrainerName { get; set; }

    }
}
