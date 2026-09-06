using PatientManagementSystem.Data;
using PatientManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace WinFormsApp2.Data
{
    public class AccessPatientRepository : IPatientRepository
    {
        private readonly string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Asus\Documents\PatientManagement.accdb;Persist Security Info=False;";

        public bool Add(Patient patient)
        {
            return AddPatient(patient);
        }

        public bool AddPatient(Patient patient)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Patients
                         (NationalCode, FirstName, LastName, DateOfBirth,
                          Phone, Address, RegistrationDate)
                         VALUES (?, ?, ?, ?, ?, ?, ?)";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalCode", patient.NationalCode);
                    command.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    command.Parameters.AddWithValue("@LastName", patient.LastName);
                    command.Parameters.Add("@DateOfBirth", OleDbType.Date).Value = patient.DateOfBirth;
                    command.Parameters.AddWithValue("@Phone", patient.Phone);
                    command.Parameters.AddWithValue("@Address", patient.Address);
                    command.Parameters.Add("@RegistrationDate", OleDbType.Date).Value = patient.RegistrationDate;

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
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Patients WHERE Id = ?";

                using (OleDbCommand command = new OleDbCommand(query, connection))
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

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT Id, NationalCode, FirstName, LastName,
                                        DateOfBirth, Phone, Address, RegistrationDate
                                 FROM Patients
                                 ORDER BY Id";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Patient patient = new Patient(reader["NationalCode"].ToString());

                        patient.Id = Convert.ToInt32(reader["Id"]);
                        patient.FirstName = reader["FirstName"].ToString();
                        patient.LastName = reader["LastName"].ToString();
                        patient.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                        patient.Phone = reader["Phone"].ToString();
                        patient.Address = reader["Address"].ToString();
                        patient.RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]);

                        patients.Add(patient);
                    }
                }
            }

            return patients;
        }

        public Patient GetPatientById(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT Id, NationalCode, FirstName, LastName,
                                DateOfBirth, Phone, Address, RegistrationDate
                         FROM Patients
                         WHERE Id = ?";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Patient patient = new Patient(reader["NationalCode"].ToString());

                            patient.Id = Convert.ToInt32(reader["Id"]);
                            patient.FirstName = reader["FirstName"].ToString();
                            patient.LastName = reader["LastName"].ToString();
                            patient.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            patient.Phone = reader["Phone"].ToString();
                            patient.Address = reader["Address"].ToString();
                            patient.RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]);

                            return patient;
                        }
                    }
                }
            }

            return null;
        }

        public Patient GetPatientByNationalCode(string nationalCode)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT Id, NationalCode, FirstName, LastName,
                                DateOfBirth, Phone, Address, RegistrationDate
                         FROM Patients
                         WHERE NationalCode = ?";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalCode", nationalCode);

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Patient patient = new Patient(reader["NationalCode"].ToString());

                            patient.Id = Convert.ToInt32(reader["Id"]);
                            patient.FirstName = reader["FirstName"].ToString();
                            patient.LastName = reader["LastName"].ToString();
                            patient.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            patient.Phone = reader["Phone"].ToString();
                            patient.Address = reader["Address"].ToString();
                            patient.RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]);

                            return patient;
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

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT Id, NationalCode, FirstName, LastName,
                                DateOfBirth, Phone, Address, RegistrationDate
                         FROM Patients
                         WHERE NationalCode LIKE ?
                            OR FirstName LIKE ?
                            OR LastName LIKE ?
                            OR Phone LIKE ?
                         ORDER BY Id";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    string searchValue = "%" + keyword + "%";

                    command.Parameters.AddWithValue("@NationalCode", searchValue);
                    command.Parameters.AddWithValue("@FirstName", searchValue);
                    command.Parameters.AddWithValue("@LastName", searchValue);
                    command.Parameters.AddWithValue("@Phone", searchValue);

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Patient patient = new Patient(reader["NationalCode"].ToString());

                            patient.Id = Convert.ToInt32(reader["Id"]);
                            patient.FirstName = reader["FirstName"].ToString();
                            patient.LastName = reader["LastName"].ToString();
                            patient.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            patient.Phone = reader["Phone"].ToString();
                            patient.Address = reader["Address"].ToString();
                            patient.RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]);

                            patients.Add(patient);
                        }
                    }
                }
            }

            return patients;
        }

        public bool Update(Patient patient)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePatient(Patient patient)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = @"UPDATE Patients
                         SET NationalCode = ?,
                             FirstName = ?,
                             LastName = ?,
                             DateOfBirth = ?,
                             Phone = ?,
                             Address = ?
                         WHERE Id = ?";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalCode", patient.NationalCode);
                    command.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    command.Parameters.AddWithValue("@LastName", patient.LastName);
                    command.Parameters.Add("@DateOfBirth", OleDbType.Date).Value = patient.DateOfBirth;
                    command.Parameters.AddWithValue("@Phone", patient.Phone);
                    command.Parameters.AddWithValue("@Address", patient.Address);
                    command.Parameters.AddWithValue("@Id", patient.Id);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
    }
