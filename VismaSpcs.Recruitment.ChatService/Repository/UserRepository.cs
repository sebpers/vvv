using VismaSpcs.Recruitment.ChatService.Data;
using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Interfaces.Repositories;

namespace VismaSpcs.Recruitment.ChatService.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Database _context;

        public UserRepository(Database context)
        {
            _context = context;
        }

         public User AddUser(User userModel)
        {
            _context.Users.Add(userModel);
            // _context.SaveChanges()

            return userModel;
        }

        public User? GetUserById(int id)
        {
            User? userModel = _context.Users.FirstOrDefault(user => user.Id == id);

            if (userModel is null)
            {
                return null;
            }

            return userModel;
        }
        
        public User? GetUserByEmail(string email)
        {
            User? userModel = _context.Users.FirstOrDefault(user => user.Email.ToLower() == email.ToLower());

            return userModel;
        }

        public User? UpdateStatus(User? userModel)
        {
            // _context.SaveChanges()
            return userModel;
        }
    }
}
