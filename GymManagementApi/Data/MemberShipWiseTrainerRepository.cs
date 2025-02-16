using GymManagementApi.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GymManagementApi.Data
{
    public class MemberShipWiseTrainerRepository
    {


            private readonly string _connectionString;

            public MemberShipWiseTrainerRepository(IConfiguration configuration)
            {
                _connectionString = configuration.GetConnectionString("ConnectionString");
            }

        #region GetAllMemberShipWiseTrainer
        public IEnumerable<MemberShipWiseTrainerModel> GetAllMemberShipWiseTrainer(int? memberShipID = null)
        {
            var mwt = new List<MemberShipWiseTrainerModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_MemberShipWiseTrainer_SelectAll", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };

                // Handle NULL case properly
                if (memberShipID.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MemberShipID", memberShipID.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MemberShipID", DBNull.Value);
                }

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mwt.Add(new MemberShipWiseTrainerModel
                    {
                        MemberShipWiseTrainerID = Convert.ToInt32(reader["MemberShipWiseTrainerID"]),
                        MemberShipID = Convert.ToInt32(reader["MemberShipID"]),
                        MemberShipName = reader["MemberShipName"].ToString(),
                        TrainerID = Convert.ToInt32(reader["TrainerID"]),
                        TrainerName = reader["TrainerName"].ToString(),
                    });
                }
            }
            return mwt;
        }
        #endregion


        #region GetMemberShipWiseTrainerByPK
        public MemberShipWiseTrainerModel GetMemberShipWiseTrainerByPK(int mwtID)
            {
                MemberShipWiseTrainerModel mwt = null;

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PR_Gym_MemberShipWiseTrainer_SelectByPK", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                    };
                    cmd.Parameters.AddWithValue("@MemberShipWiseTrainerID", mwtID);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        mwt = new MemberShipWiseTrainerModel
                        {
                            MemberShipWiseTrainerID = Convert.ToInt32(reader["MemberShipWiseTrainerID"]),
                            MemberShipID = Convert.ToInt32(reader["MemberShipID"]),
                            MemberShipName = reader["MemberShipName"].ToString(),
                            TrainerID = Convert.ToInt32(reader["TrainerID"]),
                            TrainerName = reader["TrainerName"].ToString(),
                        };
                    }
                }

                return mwt;
            }
        #endregion

        #region DeleteMemberShipWiseTrainer
        public bool DeleteMemberShipWiseTrainer(int mwtID)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PR_Gym_MemberShipWiseTrainer_Delete", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                    };
                    cmd.Parameters.AddWithValue("@MemberShipWiseTrainerID", mwtID);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        #endregion

        #region AddMemberShipWiseTrainer
        public bool AddMemberShipWiseTrainer(MemberShipWiseTrainerModel mwt)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PR_Gym_MemberShipWiseTrainer_Add", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@MemberShipID", mwt.MemberShipID);
                    cmd.Parameters.AddWithValue("@TrainerID", mwt.TrainerID);
                    conn.Open();
                    int rowsAffect = cmd.ExecuteNonQuery();
                    return rowsAffect > 0;
                }
            }

        #endregion

        #region UpdateMemberShipWiseTrainer

        public bool UpdateMemberShipWiseTrainer(MemberShipWiseTrainerModel mwt)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PR_Gym_MemberShipWiseTrainer_Update", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@MemberShipWiseTrainerID", mwt.MemberShipWiseTrainerID);
                    cmd.Parameters.AddWithValue("@MemberShipID", mwt.MemberShipID);
                    cmd.Parameters.AddWithValue("@TrainerID", mwt.TrainerID);
                conn.Open();
                    int rowsAffect = cmd.ExecuteNonQuery();
                    return rowsAffect > 0;
                }
            }
            #endregion
        }
    }





