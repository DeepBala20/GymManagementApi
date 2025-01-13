using GymManagementApi.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GymManagementApi.Data
{
    public class AuthRepository
    {
        public Jwtsettings JwtSettings { get; }

        private readonly string _connectionString;


        public AuthRepository(Jwtsettings jwtsettings, IConfiguration configuration)
        {
            JwtSettings = jwtsettings;
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        // Validate user credentials (Dummy method for demo purposes)
        public AuthModel ValidateUser(AuthModel auth)
        {
            if (auth.Role == "user")
            {
                Console.WriteLine("This is User login");

                AuthModel user = null;

                // Convert `IsAdmin` to a bit value (0 for false, 1 for true)
                int isAdminValue = auth.IsAdmin == true ? 1 : 0;

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PR_Login_User", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@username", auth.UserName);
                    cmd.Parameters.AddWithValue("@password", auth.Password);
                    cmd.Parameters.AddWithValue("@IsAdmin", isAdminValue);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Read user details from the result set
                    while (reader.Read())
                    {
                        user = new AuthModel()
                        {
                            UserName = reader["username"].ToString(),
                            Email = reader["MemberEmail"].ToString(),
                            IsAdmin = Convert.ToBoolean(reader["IsAdmin"]) // Convert BIT to bool
                        };
                    }
                }

                // Check if the user is an admin and assign the appropriate role
                if (user != null)
                {
                    user.Role = user.IsAdmin == true ? "admin" : "user";
                }

                return user; // Return the user details
            }

            else if (auth.Role == "trainer")
            {
                Console.WriteLine("this is trainer login");
                AuthModel trainer = null;

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PR_Login_Trainer", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@username", auth.UserName);
                    cmd.Parameters.AddWithValue("@password", auth.Password);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        trainer = new AuthModel()
                        {
                            UserName = reader["username"].ToString(),
                            Email = reader["TrainerEmail"].ToString(),
                            Role = "trainer"
                        };
                    }
                    
                }
                return trainer;
            }
            return null;
        }

        #region GenerateToken
        public string GenerateToken(AuthModel auth)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, auth.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("role", auth.Role),
                new Claim("email", auth.Email) // Add email dynamically
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: JwtSettings.Issuer,
                audience: JwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(JwtSettings.ExpiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token); // Return token as string
        }
        #endregion
    }
}


