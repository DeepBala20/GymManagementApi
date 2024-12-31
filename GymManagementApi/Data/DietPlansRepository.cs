using GymManagementApi.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GymManagementApi.Data
{
    public class DietPlansRepository
    {
        private readonly string _connectionString;

        public DietPlansRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }
        #region GetAllDietPlans
        public IEnumerable<DietPlanModel> GetAllDietPlans()
        {
            var dietPlans = new List<DietPlanModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_DietPlans_SelectAll", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dietPlans.Add(new DietPlanModel()
                    {
                        DietPlanID = Convert.ToInt32(reader["DietPlanID"]),
                        DietType = reader["DietType"].ToString(),
                        Monday = reader["Monday"].ToString(),
                        Tuesday = reader["Tuesday"].ToString(),
                        Wednesday = reader["Wednesday"].ToString(),
                        Thursday = reader["Thursday"].ToString(),
                        Friday = reader["Friday"].ToString(),
                        Saturday = reader["Saturday"].ToString(),
                        Sunday = reader["Sunday"].ToString(),

                    });
                }                
            }
            return dietPlans;
        }
        #endregion

        #region GetDietPlanByPk
        public DietPlanModel GetDietPlanByPk(int dietPlanID)
        {
            DietPlanModel dietPlan = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_DietPlans_SelectByPK", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@DietPlanID", dietPlanID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dietPlan = new DietPlanModel()
                    {
                        DietPlanID = Convert.ToInt32(reader["DietPlanID"]),
                        DietType = reader["DietType"].ToString(),
                        Monday = reader["Monday"].ToString(),
                        Tuesday = reader["Tuesday"].ToString(),
                        Wednesday = reader["Wednesday"].ToString(),
                        Thursday = reader["Thursday"].ToString(),
                        Friday = reader["Friday"].ToString(),
                        Saturday = reader["Saturday"].ToString(),
                        Sunday = reader["Sunday"].ToString(),

                    };
                }
            }

            return dietPlan;
        }
        #endregion

        #region DeleteDietPlan
        public bool DeleteDietPlan(int dietPlanID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_DietPlans_Delete", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@DietPlanID", dietPlanID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region AddDietPlan

        public bool AddDietPlan(DietPlanModel dietPlan)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_DietPlans_Add", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@DietType", dietPlan.DietType);
                cmd.Parameters.AddWithValue("@Sunday", dietPlan.Sunday);
                cmd.Parameters.AddWithValue("@Monday", dietPlan.Monday);
                cmd.Parameters.AddWithValue("@Tuesday", dietPlan.Tuesday);
                cmd.Parameters.AddWithValue("@Wednesday", dietPlan.Wednesday);
                cmd.Parameters.AddWithValue("@Thursday", dietPlan.Thursday);
                cmd.Parameters.AddWithValue("@Friday", dietPlan.Friday);
                cmd.Parameters.AddWithValue("@Saturday", dietPlan.Saturday);
                conn.Open();
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }

        #endregion

        #region UpdateDietPlan

        public bool UpdateDietPlan(DietPlanModel dietPlan)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_DietPlans_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@DietPlanID", dietPlan.DietPlanID);
                cmd.Parameters.AddWithValue("@DietType", dietPlan.DietType);
                cmd.Parameters.AddWithValue("@Sunday", dietPlan.Sunday);
                cmd.Parameters.AddWithValue("@Monday", dietPlan.Monday);
                cmd.Parameters.AddWithValue("@Tuesday", dietPlan.Tuesday);
                cmd.Parameters.AddWithValue("@Wednesday", dietPlan.Wednesday);
                cmd.Parameters.AddWithValue("@Thursday", dietPlan.Thursday);
                cmd.Parameters.AddWithValue("@Friday", dietPlan.Friday);
                cmd.Parameters.AddWithValue("@Saturday", dietPlan.Saturday);
                conn.Open();
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }
        #endregion

        #region DietPlanDropDown
        public IEnumerable<DietPlanDropDown> GetDropDownDietPlans()
        {
            var dietPlansdrp = new List<DietPlanDropDown>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_DietPlans_DropDown", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dietPlansdrp.Add(new DietPlanDropDown()
                    {
                        DietPlanID = Convert.ToInt32(reader["DietPlanID"]),
                        DietType = reader["DietType"].ToString(),

                    });
                }
            }
            return dietPlansdrp;
        }
        #endregion

    }
}
