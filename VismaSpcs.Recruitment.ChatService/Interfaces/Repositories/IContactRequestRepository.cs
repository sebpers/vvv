using VismaSpcs.Recruitment.ChatService.Entities;

namespace VismaSpcs.Recruitment.ChatService.Interfaces.Repositories
{
    public interface IContactRequestRepository
    {
        bool AlreadyExists(int requestSentById, int requestSendToId);
        ContactRequest? GetContactRequestById(int id);
        void AddContactRequest(ContactRequest contactRequest);
        ContactRequest Update(ContactRequest contactRequest);
    }
}
