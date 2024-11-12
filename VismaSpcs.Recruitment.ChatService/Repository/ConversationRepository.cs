using VismaSpcs.Recruitment.ChatService.Data;
using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Interfaces.Repositories;

namespace VismaSpcs.Recruitment.ChatService.Repository
{
    internal class ConversationRepository : IConversationRepository
    {
        private readonly Database _context;

        public ConversationRepository(Database context)
        {
            _context = context;
        }

        public void CreateGroupConversation(Conversation conversation)
        {
            _context.Conversations.Add(conversation);
            // _context.SaveChanges();
        }

        public void CreatePrivateConversation(Conversation conversationModel)
        {
            _context.Conversations.Add(conversationModel);
            // _context.SaveChanges();
        }

        public Conversation? GetPrivateConversationById(int userIdOne, int userIdTwo)
        {
            Conversation? privateConversationModel = _context.Conversations
                .FirstOrDefault(c => !c.IsGroup &&
                    c.Participants.Any(p => p.Id == userIdOne) &&
                    c.Participants.Any(x => x.Id == userIdTwo));

            return privateConversationModel;
        }

        public Conversation? GetConversationById(int id)
        {
            Conversation? conversationModel = _context.Conversations.Find(c => c.Id == id);

            return conversationModel;
        }
    }
}
