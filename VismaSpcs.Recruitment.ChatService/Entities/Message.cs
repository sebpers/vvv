namespace VismaSpcs.Recruitment.ChatService.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime? SentAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public User? SentBy { get; set; }

        public int ConversationId { get; set; }
        public Conversation? Conversation { get; set; }
    }
}
