using GymManagementApi.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GymManagementApi.Data
{
    public class PaymentsRepository
    {
        private readonly string _connectionString;

        public PaymentsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region GetAllPayments
        public IEnumerable<PaymentModel> GetAllPayments()
        {
            var payments = new List<PaymentModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Payments_SelectAll", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    payments.Add(new PaymentModel
                    {
                        PaymentID = Convert.ToInt32(reader["PaymentID"]),
                        PaymentMethod = reader["PaymentMethod"].ToString(),
                        MemberName = reader["MemberName"].ToString(),
                        MemberID = Convert.ToInt32(reader["MemberID"]),
                        PaymentDate = Convert.ToDateTime(reader["PaymentDate"]),
                    });
                }
            }
            return payments;
        }
        #endregion

        #region GetPaymentByPk
        public PaymentModel GetPaymentByPk(int paymentID) 
        {
            PaymentModel payment = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Payments_SelectByPK", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@PaymentID", paymentID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    payment = new PaymentModel
                    {
                        PaymentID = Convert.ToInt32(reader["PaymentID"]),
                        PaymentMethod = reader["PaymentMethod"].ToString(),
                        MemberName = reader["MemberName"].ToString(),
                        MemberID = Convert.ToInt32(reader["MemberID"]),
                        PaymentDate = Convert.ToDateTime(reader["PaymentDate"]),
                    };
                }
            }
            return payment;
        }
        #endregion

        #region DeletePayment
        public bool DeletePayment(int paymentID) 
        {
            using (SqlConnection conn = new SqlConnection(_connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Payments_Delete", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@PaymentID", paymentID);
                conn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                return rowAffected > 0;
            }            
        }
        #endregion

        #region AddPayment
        public bool AddPayment(PaymentModel payment)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Payments_Add", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                cmd.Parameters.AddWithValue("@MemberID", payment.MemberID);
                conn.Open();
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }
        #endregion

        #region UpdatePayment
        public bool UpdatePayment(PaymentModel payment)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Gym_Payments_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@PaymentID", payment.PaymentID);
                cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                cmd.Parameters.AddWithValue("@MemberID", payment.MemberID);
                conn.Open();
                var rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect > 0;
            }
        }
        #endregion

    }
}
