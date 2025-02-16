using GymManagementApi.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GymManagementApi.Data
{
    public class TrainersRepository
    {
        private readonly string _connectionString;

        public TrainersRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region GetAllTrainers
        public IEnumerable<TrainerModel> GetAllTrainers()
        {
            var trainers = new List<TrainerModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Trainers_SelectAll", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    trainers.Add(new TrainerModel
                    {
                        TrainerID = Convert.ToInt32(reader["TrainerID"]),
                        TrainerName = reader["TrainerName"].ToString(),
                        TrainerMobile = reader["TrainerMobile"].ToString(),
                        TrainerEmail = reader["TrainerEmail"].ToString(),
                        TrainerAge = Convert.ToInt32(reader["TrainerAge"]),
                        TrainerWeight = Convert.ToInt32(reader["TrainerWeight"]),
                        TrainerHeight = Convert.ToInt32(reader["TrainerHeight"]),
                        JoiningDate = Convert.ToDateTime(reader["JoiningDate"]),
                        Salary = Convert.ToDouble(reader["Salary"]),
                        GymShift = Convert.ToInt32(reader["GymShift"]),
                        username = reader["username"].ToString(),
                        password = reader["password"].ToString(),
                        Experience = Convert.ToDouble(reader["Experience"]),
                        TrainerImage = reader["TrainerImage"].ToString(),
                    });
                }
            }
            return trainers;
        }
        #endregion

        #region GetTrainerByPK
        public TrainerModel GetTrainerByPK(int trainerID)
        {
            TrainerModel trainer = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Trainers_SelectByPK", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@TrainerID", trainerID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    trainer = new TrainerModel
                    {
                        TrainerID = Convert.ToInt32(reader["TrainerID"]),
                        TrainerName = reader["TrainerName"].ToString(),
                        TrainerMobile = reader["TrainerMobile"].ToString(),
                        TrainerEmail = reader["TrainerEmail"].ToString(),
                        TrainerAge = Convert.ToInt32(reader["TrainerAge"]),
                        TrainerWeight = Convert.ToInt32(reader["TrainerWeight"]),
                        TrainerHeight = Convert.ToInt32(reader["TrainerHeight"]),
                        JoiningDate = Convert.ToDateTime(reader["JoiningDate"]),
                        Salary = Convert.ToDouble(reader["Salary"]),
                        GymShift = Convert.ToInt32(reader["GymShift"]),
                        username = reader["username"].ToString(),
                        password = reader["password"].ToString(),
                        Experience = Convert.ToDouble(reader["Experience"]),
                        TrainerImage = reader["TrainerImage"].ToString(),
                    };
                }
            }

            return trainer;
        }
        #endregion

        #region DeleteTrainer
        public bool DeleteTrainer(int trainerID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Trainers_Delete", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@TrainerID", trainerID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        #endregion

        #region AddTrainer
        public bool AddTrainer(TrainerModel trainer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Trainers_Add", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TrainerName", trainer.TrainerName);
                cmd.Parameters.AddWithValue("@TrainerMobile", trainer.TrainerMobile);
                cmd.Parameters.AddWithValue("@TrainerEmail", trainer.TrainerEmail);
                cmd.Parameters.AddWithValue("@TrainerAge", trainer.TrainerAge);
                cmd.Parameters.AddWithValue("@TrainerWeight", trainer.TrainerWeight);
                cmd.Parameters.AddWithValue("@TrainerHeight", trainer.TrainerHeight);
                cmd.Parameters.AddWithValue("@JoiningDate", trainer.JoiningDate);
                cmd.Parameters.AddWithValue("@Experience", trainer.Experience);
                cmd.Parameters.AddWithValue("@GymShift", trainer.GymShift);
                cmd.Parameters.AddWithValue("@Salary", trainer.Salary);
                cmd.Parameters.AddWithValue("@username", trainer.username);
                cmd.Parameters.AddWithValue("@password", trainer.password);
                cmd.Parameters.AddWithValue("@TrainerImage", trainer.TrainerImage);
                conn.Open();
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }

        #endregion

        #region UpdateTrainer

        public bool UpdateTrainer(TrainerModel trainer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Trainers_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TrainerID", trainer.TrainerID);
                cmd.Parameters.AddWithValue("@TrainerName", trainer.TrainerName);
                cmd.Parameters.AddWithValue("@TrainerMobile", trainer.TrainerMobile);
                cmd.Parameters.AddWithValue("@TrainerEmail", trainer.TrainerEmail);
                cmd.Parameters.AddWithValue("@TrainerAge", trainer.TrainerAge);
                cmd.Parameters.AddWithValue("@TrainerWeight", trainer.TrainerWeight);
                cmd.Parameters.AddWithValue("@TrainerHeight", trainer.TrainerHeight);
                cmd.Parameters.AddWithValue("@JoiningDate", trainer.JoiningDate);
                cmd.Parameters.AddWithValue("@Experience", trainer.Experience);
                cmd.Parameters.AddWithValue("@GymShift", trainer.GymShift);
                cmd.Parameters.AddWithValue("@Salary", trainer.Salary);
                cmd.Parameters.AddWithValue("@username", trainer.username);
                cmd.Parameters.AddWithValue("@password", trainer.password);
                cmd.Parameters.AddWithValue("@TrainerImage", trainer.TrainerImage);
                conn.Open();
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }
        #endregion

        #region GetTrainersDropDown
        public IEnumerable<TrainerDropDown> GetTrainersDropDown()
        {
            var trainersdrp = new List<TrainerDropDown>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Trainers_DropDown", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    trainersdrp.Add(new TrainerDropDown
                    {
                        TrainerID = Convert.ToInt32(reader["TrainerID"]),
                        TrainerName = reader["TrainerName"].ToString(),
                    });
                }
            }
            return trainersdrp;
        }
        #endregion

        #region GetTrainersMemberShipWiseDropDown
        public IEnumerable<TrainerDropDown> GetTrainersMemberShipWiseDropDown(int memberShipID)
        {
            var trainersdrp = new List<TrainerDropDown>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Trainers_DropDown_MemberShipWise", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@MemberShipID", memberShipID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    trainersdrp.Add(new TrainerDropDown
                    {
                        TrainerID = Convert.ToInt32(reader["TrainerID"]),
                        TrainerName = reader["TrainerName"].ToString(),
                    });
                }
            }
            return trainersdrp;
        }
        #endregion
    }
}
