namespace VismaSpcs.Recruitment.ChatService.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public DateTime? JoinedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public User? Participant { get; set; }

        public int ConversationId { get; set; }
        public Conversation? Conversation { get; set; }
    }
}
