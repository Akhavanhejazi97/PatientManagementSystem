using PatientManagementSystem.Data;
using PatientManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PatientManagementSystem.Data
{
    public class SqlPatientRepository : IPatientRepository
    {
        private string connectionString = "Server=localhost;Database=DbTest;Trusted_Connection=True;TrustServerCertificate=True;";
        public bool Add(Patient patient)
        {
            return AddPatient(patient);
        }


        public bool AddPatient(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Patients
                         (NationalCode, FirstName, LastName, DateOfBirth,
                          Phone, Address, RegistrationDate)
                         VALUES
                         (@NationalCode, @FirstName, @LastName, @DateOfBirth,
                          @Phone, @Address, @RegistrationDate)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalCode", patient.NationalCode);
                    command.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    command.Parameters.AddWithValue("@LastName", patient.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@Phone", patient.Phone);
                    command.Parameters.AddWithValue("@Address", patient.Address);
                    command.Parameters.AddWithValue("@RegistrationDate", patient.RegistrationDate);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            return DeletePatient(id);
        }

        public bool DeletePatient(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Patients WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Patient> GetAll()
        {
            return GetAllPatients();
        }

        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT Id, NationalCode, FirstName, LastName,
                                DateOfBirth, Phone, Address, RegistrationDate
                         FROM Patients";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Patient patient = new Patient(reader["NationalCode"].ToString())
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Phone = reader["Phone"].ToString(),
                            Address = reader["Address"].ToString(),
                            RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"])
                        };

                        patients.Add(patient);
                    }
                }
            }

            return patients;
        }

        public Patient GetPatientById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT Id, NationalCode, FirstName, LastName,
                                DateOfBirth, Phone, Address, RegistrationDate
                         FROM Patients
                         WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Patient(reader["NationalCode"].ToString())
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                Phone = reader["Phone"].ToString(),
                                Address = reader["Address"].ToString(),
                                RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"])
                            };
                        }
                    }
                }
            }

            return null;
        }

        public Patient GetPatientByNationalCode(string nationalCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT Id, NationalCode, FirstName, LastName,
                                DateOfBirth, Phone, Address, RegistrationDate
                         FROM Patients
                         WHERE NationalCode = @NationalCode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalCode", nationalCode);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Patient(reader["NationalCode"].ToString())
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                Phone = reader["Phone"].ToString(),
                                Address = reader["Address"].ToString(),
                                RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"])
                            };
                        }
                    }
                }
            }

            return null;
        }

        public List<Patient> Search(string keyword)
        {
            return SearchPatients(keyword);
        }

        public List<Patient> SearchPatients(string keyword)
        {
            List<Patient> patients = new List<Patient>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT Id, NationalCode, FirstName, LastName,
                                DateOfBirth, Phone, Address, RegistrationDate
                         FROM Patients
                         WHERE NationalCode LIKE @Keyword
                            OR FirstName LIKE @Keyword
                            OR LastName LIKE @Keyword
                            OR Phone LIKE @Keyword";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patients.Add(new Patient(reader["NationalCode"].ToString())
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                Phone = reader["Phone"].ToString(),
                                Address = reader["Address"].ToString(),
                                RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"])
                            });
                        }
                    }
                }
            }

            return patients;
        }

        public bool Update(Patient patient)
        {
            return UpdatePatient(patient);
        }

        public bool UpdatePatient(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"UPDATE Patients
                         SET NationalCode = @NationalCode,
                             FirstName = @FirstName,
                             LastName = @LastName,
                             DateOfBirth = @DateOfBirth,
                             Phone = @Phone,
                             Address = @Address,
                             RegistrationDate = @RegistrationDate
                         WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalCode", patient.NationalCode);
                    command.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    command.Parameters.AddWithValue("@LastName", patient.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@Phone", patient.Phone);
                    command.Parameters.AddWithValue("@Address", patient.Address);
                    command.Parameters.AddWithValue("@RegistrationDate", patient.RegistrationDate);
                    command.Parameters.AddWithValue("@Id", patient.Id);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}