using VismaSpcs.Recruitment.ChatService.Entities;

namespace VismaSpcs.Recruitment.ChatService.Interfaces.Repositories
{
    public interface IMessageRepository
    {
        public void SendMessage(Message message);
    }
}
