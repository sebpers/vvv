namespace VismaSpcs.Recruitment.ChatService.Entities
{
    public class Conversation
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsGroup { get; set; } = false;

        public List<Chat> Participants { get; set; } = new();
        public List<Message> Messages { get; set; } = new();

        public void AddParticipantsToPrivateChat(int userIdOne, int userIdTwo)
        {
            if (Participants.Any(p => p.UserId == userIdOne ||  p.UserId == userIdTwo))
            {
                throw new Exception("One or both are in the chat already");
            }

            Participants.Add(new Chat { UserId = userIdOne });
            Participants.Add(new Chat { UserId = userIdTwo });
        }
        
        public void AddParticipantsToGroupChat(List<int> participantIds)
        {
            if (participantIds.Any(pid => Participants.Any(p => p.UserId == pid)))
            {
                throw new Exception("One or more participants are already in the chat");
            }

            foreach (var id in participantIds)
            {
                Participants.Add(new Chat { UserId = id });
            }
        }
    }
}
