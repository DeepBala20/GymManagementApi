namespace GymManagementApi.Model
{
    public class PaymentModel
    {
        public int? PaymentID { get; set; }
        public string PaymentMethod { get; set; }
        public string? MemberName { get; set; }
        public DateTime PaymentDate { get; set; }
        public int MemberID { get; set; }
    }
}
