using GymManagementApi.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GymManagementApi.Data
{
    public class MemberShipsRepository
    {
        private readonly string _connectionString;

        public MemberShipsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region GetAllMemberShips
        public IEnumerable<MemberShipModel> GetAllMemberShips()
        {
            var memberShips = new List<MemberShipModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_MemberShip_SelectAll", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    memberShips.Add(new MemberShipModel
                    {
                        MemberShipID = Convert.ToInt32(reader["MemberShipID"]),
                        MemberShipName = reader["MemberShipName"].ToString(),
                        MemberShipDuration = Convert.ToInt32(reader["MemberShipDuration"]),
                        MemberShipPrice = Convert.ToDouble(reader["MemberShipPrice"]),
                    });
                }
            }
            return memberShips;
        }
        #endregion

        #region GetMemberShipByPk
        public MemberShipModel GetMemberShipByPk(int memberShipID)
        {
            MemberShipModel memberShip = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_MemberShip_SelectByPK", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };

                cmd.Parameters.AddWithValue("@MemberShipID", memberShipID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    memberShip = new MemberShipModel
                    {
                        MemberShipID = Convert.ToInt32(reader["MemberShipID"]),
                        MemberShipName = reader["MemberShipName"].ToString(),
                        MemberShipDuration = Convert.ToInt32(reader["MemberShipDuration"]),
                        MemberShipPrice = Convert.ToDouble(reader["MemberShipPrice"]),
                    };
                }
            }
            return memberShip;
        }
        #endregion

        #region DeleteMemberShip
        public bool DeleteMemberShip(int memberShipID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_MemberShip_Delete", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@MemberShipID", memberShipID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region AddMemberShip

        public bool AddMemberShip(MemberShipModel memberShip)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_MemberShip_Add", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@MemberShipName", memberShip.MemberShipName);
                cmd.Parameters.AddWithValue("@MemberShipDuration", memberShip.MemberShipDuration);
                cmd.Parameters.AddWithValue("@MemberShipPrice", memberShip.MemberShipPrice);
                conn.Open();
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }

        #endregion

        #region UpdateMemberShip

        public bool UpdateMemberShip(MemberShipModel memberShip)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_MemberShip_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@MemberShipID", memberShip.MemberShipID);
                cmd.Parameters.AddWithValue("@MemberShipName", memberShip.MemberShipName);
                cmd.Parameters.AddWithValue("@MemberShipDuration", memberShip.MemberShipDuration);
                cmd.Parameters.AddWithValue("@MemberShipPrice", memberShip.MemberShipPrice);
                conn.Open();
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }
        #endregion

        #region GetMemberShipsDropDown
        public IEnumerable<MemberShipDropDown> GetMemberShipsDropDown()
        {
            var memberShipsdrp = new List<MemberShipDropDown>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_MemberShip_DropDown", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    memberShipsdrp.Add(new MemberShipDropDown
                    {
                        MemberShipID = Convert.ToInt32(reader["MemberShipID"]),
                        MemberShipName = reader["MemberShipName"].ToString(),
                    });
                }
            }
            return memberShipsdrp;
        }
        #endregion
    }
}
