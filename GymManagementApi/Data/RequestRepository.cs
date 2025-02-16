using Azure.Core;
using GymManagementApi.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GymManagementApi.Data
{
    public class RequestRepository
    {

       
            private readonly string _connectionString;

            public RequestRepository(IConfiguration configuration)
            {
                _connectionString = configuration.GetConnectionString("ConnectionString");
            }

            #region GetAllRequest
            public IEnumerable<RequestModel> GetAllRequest()
            {
                var requests = new List<RequestModel>();

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PR_Gym_Request_SelectAll", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                    };
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        requests.Add(new RequestModel
                        {
                            RequestID = reader["RequestID"] != DBNull.Value ? Convert.ToInt32(reader["RequestID"]) : 0,
                            RequestDate = reader["RequestDate"] != DBNull.Value ? Convert.ToDateTime(reader["RequestDate"]) : DateTime.MinValue,
                            RequestDescription = reader["RequestDescription"] != DBNull.Value ? reader["RequestDescription"].ToString() : string.Empty,
                            MemberID = reader["MemberID"] != DBNull.Value ? Convert.ToInt32(reader["MemberID"]) : 0,
                            MemberName = reader["MemberName"] != DBNull.Value ? reader["MemberName"].ToString() : string.Empty,
                            TrainerID = reader["TrainerID"] != DBNull.Value ? Convert.ToInt32(reader["TrainerID"]) : 0,
                            TrainerName = reader["TrainerName"] != DBNull.Value ? reader["TrainerName"].ToString() : string.Empty,
                            RequestStatus = reader["RequestStatus"] != DBNull.Value ? reader["RequestStatus"].ToString() : string.Empty,
                        });
                    }
                }
                return requests;
            }
        #endregion

        #region GetAllRequestByMember
        public IEnumerable<RequestModel> GetAllRequestByMember(int memberID)
        {
            var requests = new List<RequestModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Request_SelectByMember", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@MemberID", memberID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    requests.Add(new RequestModel
                    {
                        RequestID = reader["RequestID"] != DBNull.Value ? Convert.ToInt32(reader["RequestID"]) : 0,
                        RequestDate = reader["RequestDate"] != DBNull.Value ? Convert.ToDateTime(reader["RequestDate"]) : DateTime.MinValue,
                        RequestDescription = reader["RequestDescription"] != DBNull.Value ? reader["RequestDescription"].ToString() : string.Empty,
                        MemberID = reader["MemberID"] != DBNull.Value ? Convert.ToInt32(reader["MemberID"]) : 0,
                        MemberName = reader["MemberName"] != DBNull.Value ? reader["MemberName"].ToString() : string.Empty,
                        TrainerID = reader["TrainerID"] != DBNull.Value ? Convert.ToInt32(reader["TrainerID"]) : 0,
                        TrainerName = reader["TrainerName"] != DBNull.Value ? reader["TrainerName"].ToString() : string.Empty,
                        RequestStatus = reader["RequestStatus"] != DBNull.Value ? reader["RequestStatus"].ToString() : string.Empty,
                    });
                }
            }
            return requests;
        }
        #endregion

        #region GetAllRequestByTrainer
        public IEnumerable<RequestModel> GetAllRequestByTrainer(int trainerID)
        {
            var requests = new List<RequestModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Request_SelectByTrainer", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@TrainerID", trainerID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    requests.Add(new RequestModel
                    {
                        RequestID = reader["RequestID"] != DBNull.Value ? Convert.ToInt32(reader["RequestID"]) : 0,
                        RequestDate = reader["RequestDate"] != DBNull.Value ? Convert.ToDateTime(reader["RequestDate"]) : DateTime.MinValue,
                        RequestDescription = reader["RequestDescription"] != DBNull.Value ? reader["RequestDescription"].ToString() : string.Empty,
                        MemberID = reader["MemberID"] != DBNull.Value ? Convert.ToInt32(reader["MemberID"]) : 0,
                        MemberName = reader["MemberName"] != DBNull.Value ? reader["MemberName"].ToString() : string.Empty,
                        TrainerID = reader["TrainerID"] != DBNull.Value ? Convert.ToInt32(reader["TrainerID"]) : 0,
                        TrainerName = reader["TrainerName"] != DBNull.Value ? reader["TrainerName"].ToString() : string.Empty,
                        RequestStatus = reader["RequestStatus"] != DBNull.Value ? reader["RequestStatus"].ToString() : string.Empty,
                    });
                }
            }
            return requests;
        }
        #endregion

        #region GetRequestByPK
        public RequestModel GetRequestByPK(int requestID)
            {
                RequestModel request = null;

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PR_Gym_Request_SelectByPK", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                    };
                    cmd.Parameters.AddWithValue("@RequestID", requestID);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        request = new RequestModel
                        {
                            RequestID = reader["RequestID"] != DBNull.Value ? Convert.ToInt32(reader["RequestID"]) : 0,
                            RequestDate = reader["RequestDate"] != DBNull.Value ? Convert.ToDateTime(reader["RequestDate"]) : DateTime.MinValue,
                            RequestDescription = reader["RequestDescription"] != DBNull.Value ? reader["RequestDescription"].ToString() : string.Empty,
                            MemberID = reader["MemberID"] != DBNull.Value ? Convert.ToInt32(reader["MemberID"]) : 0,
                            MemberName = reader["MemberName"] != DBNull.Value ? reader["MemberName"].ToString() : string.Empty,
                            TrainerID = reader["TrainerID"] != DBNull.Value ? Convert.ToInt32(reader["TrainerID"]) : 0,
                            TrainerName = reader["TrainerName"] != DBNull.Value ? reader["TrainerName"].ToString() : string.Empty,
                            RequestStatus = reader["RequestStatus"] != DBNull.Value ? reader["RequestStatus"].ToString() : string.Empty,
                        };
                    }
                }

                return request;
            }
            #endregion

            #region DeleteRequest
            public bool DeleteRequest(int requestID)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PR_Gym_Request_Delete", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                    };
                    cmd.Parameters.AddWithValue("@RequestID", requestID);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            #endregion

            #region AddRequest
            public bool AddRequest(RequestModel request)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PR_Gym_Request_Add", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                //cmd.Parameters.AddWithValue("@RequestDescription", request.RequestDescription);
                //cmd.Parameters.AddWithValue("@MemberID", request.MemberID);
                //cmd.Parameters.AddWithValue("@TrainerID", request.TrainerID);
                cmd.Parameters.AddWithValue("@RequestDescription", request.RequestDescription ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MemberID", request.MemberID.HasValue ? request.MemberID.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TrainerID", request.TrainerID.HasValue ? request.TrainerID.Value : (object)DBNull.Value);

                conn.Open();
                    int rowsAffect = cmd.ExecuteNonQuery();
                    return rowsAffect > 0;
                }
            }

            #endregion

            #region UpdateRequest

            public bool UpdateRequest(RequestModel request)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PR_Gym_Request_Update", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@RequestID", request.RequestID);
                    cmd.Parameters.AddWithValue("@RequestDescription", request.RequestDescription ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MemberID", request.MemberID.HasValue ? request.MemberID.Value : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TrainerID", request.TrainerID.HasValue ? request.TrainerID.Value : (object)DBNull.Value);
                conn.Open();
                    int rowsAffect = cmd.ExecuteNonQuery();
                    return rowsAffect > 0;
                }
            }
        #endregion

        #region UpdateRequestStatus

        public bool UpdateRequestStatus(RequestModel request)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Request_Status_Change", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@RequestID", request.RequestID);
                cmd.Parameters.AddWithValue("@RequestStatus", request.RequestStatus);
                conn.Open();
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }
        #endregion
    }
}

