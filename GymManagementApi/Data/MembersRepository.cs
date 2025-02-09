using GymManagementApi.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GymManagementApi.Data
{
    public class MembersRepository
    {
        private readonly string _connectionString;

        public MembersRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }
        #region GetAllMembers
        public IEnumerable<MemberModel> GetAllMembers() 
        { 
            var members = new List<MemberModel>();
            //Console.WriteLine("member retrived");

            using (SqlConnection conn = new SqlConnection(_connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Members_SelectAll",conn) 
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    members.Add(new MemberModel
                    {
                        MemberID = Convert.ToInt32(reader["MemberID"]),
                        MemberName = reader["MemberName"].ToString(),
                        MemberMobile = reader["MemberMobile"].ToString(),
                        MemberEmail = reader["MemberEmail"].ToString(),
                        MemberAge = Convert.ToInt32(reader["MemberAge"]),
                        MemberWeight = Convert.ToInt32(reader["MemberWeight"]),
                        MemberHeight = Convert.ToInt32(reader["MemberHeight"]),
                        MemberBMI = Convert.ToInt32(reader["MemberBMI"]),
                        JoiningDate = Convert.ToDateTime(reader["JoiningDate"]),
                        JoiningReasonID = Convert.ToInt32(reader["JoiningReasonID"]),
                        GymShift = reader["GymShift"].ToString(),
                        MemberShipID = Convert.ToInt32(reader["MemberShipID"]),
                        MemberShipEndDate = Convert.ToDateTime(reader["MemberShipEndDate"]),
                        TrainerID = Convert.ToInt32(reader["TrainerID"]),
                        IsAdmin = Convert.ToInt32(reader["IsAdmin"]),
                        username = reader["username"].ToString(),
                        password = reader["password"].ToString(),
                        MemberShipName = reader["MemberShipName"].ToString(),
                        TrainerName = reader["TrainerName"].ToString(),
                        DietPlanID = reader["DietPlanID"].ToString(),
                        PaymentStatus = reader["Payment_Status"].ToString()

                    });
                }
            }
            return members;
        }
        #endregion

        #region GetAllMembersByTrainer
        public IEnumerable<MemberModel> GetAllMembersByTrainer(int trainerID)
        {
            var members = new List<MemberModel>();
            //Console.WriteLine("member retrived");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Members_TrainerWise_SelectAll", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@TrainerID", trainerID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    members.Add(new MemberModel
                    {
                        MemberID = Convert.ToInt32(reader["MemberID"]),
                        MemberName = reader["MemberName"].ToString(),
                        MemberMobile = reader["MemberMobile"].ToString(),
                        MemberEmail = reader["MemberEmail"].ToString(),
                        MemberAge = Convert.ToInt32(reader["MemberAge"]),
                        MemberWeight = Convert.ToInt32(reader["MemberWeight"]),
                        MemberHeight = Convert.ToInt32(reader["MemberHeight"]),
                        MemberBMI = Convert.ToInt32(reader["MemberBMI"]),
                        JoiningDate = Convert.ToDateTime(reader["JoiningDate"]),
                        JoiningReasonID = Convert.ToInt32(reader["JoiningReasonID"]),
                        GymShift = reader["GymShift"].ToString(),
                        MemberShipID = Convert.ToInt32(reader["MemberShipID"]),
                        MemberShipEndDate = Convert.ToDateTime(reader["MemberShipEndDate"]),
                        TrainerID = Convert.ToInt32(reader["TrainerID"]),
                        IsAdmin = Convert.ToInt32(reader["IsAdmin"]),
                        username = reader["username"].ToString(),
                        password = reader["password"].ToString(),
                        MemberShipName = reader["MemberShipName"].ToString(),
                        TrainerName = reader["TrainerName"].ToString(),
                        DietPlanID = reader["DietPlanID"].ToString(),
                        PaymentStatus = reader["Payment_Status"].ToString()
                    });
                }
            }
            return members;
        }
        #endregion
        #region GetAllMembersByPaymentStatus
        public IEnumerable<MemberModel> GetAllMembersByPaymentStatus(string status)
        {
            var members = new List<MemberModel>();
            //Console.WriteLine("member retrived");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Members_SelectByPaymentStatus", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@status", status);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    members.Add(new MemberModel
                    {
                        MemberID = Convert.ToInt32(reader["MemberID"]),
                        MemberName = reader["MemberName"].ToString(),
                        MemberMobile = reader["MemberMobile"].ToString(),
                        MemberEmail = reader["MemberEmail"].ToString(),
                        MemberAge = Convert.ToInt32(reader["MemberAge"]),
                        MemberWeight = Convert.ToInt32(reader["MemberWeight"]),
                        MemberHeight = Convert.ToInt32(reader["MemberHeight"]),
                        MemberBMI = Convert.ToInt32(reader["MemberBMI"]),
                        JoiningDate = Convert.ToDateTime(reader["JoiningDate"]),
                        JoiningReasonID = Convert.ToInt32(reader["JoiningReasonID"]),
                        GymShift = reader["GymShift"].ToString(),
                        MemberShipID = Convert.ToInt32(reader["MemberShipID"]),
                        MemberShipEndDate = Convert.ToDateTime(reader["MemberShipEndDate"]),
                        TrainerID = Convert.ToInt32(reader["TrainerID"]),
                        IsAdmin = Convert.ToInt32(reader["IsAdmin"]),
                        username = reader["username"].ToString(),
                        password = reader["password"].ToString(),
                        MemberShipName = reader["MemberShipName"].ToString(),
                        TrainerName = reader["TrainerName"].ToString(),
                        DietPlanID = reader["DietPlanID"].ToString(),
                        PaymentStatus = reader["Payment_Status"].ToString()
                    });
                }
            }
            return members;
        }
        #endregion

        #region GetMeberByPk

        public MemberModel GetMeberByPk(int memberID)
        {
            MemberModel member = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Members_SelectByPK", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@MemberID", memberID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    member = new MemberModel
                    {
                        MemberID = Convert.ToInt32(reader["MemberID"]),
                        MemberName = reader["MemberName"].ToString(),
                        MemberMobile = reader["MemberMobile"].ToString(),
                        MemberEmail = reader["MemberEmail"].ToString(),
                        MemberAge = Convert.ToInt32(reader["MemberAge"]),
                        MemberWeight = Convert.ToInt32(reader["MemberWeight"]),
                        MemberHeight = Convert.ToInt32(reader["MemberHeight"]),
                        MemberBMI = Convert.ToInt32(reader["MemberBMI"]),
                        JoiningDate = Convert.ToDateTime(reader["JoiningDate"]),
                        JoiningReasonID = Convert.ToInt32(reader["JoiningReasonID"]),
                        GymShift = reader["GymShift"].ToString(),
                        MemberShipID = Convert.ToInt32(reader["MemberShipID"]),
                        MemberShipEndDate = Convert.ToDateTime(reader["MemberShipEndDate"]),
                        TrainerID = Convert.ToInt32(reader["TrainerID"]),
                        IsAdmin = Convert.ToInt32(reader["IsAdmin"]),
                        username = reader["username"].ToString(),
                        password = reader["password"].ToString(),
                        MemberShipName = reader["MemberShipName"].ToString(),
                        TrainerName = reader["TrainerName"].ToString(),
                        DietPlanID = reader["DietPlanID"].ToString(),
                        PaymentStatus = reader["Payment_Status"].ToString()
                    };
                }
            }
            return member;
        }
        #endregion

        #region DeleteMember
        public bool DeleteMember(int memberID)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Members_Delete", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@MemberID",memberID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region AddMember

        public bool AddMember(MemberModel member)
        {
            Console.WriteLine("Adding a member..",member);
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Members_Add", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@MemberName", member.MemberName);
                cmd.Parameters.AddWithValue("@MemberMobile", member.MemberMobile);
                cmd.Parameters.AddWithValue("@MemberEmail", member.MemberEmail);
                cmd.Parameters.AddWithValue("@MemberAge", member.MemberAge);
                cmd.Parameters.AddWithValue("@MemberWeight", member.MemberWeight);
                cmd.Parameters.AddWithValue("@MemberHeight", member.MemberHeight);
                cmd.Parameters.AddWithValue("@JoiningDate", member.JoiningDate);
                cmd.Parameters.AddWithValue("@MemberBMI", member.MemberBMI);
                cmd.Parameters.AddWithValue("@JoiningReasonID", member.JoiningReasonID);
                cmd.Parameters.AddWithValue("@GymShift", member.GymShift);
                cmd.Parameters.AddWithValue("@MemberShipID", member.MemberShipID);
                cmd.Parameters.AddWithValue("@MemberShipEndDate", member.MemberShipEndDate);
                cmd.Parameters.AddWithValue("@TrainerID", member.TrainerID);
                cmd.Parameters.AddWithValue("@IsAdmin", member.IsAdmin);
                cmd.Parameters.AddWithValue("@username", member.username);
                cmd.Parameters.AddWithValue("@password", member.password);
                conn.Open();
                var rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }

        #endregion

        #region UpdateMember

        public bool UpdateMember(MemberModel member)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Members_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@MemberID", member.MemberID);
                cmd.Parameters.AddWithValue("@MemberName", member.MemberName);
                cmd.Parameters.AddWithValue("@MemberMobile", member.MemberMobile);
                cmd.Parameters.AddWithValue("@MemberEmail", member.MemberEmail);
                cmd.Parameters.AddWithValue("@MemberAge", member.MemberAge);
                cmd.Parameters.AddWithValue("@MemberWeight", member.MemberWeight);
                cmd.Parameters.AddWithValue("@MemberHeight", member.MemberHeight);
                cmd.Parameters.AddWithValue("@JoiningDate", member.JoiningDate);
                cmd.Parameters.AddWithValue("@MemberBMI", member.MemberBMI);
                cmd.Parameters.AddWithValue("@JoiningReasonID", member.JoiningReasonID);
                cmd.Parameters.AddWithValue("@GymShift", member.GymShift);
                cmd.Parameters.AddWithValue("@MemberShipID", member.MemberShipID);
                cmd.Parameters.AddWithValue("@MemberShipEndDate", member.MemberShipEndDate);
                cmd.Parameters.AddWithValue("@TrainerID", member.TrainerID);
                cmd.Parameters.AddWithValue("@IsAdmin", member.IsAdmin);
                cmd.Parameters.AddWithValue("@username", member.username);
                cmd.Parameters.AddWithValue("@password", member.password);
                conn.Open();
                var rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }
        #endregion

        #region GetMembersDropDown
        public IEnumerable<MemberDropDoown> GetMembersDropDown()
        {
            var membersdrp = new List<MemberDropDoown>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Members_DropDown", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    membersdrp.Add(new MemberDropDoown
                    {
                        MemberID = Convert.ToInt32(reader["MemberID"]),
                        MemberName = reader["MemberName"].ToString(),
                        MemberShipPrice = reader["MemberShipPrice"].ToString()
                    });
                }
            }
            return membersdrp;
        }
        #endregion
    }
}
