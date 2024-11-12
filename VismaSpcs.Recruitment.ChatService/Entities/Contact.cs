namespace VismaSpcs.Recruitment.ChatService.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public int RequestSentById { get; set; }
        public int RequestSentToId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
