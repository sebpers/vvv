using VismaSpcs.Recruitment.ChatService.Entities;

namespace VismaSpcs.Recruitment.ChatService.Interfaces.Services
{
    public interface IContactRequestService
    {
        void SendContactRequest(int requestSentById, int requestSentToId);
        void AcceptContactRequest(int requestId);
        void DeclineContactRequest(int requestId);
        ContactRequest? GetContactRequestById(int ContactRequestId);
    }
}
