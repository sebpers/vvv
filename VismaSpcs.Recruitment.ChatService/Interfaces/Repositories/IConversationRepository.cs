using VismaSpcs.Recruitment.ChatService.Entities;

namespace VismaSpcs.Recruitment.ChatService.Interfaces.Repositories
{
    public interface IConversationRepository
    {
        public void CreatePrivateConversation(Conversation conversation);
        public void CreateGroupConversation(Conversation conversation);
        public Conversation? GetPrivateConversationById(int userIdOne, int userIdTwo);
        public Conversation? GetConversationById(int id);
    }
}
