using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Enum;

namespace VismaSpcs.Recruitment.ChatService.Interfaces.Services
{
    public interface IUserService
    {
        public User? AddUser(User user);
        public User? GetUserById(int id);
        public User? UpdateStatus(int id, UserStatus status, string customStatusMessage);
        public void SendContactRequest(int requestSentById, int requestSentToId);
        public void AcceptContactRequest(int contactRequestId);
        public void DeclineContactRequest(int contactRequestId);
    }
}
