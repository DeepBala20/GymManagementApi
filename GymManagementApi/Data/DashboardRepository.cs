using GymManagementApi.Model;
using Microsoft.Data.SqlClient;
using System.Data;
namespace GymManagementApi.Data
{
    public class DashboardRepository
    {
        private readonly string _connectionString;

        public DashboardRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region GetTotalMembers
        public DashboardModel GetTotalMembers()
        {
            DashboardModel totalMembers = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Count_All_Member", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    totalMembers = new DashboardModel()
                    {
                        Total = reader["total"].ToString(),
                    };
                }
            }
            return totalMembers;
        }
        #endregion

        #region GetTotalTrainers
        public DashboardModel GetTotalTrainer()
        {
            DashboardModel totalMembers = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Count_All_Trainer", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    totalMembers = new DashboardModel()
                    {
                        Total = reader["total"].ToString(),
                    };
                }
            }
            return totalMembers;
        }
        #endregion

        #region GetTotalEquipments
        public DashboardModel GetTotalEquipments()
        {
            DashboardModel totalMembers = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Count_All_Equipment", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    totalMembers = new DashboardModel()
                    {
                        Total = reader["total"].ToString(),
                    };
                }
            }
            return totalMembers;
        }
        #endregion
        #region GetTotalMemberShipPlans
        public DashboardModel GetTotalMemberShipPlans()
        {
            DashboardModel totalMembers = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Count_All_MemberShipPlans", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    totalMembers = new DashboardModel()
                    {
                        Total = reader["total"].ToString(),
                    };
                }
            }
            return totalMembers;
        }
        #endregion
        #region GetTotalMemberTrainerWise
        public DashboardModel GetTotalMemberTrainerWise(int id)
        {
            DashboardModel totalMembers = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Count_All_Membes_TrainerWise", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TrainerID", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    totalMembers = new DashboardModel()
                    {
                        Total = reader["total"].ToString(),
                    };
                }
            }
            return totalMembers;
        }
        #endregion
    }
}
