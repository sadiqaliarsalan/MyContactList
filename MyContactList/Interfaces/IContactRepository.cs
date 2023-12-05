using MyContactList.Common.Models;

namespace MyContactList.Interfaces
{
    public interface IContactRepository
    {
        List<Contact>? GetAllContacts();

        Contact? GetContactById(int id);

        Contact? UpdateContact(Contact contact);
    }
}
