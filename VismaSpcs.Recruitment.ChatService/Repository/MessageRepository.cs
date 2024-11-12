using VismaSpcs.Recruitment.ChatService.Data;
using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Interfaces.Repositories;

namespace VismaSpcs.Recruitment.ChatService.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Database _context;

        public MessageRepository(Database context)
        {
            _context = context;
        }

        public void SendMessage(Message message)
        {
            _context.Messages.Add(message);
            // _context.SaveChanges();
        }
    }
}
