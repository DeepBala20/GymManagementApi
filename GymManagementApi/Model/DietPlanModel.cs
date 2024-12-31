namespace GymManagementApi.Model
{
    public class DietPlanModel
    {
        public int? DietPlanID { get; set; }
        public string DietType { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
        
    }
    public class DietPlanDropDown
    {
        public int DietPlanID { get; set; }
        public string DietType { get; set; }

    }
}
