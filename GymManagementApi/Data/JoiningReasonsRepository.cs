using GymManagementApi.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GymManagementApi.Data
{
    public class JoiningReasonsRepository
    {
        private readonly string _connectionString;

        public JoiningReasonsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }
        #region GetAllJoiningReasons
        public IEnumerable<JoiningReasonModel> GetAllJoiningReasons() 
        {
            var joiningReasons = new List<JoiningReasonModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_JoiningReasons_SelectAll", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    joiningReasons.Add(new JoiningReasonModel
                    {
                        JoiningReasonID = Convert.ToInt32(reader["JoiningReasonID"]),
                        JoiningReason = reader["JoiningReason"].ToString(),
                        DietPlanID = Convert.ToInt32(reader["DietPlanID"]),
                        DietType = reader["DietType"].ToString(),
                    });             
                }
            }
            return joiningReasons;
        }
        #endregion

        #region getJoiningReasonByPk

        public JoiningReasonModel GetJoiningReasonByPk(int joiningReasonID)
        {
            JoiningReasonModel joiningReason = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_JoiningReasons_SelectByPK", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@JoiningReasonID", joiningReasonID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    joiningReason = new JoiningReasonModel
                    {
                        JoiningReasonID = Convert.ToInt32(reader["JoiningReasonID"]),
                        JoiningReason = reader["JoiningReason"].ToString(),
                        DietPlanID = Convert.ToInt32(reader["DietPlanID"]),
                        DietType = reader["DietType"].ToString(),
                    };
                }
            }
            return joiningReason;

        }
        #endregion

        #region DeleteJoiningReason
        public bool DeleteJoiningReason(int joiningReasonID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_JoiningReasons_Delete", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@JoiningReasonID", joiningReasonID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region AddJoinigReason

        public bool AddJoinigReason(JoiningReasonModel joiningReason)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_JoiningReasons_Add", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@JoiningReason", joiningReason.JoiningReason);
                cmd.Parameters.AddWithValue("@DietPlanID", joiningReason.DietPlanID);
                conn.Open();
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }

        #endregion

        #region UpdateJoinigReason

        public bool UpdateJoinigReason(JoiningReasonModel joiningReason)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_JoiningReasons_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@JoiningReasonID", joiningReason.JoiningReasonID);
                cmd.Parameters.AddWithValue("@JoiningReason", joiningReason.JoiningReason);
                cmd.Parameters.AddWithValue("@DietPlanID", joiningReason.DietPlanID);
                conn.Open();
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }
        #endregion

        #region AllJoiningReasonsDropDown
        public IEnumerable<JoiningReasonDropDown> GetJoiningReasonsDropDown()
        {
            var joiningReasonsdrp = new List<JoiningReasonDropDown>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_JoiningReasons_DropDown", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    joiningReasonsdrp.Add(new JoiningReasonDropDown
                    {
                        JoiningReasonID = Convert.ToInt32(reader["JoiningReasonID"]),
                        JoiningReason = reader["JoiningReason"].ToString(),
                    });
                }
            }
            return joiningReasonsdrp;
        }
        #endregion
    }
}
