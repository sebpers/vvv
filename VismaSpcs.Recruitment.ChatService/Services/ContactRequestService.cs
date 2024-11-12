using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Enum;
using VismaSpcs.Recruitment.ChatService.Validators;
using VismaSpcs.Recruitment.ChatService.Interfaces.Repositories;
using VismaSpcs.Recruitment.ChatService.Interfaces.Services;

namespace VismaSpcs.Recruitment.ChatService.Services
{
    public class ContactRequestService : IContactRequestService
    {
        private readonly IContactRequestRepository _contactRequestRepository;
        private readonly IUserRepository _userRepostirory;
        private readonly IContactRepository _contactRepository;

        public ContactRequestService(
            IContactRequestRepository contactRequestRepository,
            IUserRepository userRepository,
            IContactRepository contactRepository
        )
        {
            _contactRequestRepository = contactRequestRepository;
            _userRepostirory = userRepository;
            _contactRepository = contactRepository;
        }

        public void SendContactRequest(int requestSentById, int requestSentToId)
        {
            User? requestSentBy = _userRepostirory.GetUserById(requestSentById);
            User? requestSentTo = _userRepostirory.GetUserById(requestSentToId);

            Validate.NotNull(requestSentBy, nameof(requestSentBy));
            Validate.NotNull(requestSentTo, nameof(requestSentTo));

            bool exists = _contactRequestRepository.AlreadyExists(requestSentToId, requestSentToId);
            Validate.AlreadyExistsByBool(exists, "Pending contact request");

            ContactRequest contactRequestModel = new()
            {
                RequestSentById = requestSentById,
                RequestSentToId = requestSentToId,
                Status = ContactRequestStatus.Pending,
                CreatedAt = DateTime.Now
            };

            _contactRequestRepository.AddContactRequest(contactRequestModel);
        }

        public void AcceptContactRequest(int contactRequestId)
        {
            ContactRequest? contactRequestModel = GetContactRequestById(contactRequestId);

            Validate.NotNull(contactRequestModel, nameof(contactRequestModel));

            if (contactRequestModel.Status != ContactRequestStatus.Pending)
            {
                throw new Exception($"Request is invalid, current status is not pending. Current status: {contactRequestModel.Status}");
            }

            Contact? contact = _contactRepository.GetContactByIds(contactRequestModel.RequestSentById, contactRequestModel.RequestSentToId);
            Validate.AlreadyExists(contact, nameof(contact));

            contactRequestModel.Status = ContactRequestStatus.Accepted;
            contactRequestModel.RequestRespondedAt = DateTime.Now;

            _contactRequestRepository.Update(contactRequestModel);

            Contact contactModel = new()
            {
                RequestSentById = contactRequestModel.RequestSentById,
                RequestSentToId = contactRequestModel.RequestSentToId,
                CreatedAt = DateTime.Now
            };

            _contactRepository.AddContact(contactModel);
        }

        public void DeclineContactRequest(int contactRequestId)
        {
            ContactRequest? contactRequestModel = GetContactRequestById(contactRequestId);

            Validate.NotNull(contactRequestModel, nameof(contactRequestModel));

            if (contactRequestModel.Status != ContactRequestStatus.Pending)
            {
                throw new Exception($"Request is invalid, current status is not pending. Current status: {contactRequestModel.Status}");
            }

            contactRequestModel.Status = ContactRequestStatus.Declined;
            contactRequestModel.RequestRespondedAt = DateTime.Now;

            _contactRequestRepository.Update(contactRequestModel);
        }

        public ContactRequest? GetContactRequestById(int ContactRequestId)
        {
            ContactRequest? contactRequestModel = _contactRequestRepository.GetContactRequestById(ContactRequestId);

            return contactRequestModel;
        }
    }
}
