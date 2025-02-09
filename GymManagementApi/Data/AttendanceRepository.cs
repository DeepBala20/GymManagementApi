using GymManagementApi.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GymManagementApi.Data
{
    public class AttendanceRepository
    {
        private readonly string _connectionString;

        public AttendanceRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region AttendanceReport
        public IEnumerable<AttendanceModel> AttendanceReport()
        {
            var attendanceReport = new List<AttendanceModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_GetAllAttendanceReport", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    attendanceReport.Add(new AttendanceModel
                    {
                        AttendanceID = reader.IsDBNull(reader.GetOrdinal("AttendanceID")) ? 0 : Convert.ToInt32(reader["AttendanceID"]),
                        MemberID = reader.IsDBNull(reader.GetOrdinal("MemberID")) ? 0 : Convert.ToInt32(reader["MemberID"]),
                        MemberName = reader.IsDBNull(reader.GetOrdinal("MemberName")) ? "" : reader["MemberName"].ToString(),
                        TrainerID = reader.IsDBNull(reader.GetOrdinal("TrainerID")) ? 0 : Convert.ToInt32(reader["TrainerID"]),
                        TrainerName = reader.IsDBNull(reader.GetOrdinal("TrainerName")) ? "" : reader["TrainerName"].ToString(),
                        FilledByAdminID = reader.IsDBNull(reader.GetOrdinal("FilledByAdminID")) ? 0 : Convert.ToInt32(reader["FilledByAdminID"]),
                        FilledByAdminName = reader.IsDBNull(reader.GetOrdinal("FilledByAdminName")) ? "" : reader["FilledByAdminName"].ToString(),
                        FilledByTrainerID = reader.IsDBNull(reader.GetOrdinal("FilledByTrainerID")) ? 0 : Convert.ToInt32(reader["FilledByTrainerID"]),
                        FilledByTrainerName = reader.IsDBNull(reader.GetOrdinal("FilledByTrainerName")) ? "" : reader["FilledByTrainerName"].ToString(),
                        AttendanceStatus = reader.IsDBNull(reader.GetOrdinal("AttendanceStatus")) ? "" : reader["AttendanceStatus"].ToString(),
                        AttendanceDate =  Convert.ToDateTime(reader["AttendanceDate"])
                    });
                }
            }
            return attendanceReport;
        }
        #endregion

        #region AttendanceReportByPK
        public AttendanceModel AttendanceReportByPK(int AttendanceID)
        {
            AttendanceModel attendanceReport =null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_GetAllAttendanceReportByPK", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@AttendanceID", AttendanceID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    attendanceReport = new AttendanceModel
                    {
                        AttendanceID = reader.IsDBNull(reader.GetOrdinal("AttendanceID")) ? 0 : Convert.ToInt32(reader["AttendanceID"]),
                        MemberID = reader.IsDBNull(reader.GetOrdinal("MemberID")) ? 0 : Convert.ToInt32(reader["MemberID"]),
                        MemberName = reader.IsDBNull(reader.GetOrdinal("MemberName")) ? "" : reader["MemberName"].ToString(),
                        TrainerID = reader.IsDBNull(reader.GetOrdinal("TrainerID")) ? 0 : Convert.ToInt32(reader["TrainerID"]),
                        TrainerName = reader.IsDBNull(reader.GetOrdinal("TrainerName")) ? "" : reader["TrainerName"].ToString(),
                        FilledByAdminID = reader.IsDBNull(reader.GetOrdinal("FilledByAdminID")) ? 0 : Convert.ToInt32(reader["FilledByAdminID"]),
                        FilledByAdminName = reader.IsDBNull(reader.GetOrdinal("FilledByAdminName")) ? "" : reader["FilledByAdminName"].ToString(),
                        FilledByTrainerID = reader.IsDBNull(reader.GetOrdinal("FilledByTrainerID")) ? 0 : Convert.ToInt32(reader["FilledByTrainerID"]),
                        FilledByTrainerName = reader.IsDBNull(reader.GetOrdinal("FilledByTrainerName")) ? "" : reader["FilledByTrainerName"].ToString(),
                        AttendanceStatus = reader.IsDBNull(reader.GetOrdinal("AttendanceStatus")) ? "" : reader["AttendanceStatus"].ToString(),
                        AttendanceDate = Convert.ToDateTime(reader["AttendanceDate"])
                    };
                }
            }
            return attendanceReport;
        }
        #endregion
        #region MembersAttendanceReport
        public IEnumerable<AttendanceModel> MembersAttendanceReport(int TrainerID)
        {
            var attendanceReport = new List<AttendanceModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_GetAllAttendanceReportOfMember", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TrainerID", TrainerID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    attendanceReport.Add(new AttendanceModel
                    {
                        AttendanceID = reader.IsDBNull(reader.GetOrdinal("AttendanceID")) ? 0 : Convert.ToInt32(reader["AttendanceID"]),
                        MemberID = reader.IsDBNull(reader.GetOrdinal("MemberID")) ? 0 : Convert.ToInt32(reader["MemberID"]),
                        MemberName = reader.IsDBNull(reader.GetOrdinal("MemberName")) ? "" : reader["MemberName"].ToString(),
                        TrainerID = reader.IsDBNull(reader.GetOrdinal("TrainerID")) ? 0 : Convert.ToInt32(reader["TrainerID"]),
                        TrainerName = reader.IsDBNull(reader.GetOrdinal("TrainerName")) ? "" : reader["TrainerName"].ToString(),
                        FilledByAdminID = reader.IsDBNull(reader.GetOrdinal("FilledByAdminID")) ? 0 : Convert.ToInt32(reader["FilledByAdminID"]),
                        FilledByAdminName = reader.IsDBNull(reader.GetOrdinal("FilledByAdminName")) ? "" : reader["FilledByAdminName"].ToString(),
                        FilledByTrainerID = reader.IsDBNull(reader.GetOrdinal("FilledByTrainerID")) ? 0 : Convert.ToInt32(reader["FilledByTrainerID"]),
                        FilledByTrainerName = reader.IsDBNull(reader.GetOrdinal("FilledByTrainerName")) ? "" : reader["FilledByTrainerName"].ToString(),
                        AttendanceStatus = reader.IsDBNull(reader.GetOrdinal("AttendanceStatus")) ? "" : reader["AttendanceStatus"].ToString(),
                        AttendanceDate = Convert.ToDateTime(reader["AttendanceDate"])
                    });
                }
            }
            return attendanceReport;
        }
        #endregion
        #region TrainersAttendanceReport
        public IEnumerable<AttendanceModel> TrainersAttendanceReport()
        {
            var attendanceReport = new List<AttendanceModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_GetAllAttendanceReportOfTrainer", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    attendanceReport.Add(new AttendanceModel
                    {
                        AttendanceID = reader.IsDBNull(reader.GetOrdinal("AttendanceID")) ? 0 : Convert.ToInt32(reader["AttendanceID"]),
                        MemberID = reader.IsDBNull(reader.GetOrdinal("MemberID")) ? 0 : Convert.ToInt32(reader["MemberID"]),
                        MemberName = reader.IsDBNull(reader.GetOrdinal("MemberName")) ? "" : reader["MemberName"].ToString(),
                        TrainerID = reader.IsDBNull(reader.GetOrdinal("TrainerID")) ? 0 : Convert.ToInt32(reader["TrainerID"]),
                        TrainerName = reader.IsDBNull(reader.GetOrdinal("TrainerName")) ? "" : reader["TrainerName"].ToString(),
                        FilledByAdminID = reader.IsDBNull(reader.GetOrdinal("FilledByAdminID")) ? 0 : Convert.ToInt32(reader["FilledByAdminID"]),
                        FilledByAdminName = reader.IsDBNull(reader.GetOrdinal("FilledByAdminName")) ? "" : reader["FilledByAdminName"].ToString(),
                        FilledByTrainerID = reader.IsDBNull(reader.GetOrdinal("FilledByTrainerID")) ? 0 : Convert.ToInt32(reader["FilledByTrainerID"]),
                        FilledByTrainerName = reader.IsDBNull(reader.GetOrdinal("FilledByTrainerName")) ? "" : reader["FilledByTrainerName"].ToString(),
                        AttendanceStatus = reader.IsDBNull(reader.GetOrdinal("AttendanceStatus")) ? "" : reader["AttendanceStatus"].ToString(),
                        AttendanceDate = Convert.ToDateTime(reader["AttendanceDate"])
                    });
                }
            }
            return attendanceReport;
        }
        #endregion
        #region FillMembersAttendence

        public bool FillMembersAttendence(FillAttendanceModel attendance)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_FillOrEditMemberAttendanceByTrainer", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@MemberID", attendance.MemberID);
                cmd.Parameters.AddWithValue("@TrainerID", attendance.TrainerID);
                cmd.Parameters.AddWithValue("@Status", attendance.AttendanceStatus);
                conn.Open();
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }

        #endregion
        #region FillTrainersAttendence
        public bool FillTrainersAttendence(FillAttendanceModel attendance)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_FillOrEditTrainerAttendanceByAdmin", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TrainerID", attendance.TrainerID);
                cmd.Parameters.AddWithValue("@AdminID", attendance.MemberID);
                cmd.Parameters.AddWithValue("@Status", attendance.AttendanceStatus);
                conn.Open();
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }

        #endregion

        
    }
}
