using VismaSpcs.Recruitment.ChatService.Data;
using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Interfaces.Repositories;

namespace VismaSpcs.Recruitment.ChatService.Repository
{
    public class ContactRequestRepository : IContactRequestRepository
    {
        private readonly Database _context;

        public ContactRequestRepository(Database context)
        {
            _context = context;
        }

        public void AddContactRequest(ContactRequest contactRequest)
        {
            _context.ContactRequests.Add(contactRequest);
            // _context.SaveChanges();
        }

        public ContactRequest Update(ContactRequest contactRequest)
        {
            // _context.SaveChanges();

            return contactRequest;
        }

        public ContactRequest? GetContactRequestById(int id)
        {
            ContactRequest? contactRequestModel = _context.ContactRequests.FirstOrDefault(cr => cr.Id == id);

            return contactRequestModel;
        }

        public bool AlreadyExists(int requestSentById, int requestSendToId)
        {
            bool alreadyExists = _context.ContactRequests.Any(
                cr => cr.RequestSentById == requestSentById &&
                cr.RequestSentToId == requestSendToId &&
                cr.Status == Enum.ContactRequestStatus.Pending
             );

            return alreadyExists;
        }
    }
}
