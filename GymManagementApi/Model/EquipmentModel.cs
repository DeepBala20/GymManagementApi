namespace GymManagementApi.Model
{
    public class EquipmentModel
    {
        public int? EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public DateTime EquipmentPurchaseDate { get; set; }
        public double EquipmentPrice { get; set; }
        public int EquipmentWarranty { get; set; }
        public string EquipmentImage { get; set; }
    }
}
