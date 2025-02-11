namespace GymManagementApi.Model
{
    public class TrainerModel
    {
        public int? TrainerID { get; set; }
        public string TrainerName { get; set; }
        public string TrainerMobile { get; set; }
        public string TrainerEmail { get; set; }
        public int TrainerAge { get; set; }
        public double TrainerWeight { get; set; }
        public double TrainerHeight { get; set; }
        public DateTime JoiningDate { get; set; }
        public double Experience { get; set; }
        public double Salary { get; set; }
        public int GymShift { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string TrainerImage { get; set; }
    }

    public class TrainerDropDown
    {
        public int? TrainerID { get; set; }
        public string TrainerName { get; set; }
    }
}