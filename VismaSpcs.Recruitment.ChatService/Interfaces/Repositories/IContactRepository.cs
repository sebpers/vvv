using VismaSpcs.Recruitment.ChatService.Entities;

namespace VismaSpcs.Recruitment.ChatService.Interfaces.Repositories
{
    public interface IContactRepository
    {
        public Contact AddContact(Contact contactModel);
        public Contact? GetContactByIds(int requestBy, int requestTo);
    }
}
