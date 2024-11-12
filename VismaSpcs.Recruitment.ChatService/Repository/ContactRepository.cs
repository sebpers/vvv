using ChatService.Data;
using ChatService.Entities;
using ChatService.Interfaces.Repositories;

namespace ChatService.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly Database _context;

        public ContactRepository(Database context)
        {
            _context = context;
        }

        public Contact? AddContact(Contact contactModel)
        {
            _context.Contacts.Add(contactModel);

            // _context.SaveChanges();

            return contactModel;
        }

        public Contact? GetContactByIds(int requestBy, int requestTo)
        {
            Contact? ContactModel = _context.Contacts.FirstOrDefault(c => c.RequestSentById == requestBy && c.RequestSentToId == requestTo);

            return ContactModel;
        }
    }
}
