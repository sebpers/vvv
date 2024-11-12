using VismaSpcs.Recruitment.ChatService.Entities;

namespace VismaSpcs.Recruitment.ChatService.Interfaces.Services
{
    public interface IMessageService
    {
        void SendMessageToPrivate(Message message);
        void SendMessageToGroup(Message message);
        List<Message>? GetMessagesByConversationId(int conversationId);
    }
}
