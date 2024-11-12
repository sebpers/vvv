using VismaSpcs.Recruitment.ChatService.Entities;

namespace VismaSpcs.Recruitment.ChatService.Data
{
    public class Database
    {
        public List<Message> Messages { get; set; } = new();
        public List<Chat> Chats { get; set; } = new();
        public List<Contact> Contacts { get; set; } = new();
        public List<ContactRequest> ContactRequests { get; set; } = new();
        public List<Conversation> Conversations { get; set; } = new();
        public List<User> Users { get; set; } = new();
    }
}
