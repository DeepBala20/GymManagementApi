namespace GymManagementApi.Model
{
    public class MemberShipModel
    {
        public int? MemberShipID { get; set; }
        public string MemberShipName { get; set; }
        public int MemberShipDuration { get; set; }
        public double MemberShipPrice { get; set; }
    }
    public class MemberShipDropDown
    {
        public int? MemberShipID { get; set; }
        public string MemberShipName { get; set; }

        public string MemberShipDuration { get; set; }
    }
}