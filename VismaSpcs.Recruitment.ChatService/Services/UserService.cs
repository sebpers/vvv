using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Enum;
using VismaSpcs.Recruitment.ChatService.Validators;
using VismaSpcs.Recruitment.ChatService.Interfaces.Repositories;
using VismaSpcs.Recruitment.ChatService.Interfaces.Services;

namespace VismaSpcs.Recruitment.ChatService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IContactRequestService _contactRequestService;

        public UserService(IUserRepository userRepository, IContactRequestService contactRequestService)
        {
            _userRepository = userRepository;
            _contactRequestService = contactRequestService;
        }

        public User? AddUser(User userModel)
        {
            Validate.NotNull(userModel, nameof(userModel));            
            Validate.NotNullOrWhiteSpace(userModel.Email, nameof(userModel.Email));

            User? existingUserModel = _userRepository.GetUserByEmail(userModel.Email);

            Validate.AlreadyExists(existingUserModel, nameof(existingUserModel));

            User? user = _userRepository.AddUser(userModel);

            return user;
        }

        public User? GetUserById(int id)
        {
            User? userModel = _userRepository.GetUserById(id);

            Validate.NotNull(userModel, nameof(userModel));

            return userModel;
        }

        public User? UpdateStatus(int id, UserStatus status, string customStatusMessage)
        {
            User? userModel = GetUserById(id);

            Validate.NotNull(userModel, nameof(userModel));

            userModel.UpdateStatus(status, customStatusMessage);

            User? updatedUserModel = _userRepository.UpdateStatus(userModel);

            return updatedUserModel;
        }

        public void SendContactRequest(int requestSentById, int requestSentToId)
        {
            _contactRequestService.SendContactRequest(requestSentById, requestSentToId);
        }

        public void AcceptContactRequest(int contactRequestId)
        {
            _contactRequestService.AcceptContactRequest(contactRequestId);
        }

        public void DeclineContactRequest(int contactRequestId)
        {
            _contactRequestService.DeclineContactRequest(contactRequestId);
        }
    }
}
