using PatientManagementSystem.Models;

namespace PatientManagementSystem.Data
{
    public interface IUserRepository
    {
        User GetByUsername(string username);

        User GetByMobile(string mobile);

        bool Add(User user);

        bool UpdatePassword(string mobile, string passwordHash);
    }
}