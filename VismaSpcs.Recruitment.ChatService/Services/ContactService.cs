using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Validators;
using VismaSpcs.Recruitment.ChatService.Interfaces.Repositories;
using VismaSpcs.Recruitment.ChatService.Interfaces.Services;

namespace VismaSpcs.Recruitment.ChatService.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public Contact AddContact(Contact contactModel)
        {
            Contact? exists = _contactRepository.GetContactByIds(contactModel.RequestSentById, contactModel.RequestSentToId);

            Validate.AlreadyExists(exists, nameof(exists));

            _contactRepository.AddContact(contactModel);

            return contactModel;
        }
    }
}
