using VismaSpcs.Recruitment.ChatService.Enum;

namespace VismaSpcs.Recruitment.ChatService.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsOnline { get; set; } = false;
        public UserStatus Status { get; set; } = UserStatus.Offline;
        public string CustomStatusMessage { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<Chat> Chats { get; set; } = new();
        public List<Contact> Contacts { get; set; } = new();
        public List<ContactRequest> ContactRequests { get; set; } = new();

        public void UpdateStatus(UserStatus status, string customMessage)
        {
            this.Status = status;
            this.CustomStatusMessage = customMessage;
        }
    }
}
