using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Validators;
using VismaSpcs.Recruitment.ChatService.Interfaces.Repositories;
using VismaSpcs.Recruitment.ChatService.Interfaces.Services;

namespace VismaSpcs.Recruitment.ChatService.Services
{
    public class ConversationService : IConversationService
    {
        private readonly IConversationRepository _conversationRepository;

        public ConversationService(IConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }

        public void CreateGroupConversation(string conversationName, List<int> participantIds)
        {
            if (participantIds.Count < 2)
            {
                throw new Exception("Not enough participants to create group chat");
            }

            Conversation conversationModel = new();

            conversationModel.AddParticipantsToGroupChat(participantIds);
            conversationModel.Name = conversationName;
            conversationModel.IsGroup = true;

            _conversationRepository.CreateGroupConversation(conversationModel);
        }

        public void CreatePrivateConversation(int userIdOne, int userIdTwo)
        {
            Conversation? conversationModelExists = _conversationRepository.GetPrivateConversationById(userIdOne, userIdTwo);

            Validate.NotNull(conversationModelExists, nameof(conversationModelExists));

            Conversation conversationModel = new();

            conversationModel.AddParticipantsToPrivateChat(userIdOne, userIdTwo);
            conversationModel.IsGroup = false;

            _conversationRepository.CreatePrivateConversation(conversationModel);
        }
    }
}
