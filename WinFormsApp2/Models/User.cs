using System;

namespace PatientManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Mobile { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }
    }
}