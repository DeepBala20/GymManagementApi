namespace GymManagementApi.Model
{
    public class JoiningReasonModel
    {
        public int? JoiningReasonID { get; set; }
        public string JoiningReason { get; set; }
        public int DietPlanID { get; set; }
        public string DietType { get; set; }
    }
    public class JoiningReasonDropDown
    {
        public int? JoiningReasonID { get; set; }
        public string JoiningReason { get; set; }
    }
}
