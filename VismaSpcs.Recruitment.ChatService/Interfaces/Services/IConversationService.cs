namespace VismaSpcs.Recruitment.ChatService.Interfaces.Services
{
    public interface IConversationService
    {
        void CreatePrivateConversation(int userIdOne, int userIdTwo);
        void CreateGroupConversation(string conversationName, List<int> participantIds);
    }
}
