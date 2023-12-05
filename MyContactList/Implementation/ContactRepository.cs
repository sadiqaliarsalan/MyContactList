using MyContactList.Common.Models;
using MyContactList.Interfaces;

public class ContactRepository : IContactRepository
{
    private List<Contact> _contacts = new();

    /// <summary>
    /// Initializes the repository with 25 dummy contacts
    /// </summary>
    public ContactRepository()
    {
        for (int i = 1; i <= 25; i++)
        {
            _contacts.Add(new Contact
            {
                Id = i,
                Name = $"John {i}",
                Address = $"{i} Old Street",
                PhoneNumber = "1231239999",
                Birthday = new DateTime(1980, 1, 1),
                Workplace = $"Company Number {i}"
            });
        }
    }

    /// <summary>
    /// Gets all contacts from the repository
    /// </summary>
    /// <returns>A list of all contacts if available, or null if no contacts are stored</returns>
    public List<Contact>? GetAllContacts()
    {
        return _contacts != null ? _contacts : null;
    }

    /// <summary>
    /// Retrieves a contact by its id
    /// </summary>
    /// <param name="id">The id of the contact</param>
    /// <returns>The contact if found, or null if no contact with the given id found</returns>
    public Contact? GetContactById(int id)
    {
        return _contacts.FirstOrDefault(c => c.Id == id);
    }

    /// <summary>
    /// Updates the information of an existing contact in the repository
    /// </summary>
    /// <param name="contact">The contact with updated information</param>
    /// <returns>The updated contact if the operation is successful, or null if the contact do not exist</returns>
    public Contact? UpdateContact(Contact contact)
    {
        var index = _contacts.FindIndex(c => c.Id == contact.Id);
        if (index == -1)
        {
            return null;
        }

        _contacts[index] = contact;
        return contact;
    }
}
