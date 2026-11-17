using PatientManagementSystem.Models;
using System.Data.SqlClient;

namespace PatientManagementSystem.Data
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\Projects;Initial Catalog=DbTest2;Integrated Security=True;TrustServerCertificate=True;";

        public User GetByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = (int)reader["Id"],
                                Mobile = reader["Mobile"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Username = reader["Username"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        public User GetByMobile(string mobile)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Mobile = @Mobile";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Mobile", mobile);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = (int)reader["Id"],
                                Mobile = reader["Mobile"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Username = reader["Username"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        public bool Add(User user)
        {
            if (GetByUsername(user.Username) != null ||
                GetByMobile(user.Mobile) != null)
                return false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Users
                    (Mobile, FirstName, LastName, Username, PasswordHash)
                    VALUES
                    (@Mobile, @FirstName, @LastName, @Username, @PasswordHash)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Mobile", user.Mobile);
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);

                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdatePassword(string mobile, string passwordHash)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Users
                                 SET PasswordHash = @PasswordHash
                                 WHERE Mobile = @Mobile";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Mobile", mobile);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}