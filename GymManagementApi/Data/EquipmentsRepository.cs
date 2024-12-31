using GymManagementApi.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GymManagementApi.Data
{
    public class EquipmentsRepository
    {
        private readonly string _connectionString;

        public EquipmentsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }
        #region GetAllEquipments
        public IEnumerable<EquipmentModel> GetAllEquipments()
        {
            var equipments = new List<EquipmentModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Equipments_SelectAll", conn) 
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    equipments.Add(new EquipmentModel 
                    {
                        EquipmentID = Convert.ToInt32(reader["EquipmentID"]),
                        EquipmentName = reader["EquipmentName"].ToString(),
                        EquipmentPurchaseDate = Convert.ToDateTime(reader["EquipmentPurchaseDate"]),
                        EquipmentPrice = Convert.ToDouble(reader["EquipmentPrice"]),
                        EquipmentWarranty = Convert.ToInt32(reader["EquipmentWarranty"]),
                        EquipmentImage = reader["EquipmentImage"].ToString(), 
                    });
                }
            }

            return equipments;
        }
        #endregion

        #region GetEquipmentByPK
        public EquipmentModel GetEquipmentByPk(int equipmentID) 
        {
            EquipmentModel equipment = null;

            using (SqlConnection conn = new SqlConnection(_connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Equipments_SelectByPK",conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@EquipmentID", equipmentID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    equipment = new EquipmentModel
                    {
                        EquipmentID = Convert.ToInt32(reader["EquipmentID"]),
                        EquipmentName = reader["EquipmentName"].ToString(),
                        EquipmentPurchaseDate = Convert.ToDateTime(reader["EquipmentPurchaseDate"]),
                        EquipmentPrice = Convert.ToDouble(reader["EquipmentPrice"]),
                        EquipmentWarranty = Convert.ToInt32(reader["EquipmentWarranty"]),
                        EquipmentImage = reader["EquipmentImage"].ToString(),
                    };
                }
            }
            return equipment;
        }
        #endregion

        #region DeleteEquipment
        public bool DeleteEquipment(int equipmentID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Equipments_Delete", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@EquipmentID", equipmentID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region AddEquipment

        public bool AddEquipment(EquipmentModel equipment)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Equipments_Add", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EquipmentName", equipment.EquipmentName);
                cmd.Parameters.AddWithValue("@EquipmentPurchaseDate", equipment.EquipmentPurchaseDate);
                cmd.Parameters.AddWithValue("@EquipmentPrice", equipment.EquipmentPrice);
                cmd.Parameters.AddWithValue("@EquipmentWarranty", equipment.EquipmentWarranty);
                cmd.Parameters.AddWithValue("@EquipmentImage", equipment.EquipmentImage);
                conn.Open();
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }

        #endregion

        #region UpdateEquipment

        public bool UpdateEquipment(EquipmentModel equipment)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Equipments_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EquipmentID", equipment.EquipmentID);
                cmd.Parameters.AddWithValue("@EquipmentName", equipment.EquipmentName);
                cmd.Parameters.AddWithValue("@EquipmentPurchaseDate", equipment.EquipmentPurchaseDate);
                cmd.Parameters.AddWithValue("@EquipmentPrice", equipment.EquipmentPrice);
                cmd.Parameters.AddWithValue("@EquipmentWarranty", equipment.EquipmentWarranty);
                cmd.Parameters.AddWithValue("@EquipmentImage", equipment.EquipmentImage);
                conn.Open();
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }
        #endregion
    }
}
