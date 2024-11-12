using VismaSpcs.Recruitment.ChatService.Entities;

namespace VismaSpcs.Recruitment.ChatService.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public User AddUser(User user);
        public User? GetUserById(int id);
        public User? GetUserByEmail(string email);
        public User? UpdateStatus(User userModel);
    }
}
