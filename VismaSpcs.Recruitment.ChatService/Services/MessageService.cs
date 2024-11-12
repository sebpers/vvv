using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Validators;
using VismaSpcs.Recruitment.ChatService.Interfaces.Repositories;
using VismaSpcs.Recruitment.ChatService.Interfaces.Services;

namespace VismaSpcs.Recruitment.ChatService.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IConversationRepository _conversationRepository;

        public MessageService(IMessageRepository messageRepository, IConversationRepository conversationRepository)
        {
            _messageRepository = messageRepository;
            _conversationRepository = conversationRepository;
        }

        public void SendMessageToPrivate(Message messageModel)
        {
            ValidateSendMessage(messageModel, false);

            _messageRepository.SendMessage(messageModel);
        }
        
        public void SendMessageToGroup(Message messageModel)
        {

            ValidateSendMessage(messageModel, true);

            _messageRepository.SendMessage(messageModel);
        }

        public List<Message>? GetMessagesByConversationId(int conversationId)
        {
            Conversation? conversationModel = _conversationRepository.GetConversationById(conversationId);

            Validate.NotNull(conversationModel, nameof(conversationModel));

            List<Message>? messages = conversationModel.Messages;

            Validate.NotNull(messages, nameof(messages));

            return messages;
        }

        private void ValidateSendMessage(Message messageModel, bool isGroup)
        {
            Validate.NotNull(messageModel, nameof(messageModel));

            Conversation? existingConversationModel = _conversationRepository.GetConversationById(messageModel.ConversationId);

            Validate.NotNull(existingConversationModel, nameof(existingConversationModel));

            if (existingConversationModel.IsGroup != isGroup)
            {
                string typeOfConversation = isGroup ? "group" : "private";
                throw new Exception($"Cannot send message to a {typeOfConversation} conversation");
            }
        }
    }
}
