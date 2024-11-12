using VismaSpcs.Recruitment.ChatService.Enum;

namespace VismaSpcs.Recruitment.ChatService.Entities
{
    public class ContactRequest
    {
        public int Id { get; set; }
        public int RequestSentById { get; set; }
        public int RequestSentToId { get; set; }
        public ContactRequestStatus Status { get; set; } = ContactRequestStatus.Pending;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? RequestRespondedAt { get; set; }
    }
}
